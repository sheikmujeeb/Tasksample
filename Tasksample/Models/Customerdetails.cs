﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("CustomerType")]
        public long CustomerTypeId { get; set; }
        [Required]
        [MaxLength(10)]
        [Range(1, 9999999999, ErrorMessage = "Please Enter the correct number")]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
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
        [MaxLength(50)]
        public string Remarks { get; set; } = string.Empty;
        [Required]
        
        public DateTime CreatedOn { get; set; }
        
        public DateTime? UpdatedOn { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

    }
 
}