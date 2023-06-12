using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.Models
{
    public class ImageUploadResponseModel
    {
        public bool Success { get; set; }

        public string FilePath { get; set; } = null!;

        public string Error { get; set; } = null!;
    }
}
