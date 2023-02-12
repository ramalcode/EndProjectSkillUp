using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;

namespace SkillUp.Entity.Entities.Relations.CourseExtraProperities
{
    public class Category : BaseNameableEntity
    {
        public string Description { get; set; }
        public string IconUrl { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<CourseCategory> CourseCategories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
