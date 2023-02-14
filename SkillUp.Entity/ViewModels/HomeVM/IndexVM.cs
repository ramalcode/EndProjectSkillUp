using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;

namespace SkillUp.Entity.ViewModels
{
    public class IndexVM
    {
        public ICollection<Course> Courses { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
