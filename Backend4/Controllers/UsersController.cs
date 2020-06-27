
using Backend4.Models.Users;
using Backend4.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend4.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUsersService usersService;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                // if user already exist.
                var existingUser = this.usersService.FindByFullName(user.FirstName, user.LastName);
                if (existingUser != null)
                {
                    logger.LogInformation("A user with provided information already exist.");

                    existingUser.UserExist = true;
                    return this.View("SignUpAlreadyExist", existingUser);
                }

                return this.View("SignUpCredentials", new UserCredential());
            }

            return this.View(user);
        }

        public IActionResult SignUpCredentials(string fullName)
        {
            var fullNameSplitted = fullName.Split(" ");

            var user = this.usersService.FindByFullName(fullNameSplitted[0], fullNameSplitted[1]);

            if (user == null)
            {
                return NotFound();
            }

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUpCredentials(UserCredential credential)
        {
            if (!ModelState.IsValid)
            {
                return View(credential);
            }

            if (!credential.UserExist)
            {
                logger.LogInformation("Creating a user account.");

                this.usersService.Create(credential);
            }

            return this.View("Complete", credential);
        }
    }
}