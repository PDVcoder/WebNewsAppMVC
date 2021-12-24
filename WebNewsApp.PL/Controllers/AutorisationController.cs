using Microsoft.AspNetCore.Mvc;
using NewsWebApp.BLL.DTO;
using NewsWebApp.BLL.Infrastructure;
using NewsWebApp.BLL.Interfaces;
using NewsWebApp.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.PL.Controllers
{
    public class AutorisationController : Controller
    {
        public AutorisationController(IAutoresationService autoresationService)
        {
            _autoresationService = autoresationService;
        }

        private IAutoresationService _autoresationService;

        public IActionResult Autorisation()
        {
            return View("Autorisation");
        }

        [HttpPost]
        public IActionResult Register(AutrorisationModel model)
        {
            string result = string.Empty;
            
            string username = "", firstname = "", lastname = "", email = "", mobile = "", password1 = "", password2 = "";

            if (model.RegistrationModel.Username == null || 
                model.RegistrationModel.Firstname == null ||
                model.RegistrationModel.Lastname == null ||
                model.RegistrationModel.Email == null ||
                model.RegistrationModel.Mobile == null ||
                model.RegistrationModel.Password1 == null ||
                model.RegistrationModel.Password2 == null)
            {
                result = "Empty strings";
                ViewBag.Result = result;
                return View("Autorisation");
            }
            username = model.RegistrationModel.Username;
            firstname = model.RegistrationModel.Firstname;
            lastname = model.RegistrationModel.Lastname;
            email = model.RegistrationModel.Email;
            mobile = model.RegistrationModel.Mobile;
            password1 = model.RegistrationModel.Password1;
            password2 = model.RegistrationModel.Password2;

            if (!password1.Equals(password2)) result = "Password don't match";
            else
            {
                AuthorDTO author = new AuthorDTO
                {
                    Username = username,
                    Firstname = firstname,
                    Lastname = lastname,
                    Email = email,
                    Password = password1,
                    Mobile = mobile
                };
                try
                {
                    _autoresationService.RegistrateUser(author);
                    result = "Registered successful!";
                }
                catch (ValidationException e)
                {
                    result = e.Message;
                }
            }
            ViewBag.Result = result;
            return View("Autorisation");
        }

        
        public IActionResult Login(AutrorisationModel model)
        {
            string result = string.Empty;
            string login = "", password = "";
            if (model.LoginModel.Username == null || 
                model.LoginModel.Password == null)
            {
                result = "Empty strings";
                ViewBag.Result = result;
                return View("Autorisation");
            }

            login = model.LoginModel.Username;
            password = model.LoginModel.Password;

            try
            {
                var user = _autoresationService.LogIn(login, password);
                int id = user.Id;
                result = "Login successful!";
                return this.RedirectToAction("PublishPage", "Publisher", new { id }); 
            }
            catch (ValidationException e)
            {
                result = e.Message;
            }
            ViewBag.Result = result;
            return View("Autorisation");
        }
    }
}
