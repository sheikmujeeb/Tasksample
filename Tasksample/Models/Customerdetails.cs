﻿using System.ComponentModel.DataAnnotations;

namespace Tasksample.Models


{
    public class Customerdetails
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(25)]
        public string CustomerType { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;
        [Required]
        [MaxLength(25)]
        public string Country { get; set; } = string.Empty;       
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [MaxLength(25)]
        public string Remarks { get; set; } = string.Empty;
        [Required]

       // [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        
        //[DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        [Required]

        public bool IsDeleted { get; set; } = false;

    }
}