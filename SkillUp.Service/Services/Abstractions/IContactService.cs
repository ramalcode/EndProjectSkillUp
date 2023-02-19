using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.Entities.Settings;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IContactService
    {
        Task<ICollection<ContactUs>> GetAllMessageAsync();

        Task CreateContactAsync(CreateContactVM contactVM);

        Task DeleteMessageAsync(int id);

    }
}
