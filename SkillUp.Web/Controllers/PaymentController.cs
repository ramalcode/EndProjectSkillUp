using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using Stripe;
using System;

namespace SkillUp.Web.Controllers
{
    public class PaymentController : Controller
    {
        UserManager<AppUser> _userManager;
        AppDbContext _appDbContext;

        public PaymentController(UserManager<AppUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Payment()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken, double wallet)
        {
            var customers = new CustomerService();
            var chargers = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken,
            });

            var charge = chargers.Create(new ChargeCreateOptions
            {
                
                Amount = (long) wallet,
                Description = "Add Balance",
                Currency = "usd",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    {"OrderId","111" },
                    {"PostCode","LEE111" }
                }

              

            });

            if (charge.Status == "succeeded")
            {
              
                string BalanceTransactionId = charge.BalanceTransactionId;
                string id = _userManager.GetUserId(HttpContext.User) ;
                AppUser user = _appDbContext.AppUsers.FirstOrDefault(x => x.Id == id);
                user.Wallet += charge.Amount;
                _appDbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            //else 

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> BuyCourse(int courseid)
        {
            var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseid);
            string id = _userManager.GetUserId(HttpContext.User);
            AppUser user = _appDbContext.AppUsers.FirstOrDefault(x => x.Id == id);
            if (user.Wallet > course.Price * 100)
            {
                AppUserCourse userCourse = new AppUserCourse
                {
                    AppUserId = user.Id,
                    CourseId = courseid,
                };

                user.Wallet = user.Wallet - course.Price * 100;

                await _appDbContext.AddAsync(userCourse);
                await _appDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> BuyProduct(int productid)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productid);
            string id = _userManager.GetUserId(HttpContext.User);
            AppUser user = _appDbContext.AppUsers.FirstOrDefault(x => x.Id == id);
            if (user.Wallet > product.Price * 100)
            {
                AppUserProduct userProduct = new AppUserProduct
                {
                    AppUserId = user.Id,
                    ProductId = productid,
                };

                user.Wallet = user.Wallet - product.Price * 100;

                await _appDbContext.AddAsync(userProduct);
                await _appDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
