using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.Entities.Relations.ManyToMany;

namespace SkillUp.Entity.Entities
{
    public class Course:BaseNameableEntity
    {
        public int ViewCount { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string Description { get; set; }
        public string CourseOverview { get; set; }
        public string Requirement { get; set; }
        public string Certification { get; set; }
        public string? ImageUrl { get; set; }
        public string? PreviewUrl { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;



        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }


        public ICollection<Paragraph>? Paragraphs { get; set; }
        public ICollection<CourseCategory>? CourseCategories { get; set; }
        public ICollection<AppUserCourse>? AppUserCourses { get; set; }



    }
}
