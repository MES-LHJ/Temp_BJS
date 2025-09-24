using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Dpt
{
    //public class TreeNode
    //{
    //    public long Id { get; set; }
    //    public long ParentId { get; set; }
    //    public string Code { get; set; }
    //    public string Name { get; set; }
    //}
    public partial class Tree : Form
    {
        public class TreeNodeDto
        {
            public long Id { get; set; }
            public long ParentId { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
        }
        public Tree()
        {
            InitializeComponent();
            this.Load += DeptTree_Load;
        }

        private void DeptTree_Load(object sender, EventArgs e)
        {
            SetupTreeList();
        }

        private void SetupTreeList()
        {
            // 1. 모든 데이터 가져오기
            var upperDepts = SqlReposit.GetUpperDepartments().ToList();
            var departments = SqlReposit.GetDepartments().ToList();
            var employees = SqlReposit.GetEmployees().ToList();

            // 2. 모든 객체를 담을 리스트 생성
            var allNodes = new List<TreeNodeDto>();

            allNodes.AddRange(upperDepts.Select(u => new TreeNodeDto
            {
                Id = 1000000 + u.UpperDepartmentId,
                ParentId = u.ParentId == 0 ? 0 : 1000000 + u.ParentId,
                Code = u.UpperDepartmentCode,
                Name = u.UpperDepartmentName
            }));

            allNodes.AddRange(departments.Select(d => new TreeNodeDto
            {
                Id = 2000000 + d.DepartmentId,
                ParentId = 1000000 + d.UpperDepartmentId,
                Code = d.DepartmentCode,
                Name = d.DepartmentName
            }));

            allNodes.AddRange(employees.Select(e => new TreeNodeDto
            {
                Id = 3000000 + e.EmployeeId,
                ParentId = 2000000 + e.DepartmentId,
                Code = e.EmployeeCode,
                Name = e.EmployeeName
            }));


            // 3. TreeList 컨트롤 설정
            deptTree.KeyFieldName = "Id";
            deptTree.ParentFieldName = "ParentId";
            deptTree.Columns.Clear();

            TreeListColumn codeCol = deptTree.Columns.Add();
            codeCol.FieldName = "Code"; // 통일된 속성 이름 사용
            codeCol.Caption = "코드";
            codeCol.Visible = true;
            codeCol.OptionsColumn.AllowEdit = false;

            //TreeListColumn nameCol = deptTree.Columns.Add();
            //nameCol.FieldName = "Name"; // 통일된 속성 이름 사용
            //nameCol.Caption = "이름";
            //nameCol.Visible = true;
            //nameCol.OptionsColumn.AllowEdit = false;

            deptTree.DataSource = allNodes;
            deptTree.ExpandAll();
        }
    }
}
