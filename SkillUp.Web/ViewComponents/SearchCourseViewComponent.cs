using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.Context;

namespace SkillUp.Web.ViewComponents
{
    public class SearchCourseViewComponent:ViewComponent
    {
        readonly AppDbContext _context;

        public SearchCourseViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string searchcourse)
        {
            var courses = _context.Courses.Where(c => c.Name.Contains(searchcourse)).ToList();
            return View(courses);
        }
    }
}
