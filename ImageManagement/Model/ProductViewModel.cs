using System.ComponentModel.DataAnnotations;

namespace ImageManagement.Model
{
    public class ProductViewModel
    {
        public int ImageId { get; set; }
        public string FileName { get; set; } = null!;
        [Required]
        public IFormFile FilePath { get; set; } = null!;
        public DateTime? UploadDate { get; set; }
        public string UploadedBy { get; set; } =null!;
        public string? Description { get; set; }
        public string? Tags { get; set; }
    }
}
