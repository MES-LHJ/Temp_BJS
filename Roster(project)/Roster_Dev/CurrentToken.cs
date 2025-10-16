using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev
{
    public static class CurrentToken
    {
        // 1. 실제 API 호출에 사용할 토큰
        public static string CompanyToken { get; set; }
        public static string EmployeeToken { get; set; }

        // 2. 토큰이 만료될 정확한 시각
        public static DateTime ExpiryTime { get; set; }

        // 3. 토큰이 만료되어 재로그인이 필요한 상태인지 나타내는 플래그
        public static bool NeedsRelogin { get; set; }

        /// <summary>
        /// 토큰이 만료되었는지 확인하는 속성
        /// </summary>
        public static bool IsExpired
        {
            get
            {
                // 현재 시간이 만료 시각보다 크거나 같으면 만료됨
                return DateTime.Now >= ExpiryTime;
            }
        }

        /// <summary>
        /// 토큰 정보를 초기화하고 NeedsRelogin 플래그를 재설정합니다.
        /// </summary>
        public static void Reset()
        {
            CompanyToken = null;
            EmployeeToken = null;
            ExpiryTime = DateTime.MinValue;
            NeedsRelogin = false;
        }
    }
}
