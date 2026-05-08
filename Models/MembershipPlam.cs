namespace GYM_Desktop_app.Models
{
    public class MembershipPlan
    {
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
    }
}