﻿using SkillUp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.Entity.Entities.Settings
{
    public class ContactUs:BaseNameableEntity
    {
        [Required, MaxLength(20)]
        public string Surname { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required, MinLength(50), MaxLength(1500)]
        public string Message { get; set; }
    }
}
