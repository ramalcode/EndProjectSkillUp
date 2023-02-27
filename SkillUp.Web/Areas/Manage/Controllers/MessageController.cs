using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities.Settings;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class MessageController : Controller
    {
        readonly IContactService _contactService;
        readonly IUnitOfWork _unitOfWork;


        public MessageController(IContactService contactService, IUnitOfWork unitOfWork)
        {
            _contactService = contactService;
            _unitOfWork = unitOfWork;
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

        public async Task<IActionResult> ReadMessage(int id)
        {
            await _contactService.ReadMessageAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
