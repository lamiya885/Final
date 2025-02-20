using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Final_CFF.BL.Extentions;

public static class FileExtention
{
    public static bool IsValidType(this IFormFile file, string type)
         => file.ContentType.StartsWith(type);
    public static bool IsValidSize(this IFormFile file, int kb)
        => file.Length <= kb * 1024;
    public static async Task<string> UploadAsync(this IFormFile file, params string[] paths)
    {
        string uploadPath = Path.Combine(paths);

        if (File.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        string fileName = Path.GetRandomFileName() + Path.GetExtension(uploadPath);

        using (Stream stream = File.Create(Path.Combine(uploadPath, fileName)))
        {
            await file.CopyToAsync(stream);
        }
        return fileName;

    }
}