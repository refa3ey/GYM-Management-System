using System;
namespace GYM_Desktop_app.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime JoinDate { get; set; }
        public int PlanID { get; set; }
        public DateTime MembershipExpiry { get; set; }
    }
}