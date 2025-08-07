using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.AttachmentServices
{
    public interface IAttachmentService
    {
        public string? UploadFile( IFormFile file, string foldername);
        public bool DeleteFile(string filepath);

    }
}
