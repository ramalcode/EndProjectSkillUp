using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations;

namespace SkillUp.Entity.Entities.Relations.ManyToMany
{
    public class ProductInstructor:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
