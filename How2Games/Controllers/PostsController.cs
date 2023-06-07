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
        public JsonResult UploadFile(IFormFile file)
        {
            ImageUploadResponseModel vm = new();

            if (file != null && file.Length > 0)
            {
                // Generate a unique file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Set the path to save the file within the wwwroot/Uploads folder
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                    file.CopyTo(stream);

                ViewBag.FilePath = filePath;
                Console.WriteLine(filePath);
                vm.Success = true;
            }


            return Json(vm);
        }
    }
}
