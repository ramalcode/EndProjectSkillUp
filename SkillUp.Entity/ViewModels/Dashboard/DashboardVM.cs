﻿using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;

namespace SkillUp.Entity.ViewModels
{
    public class DashboardVM
    {
        public ICollection<Course> Courses { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
    }
}
