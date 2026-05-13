using System;

namespace GYM_Desktop_app.Models
{
    public class Attendance
    {
        public int       AttendanceID  { get; set; }
        public int       MemberID      { get; set; }
        public string    MemberName    { get; set; }
        public DateTime  CheckInTime   { get; set; }
        public DateTime? CheckOutTime  { get; set; }
        public string    Notes         { get; set; }

        public TimeSpan? Duration =>
            CheckOutTime.HasValue ? (TimeSpan?)(CheckOutTime.Value - CheckInTime) : null;

        public string Status =>
            CheckOutTime.HasValue ? "Completed" : "Checked In";
    }
}
