using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AbpCMS.Web.Helpers
{
    public static class FileHelpers
    {
        public static List<string> ReadAsList(this IFormFile file)
        {
            var result = new List<string>();
            using var reader = new StreamReader(file.OpenReadStream());
            while (reader.Peek() >= 0)
            {
                result.Add(reader.ReadLine());
            }

            return result;
        }
    }
}
