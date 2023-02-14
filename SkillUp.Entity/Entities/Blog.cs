using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;

namespace SkillUp.Entity.Entities
{
    public class Blog:BaseNameableEntity
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string FirstDescription { get; set; }
        public string CreaterComment { get; set; }
        public string SecondaryDescription { get; set; }

        public ICollection<BlogCategory> BlogCategories { get; set; }
    }
}
