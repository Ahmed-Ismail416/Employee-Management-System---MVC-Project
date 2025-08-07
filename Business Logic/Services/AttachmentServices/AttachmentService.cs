using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.AttachmentServices
{
    public class AttachmentService : IAttachmentService
    {
        // Extensions Allowed
        List<string> extensionallowed = [".gif", ".jpeg", ".png", ".jpg", ".jfif"];
        
        //sizefile
        int sizefile = 4_194_304; // 
        public string? UploadFile(IFormFile file, string FolderName)
        {
            // confirm the extension
            var extension = Path.GetExtension(file.FileName);
            if (!extensionallowed.Contains(extension)) return null;
            // confirm the size
            if (file.Length > sizefile || file.Length == 0) return null;
            // Folder Path 
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);
            //file name
            var filename = $"{Guid.NewGuid().ToString()}_{ extension}";
            // filepath
            var filepath = Path.Combine(folderpath, filename);
            // upload the file
            using FileStream fs = new FileStream(filepath, FileMode.Create);
            file.CopyTo(fs);

            return filename;



        }
        public bool DeleteFile(string filepath)
        {
            // 
            if (!File.Exists(filepath)) return false;
            File.Delete(filepath);
            return true;
        }

    }
}
