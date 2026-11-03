using ImageManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace ImageManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly ImageManagementContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(ImageManagementContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.ImageMetadata.ToList());
        }

        public IActionResult AddProduct()
        {
            return View(); // Pass a new instance
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model)
        {
            string FileName = "";
            //if (ModelState.IsValid)
            //{
                if (model.FilePath != null)
                {
                    string path = Path.Combine(_env.WebRootPath, "Images");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    FileName = Guid.NewGuid().ToString() + Path.GetExtension(model.FilePath.FileName);
                    string filePath = Path.Combine(path, FileName);
                    model.FilePath.CopyTo(new FileStream(filePath, FileMode.Create));
                    var imageMetadata = new ImageMetadatum
                    {
                        FileName = model.FileName,
                        FilePath = filePath,
                        UploadDate = DateTime.Now,
                        UploadedBy = _env.ApplicationName,
                        Description = model.Description,
                        Tags = model.Tags
                    };
                    _context.ImageMetadata.Add(imageMetadata);
                    _context.SaveChanges();
                }
                // Save the uploaded file to a specific location
                //var filePath = Path.Combine("wwwroot/images", model.FilePath.FileName);
                //using (var stream = new FileStream(filePath, FileMode.Create))
                //{
                //    model.FilePath.CopyTo(stream);
                //}
                //// Save the metadata to the database
                //var imageMetadata = new ImageMetadatum
                //{
                //    FileName = model.FileName,
                //    FilePath = filePath,
                //    UploadDate = DateTime.Now,
                //    UploadedBy = model.UploadedBy,
                //    Description = model.Description,
                //    Tags = model.Tags
                //};
                //_context.ImageMetadata.Add(imageMetadata);
                //_context.SaveChanges();
                //return RedirectToAction("Index");
            //}
            return View(model);
        }

    }
}
