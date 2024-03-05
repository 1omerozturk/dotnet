namespace Basics.Models
{
    public class Candidate
    {
        public String? Email { get; set; } = String.Empty;
        public String? Firstname { get; set; } = String.Empty;
        public String? Lastname { get; set; } = String.Empty;
        public String? Fullname => $"{Firstname} {Lastname}";
        public int? Age { get; set; }
        public String? SelectedCourse { get; set; } = String.Empty;

        public DateTime ApplyAt { get; set; }

    public Candidate(){
        ApplyAt=DateTime.Now;
    }
    }


}