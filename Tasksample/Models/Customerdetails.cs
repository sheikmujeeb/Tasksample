using System.ComponentModel.DataAnnotations;

namespace Tasksample.Models


{
    public class Customerdetails
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Customer Type")]
        public string Customertype { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Phone Number")]
        public long Phonenumber { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Display(Name = "Is Active")]
        [Required]
        public bool Isactive { get; set; }
        [Required]
        public string Remarks { get; set; } = string.Empty;

    }
}