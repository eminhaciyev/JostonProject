using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JostonPortfolioProject.Areas.Admin.Utilities
{
    public static class Utilities
    {
        public static void Remove(string image)
        {
            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), image);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}