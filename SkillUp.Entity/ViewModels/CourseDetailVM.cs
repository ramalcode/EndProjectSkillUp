using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;

namespace SkillUp.Entity.ViewModels
{
    public class CourseDetailVM
    {
        public Course Course { get; set; }
        public ICollection<Paragraph> Paragraphs { get; set; }
        
    }
}
