using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Service.Services.Concretes
{
	public class ParagraphService : IParagraphService
	{
		readonly IUnitOfWork _unitOfWork;
		readonly AppDbContext appDbContext;

		public ParagraphService(IUnitOfWork unitOfWork, AppDbContext appDbContext)
		{
			_unitOfWork = unitOfWork;
			this.appDbContext = appDbContext;
		}

		public async Task CreateParagraphAsync(CreateParagraphVM paragraphVM)
		{
			Paragraph paragraph = new Paragraph
			{
				Name = paragraphVM.Name,
				CourseId = paragraphVM.CourseId,
			};
			 await _unitOfWork.GetRepository<Paragraph>().AddAsync(paragraph);
			await _unitOfWork.SaveAsync();
		}

		public Task DeleteParagraphAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<ICollection<Paragraph>> GetAllParagraphAsync()
		{
			var paragraph = appDbContext.Paragraphs.Include(x=>x.Lectures).ToList();
			//var paragraph = await _unitOfWork.GetRepository<Paragraph>().GetAllAsync(null, x=>x.Lectures.ToList());
			return paragraph;

		}

		public Task<Paragraph> GetParagraphById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateParagraphAsync(UpdateParagraphVM paragraphVM)
		{
			throw new NotImplementedException();
		}

		public Task<UpdateCategoryVM> UpdateParagraphById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
