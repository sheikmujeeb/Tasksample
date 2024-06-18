using System.ComponentModel.DataAnnotations;

namespace Tasksample.Customerdetails

{
    public class Customerdetails
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Customer Type")]
        public string Customertype { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Phone Number")]
        [Range(6000000000, 9999999999, ErrorMessage = "Please enter correct Number")]
        public long Phonenumber { get; set; }
        [Display(Name = "Date of Birth")]
        public DateOnly Dateofbirth { get; set; }
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Display(Name = "Is Active")]
        public bool Isactive { get; set; }
        public string Remarks { get; set; } = string.Empty;

    }
}