using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCourse.Data;
using MyCourse.Models;
using MyCourse.ViewModels;


namespace MyCourse.Controllers
{
    public class AccountController : Controller
    {

        private readonly AppDbContext mydb;
        UserManager<ApplicationUser> _usermanager;
        SignInManager<ApplicationUser> _signinmanager;
        RoleManager<IdentityRole> _rolemanager;


        public AccountController(AppDbContext db, UserManager<ApplicationUser> usermanager,
        SignInManager<ApplicationUser> signinmanager, RoleManager<IdentityRole> rolemanager)
        {
            mydb = db;
            _usermanager = usermanager;
            _signinmanager = signinmanager; 
            _rolemanager = rolemanager; 
        }


        public IActionResult Index()
        {
            return View();
        }

   
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                var res = await _signinmanager.PasswordSignInAsync(model.Email, model.Password, model.rememberme, false);
                if(res.Succeeded)
                {
                    return RedirectToAction("Index", "Appointment");
                }
                ModelState.AddModelError("" ,"Invalid Login Attempt");
            }
            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            if(!_rolemanager.RoleExistsAsync(Helpers.Helper.admin).GetAwaiter().GetResult())
            {
                await _rolemanager.CreateAsync(new IdentityRole(Helpers.Helper.admin));
                await _rolemanager.CreateAsync(new IdentityRole(Helpers.Helper.doctor));
                await _rolemanager.CreateAsync(new IdentityRole(Helpers.Helper.patient));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name
                };

                var result = await _usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _usermanager.AddToRoleAsync(user, model.Role);
                    await _signinmanager.SignInAsync(user, isPersistent:false);
                    return RedirectToAction("Login", "Account");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}







