using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Dpt
{
    public partial class Tree : Form
    {
        // 기본: factoryId=1 (F01) 로 동작. 필요 시 다른 팩토리 전달하는 오버로드도 제공
        private readonly long _factoryId;
        private readonly string _targetFactoryCode;

        public class TreeNodeDto
        {
            public long Id { get; set; }
            public long ParentId { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
        }

        public Tree() : this(1, "F01") { }       // Department 화면에서 기존처럼 호출해도 F01로 표시됨. :contentReference[oaicite:3]{index=3}
        public Tree(long factoryId, string targetFactoryCode = "F01")
        {
            InitializeComponent();
            _factoryId = factoryId;
            _targetFactoryCode = targetFactoryCode;
            this.Load += DeptTree_Load;
        }

        private async void DeptTree_Load(object sender, EventArgs e)
        {
            await SetupTreeListAsync();
        }

        private async Task SetupTreeListAsync()
        {
            var departments = await Roster_Dev.ApiRepository.GetDepartmentsAsync(_factoryId);  // Factory/Upper 포함
            var employees = await Roster_Dev.ApiRepository.GetEmployeesAsync(_factoryId);     // DepartmentId/Code/Name 포함

            var factoryIdFromDept = departments
                .Where(d => string.Equals(d.FactoryCode, _targetFactoryCode, StringComparison.OrdinalIgnoreCase))
                .Select(d => d.FactoryId)
                .Cast<long?>()
                .FirstOrDefault();

            var factoryIdFromEmp = employees
                .Where(e => string.Equals(e.FactoryCode, _targetFactoryCode, StringComparison.OrdinalIgnoreCase))
                .Select(e => (long?)e.FactoryId)
                .FirstOrDefault();

            var targetFactoryId = factoryIdFromDept ?? factoryIdFromEmp ?? 0;
            if (targetFactoryId == 0)
            {
                // F01이 없을 경우, 해당 팩토리의 첫 레코드로 대체(안전장치)
                targetFactoryId = departments.Select(d => d.FactoryId).Concat(employees.Select(e => e.FactoryId)).FirstOrDefault();
            }

            // 3) 노드 구성: 100만/200만/300만 대역으로 유니크 키 생성
            var factoryNodeId = 1_000_000 + targetFactoryId;

            var allNodes = new List<TreeNodeDto>();

            // 루트(Factory = 상위부서)
            var factoryName = departments.FirstOrDefault(d => d.FactoryId == targetFactoryId)?.FactoryName
                              ?? employees.FirstOrDefault(e => e.FactoryId == targetFactoryId)?.FactoryName
                              ?? _targetFactoryCode;
            var factoryCode = departments.FirstOrDefault(d => d.FactoryId == targetFactoryId)?.FactoryCode
                              ?? employees.FirstOrDefault(e => e.FactoryId == targetFactoryId)?.FactoryCode
                              ?? _targetFactoryCode;

            allNodes.Add(new TreeNodeDto
            {
                Id = factoryNodeId,
                ParentId = 0,
                Code = factoryCode,
                Name = factoryName
            });

            // 부서들 (해당 Factory만)
            var deptNodes = departments
                .Where(d => d.FactoryId == targetFactoryId)                                  // Factory 기준 필터
                .GroupBy(d => d.Id)                                                          // 동일 부서 중복 방지
                .Select(g =>
                {
                    var d = g.First();
                    return new TreeNodeDto
                    {
                        Id = 2_000_000 + d.Id,                                              // DepartmentWorkout.Id 사용
                        ParentId = factoryNodeId,
                        Code = d.Code,
                        Name = d.Name
                    };
                })
                .ToList();
            allNodes.AddRange(deptNodes);

            // 사원들 (부서 밑으로)
            var empNodes = employees
                .Where(e => e.FactoryId == targetFactoryId)                                  // 동일 Factory만
                .Select(e => new TreeNodeDto
                {
                    Id = 3_000_000 + e.Id,                                                  // EmployeeWorkout.Id 사용
                    ParentId = 2_000_000 + e.DepartmentId,                                  // 사원에서 부서 연결
                    Code = e.Code,
                    Name = e.Name
                })
                .ToList();
            allNodes.AddRange(empNodes);

            // 4) 트리 바인딩
            deptTree.KeyFieldName = "Id";
            deptTree.ParentFieldName = "ParentId";
            deptTree.Columns.Clear();

            var codeCol = deptTree.Columns.Add();
            codeCol.FieldName = "Code";
            codeCol.Caption = "코드";
            codeCol.Visible = true;
            codeCol.OptionsColumn.AllowEdit = false;

            var nameCol = deptTree.Columns.Add();
            nameCol.FieldName = "Name";
            nameCol.Caption = "이름";
            nameCol.Visible = true;
            nameCol.OptionsColumn.AllowEdit = false;

            deptTree.DataSource = allNodes;
            deptTree.ExpandAll();
        }
    }
}
