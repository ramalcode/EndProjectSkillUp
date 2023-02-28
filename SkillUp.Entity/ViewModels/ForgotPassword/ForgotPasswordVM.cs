using System.ComponentModel.DataAnnotations;

namespace SkillUp.Entity.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required, DataType(DataType.EmailAddress)] 
        public string? Email { get; set; }

    }
}
