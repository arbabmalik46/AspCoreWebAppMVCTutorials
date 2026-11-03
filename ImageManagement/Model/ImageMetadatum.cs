using System;
using System.Collections.Generic;

namespace ImageManagement.Model
{
    public partial class ImageMetadatum
    {
        public int ImageId { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public DateTime? UploadDate { get; set; }
        public string UploadedBy { get; set; } = null!;
        public string? Description { get; set; }
        public string? Tags { get; set; }
    }
}
