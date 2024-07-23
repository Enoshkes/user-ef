using Microsoft.AspNetCore.Mvc;
using user_app.Service;
using user_app.Models;
using user_app.Dto;


namespace user_app.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

        public async Task<IActionResult> Index() => View(await _userService.GetAll());

        public IActionResult Create()
        {
            return View(new CreateUserDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto userDto)
        {
            if (!ModelState.IsValid) { return RedirectToAction("Index"); }

            var createdUser = await _userService.CreateUser(userDto);

            return RedirectToAction("Details", "User", new { id = createdUser.Id });
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _userService.GetById(id));
        }
    }
}
