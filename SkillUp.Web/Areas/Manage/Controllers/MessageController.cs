using Microsoft.AspNetCore.Mvc;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MessageController : Controller
    {
        readonly IContactService _contactService;


        public MessageController(IContactService contactService)
        {
            _contactService = contactService;
        }


        //GetAll
        public async Task<IActionResult> Index()
        {
            var contact = await _contactService.GetAllMessageAsync();
            return View(contact);
        }


        //Delete
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _contactService.DeleteMessageAsync(id);
            return RedirectToAction(nameof(Index)); 
        }

        
    }
}
