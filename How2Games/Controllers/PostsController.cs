using How2Games.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace How2Games.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(string fileName, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Set the path to save the file within the wwwroot/Uploads folder
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                    file.CopyTo(stream);
            }


            return View();
        }
    }
}
