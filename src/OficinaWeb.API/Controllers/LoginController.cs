using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OficinaWeb.API.Validator;
using OficinaWeb.Models;

namespace OficinaWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel user = new UserViewModel();
            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            return View();
        }
    }
}