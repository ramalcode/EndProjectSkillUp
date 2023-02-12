using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.InstructorExtraProperities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.Entity.Entities
{
    public class Instructor:BaseNameableEntity
    {
        public string Surname { get; set; }
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PreviewVideoUrl { get; set; }
        public string StripeKey { get; set; }
        public string? FaceBookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public byte Experince { get; set; }


        public ICollection<InstructorProfession> InstructorProfessions { get; set; }
        public ICollection<AppUserInstructor> AppUserInstructors { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
