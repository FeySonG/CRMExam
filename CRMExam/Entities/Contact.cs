﻿using CRMExam.Enum;
using System.ComponentModel.DataAnnotations;

namespace CRMExam.Entities
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();  
        public Guid MarketingId { get; set; } 

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(100)]
        public string Surname { get; set; } = string.Empty;

        [StringLength(100)]
        public string Patronymic { get; set; } = string.Empty;

        [Required]
        public required string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public ContactStatus Status { get; set; }

        [Required]
        public DateTime DateOfChange { get; set; } = DateTime.UtcNow;
    }
}
