using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;

namespace SkillUp.Entity.Entities.Relations.ProductExtraProperities
{
    public class Author:BaseNameableEntity
    {
        public string Surname { get; set; }
        //public byte Age { get; set; }
        public ICollection<ProductAuthor> ProductAuthors { get; set; }

    }
}
