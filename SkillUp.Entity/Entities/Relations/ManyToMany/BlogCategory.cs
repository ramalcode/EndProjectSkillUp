﻿using SkillUp.Core.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;

namespace SkillUp.Entity.Entities.Relations.ManyToMany
{
    public class BlogCategory:BaseEntity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
