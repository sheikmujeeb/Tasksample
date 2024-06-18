using System.ComponentModel.DataAnnotations;

namespace Classlibrary
{
    public class Customerdetails
    {
        public int CustomerID { get; set; }
        [Required]
        [Display(Name ="Full Name")]
        public string Fullname { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public string Customertype { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public long Phonenumber { get; set; }
        [Display(Name = "Date of Birth")]
        public DateOnly Dateofbirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Display(Name = "Is Active")]
        public bool Isactive { get; set; }
        public string Remarks { get; set; }
    }
}
