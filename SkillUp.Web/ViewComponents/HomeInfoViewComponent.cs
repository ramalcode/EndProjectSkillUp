﻿using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.Context;

namespace SkillUp.Web.ViewComponents
{
	public class HomeInfoViewComponent:ViewComponent
	{
		readonly AppDbContext _context;

		public HomeInfoViewComponent(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(_context.HomeInfos.ToDictionary(s=>s.Key, s => s.Value));	
		}
	}
}