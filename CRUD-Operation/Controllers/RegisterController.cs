using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using CRUD.Services.Validator;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;

namespace CRUD_Operation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IValidator<Register> _validator;
        private readonly IValidator<Login> _loginValidator;

        public RegisterController(IProductRepository productRepo, IValidator<Register> validator, IValidator<Login> loginValidator )
        {
            _productRepo = productRepo;
            _validator = validator;
            _loginValidator = loginValidator;

        }



        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            var validator = new RegisterValidator();
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }
            model.Createdby = model.Name; 
            model.Updatedby = model.Name;

           
            model.IsActive = !string.IsNullOrEmpty(model.Name) &&
                            !string.IsNullOrEmpty(model.PhoneNumber) &&
                            !string.IsNullOrEmpty(model.Email) &&
                            !string.IsNullOrEmpty(model.Password);
            model.IsDelete = !(model.IsActive);
            model.IsAdmin = (model.IsActive);

            if (ModelState.IsValid)
            {
                await _productRepo.RegisterAdd(model);
                return RedirectToAction("AlertMessage");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            var validationResult = _loginValidator.Validate(model);

            if (validationResult.IsValid)
            {
             
                if (_productRepo.UserValid(model))
                {
                    // return RedirectToAction("Index", "Product");
                    return RedirectToAction("Index", "fieldGroove");
                }
            }
            else
            {
           
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model);
            }

            return View(); 
        }


        [HttpPost]
       
        public IActionResult ForgotPassword(string email , string password, string confirmPassword)
        {
            if (_productRepo.EmailValid(email))
            {
                _productRepo.UpdatePassword(email, password);
                return RedirectToAction("changePassword", "Register");

            }
            else
            {
                ModelState.AddModelError("", "Email not found. Please enter a valid email address.");
                return View();
            }
        }

      

     


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AlertMessage()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult changePassword()
        {
            return View();
        }
    }
}
