using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Helpers;

namespace JostonPortfolioProject.Areas.Admin.FileExtension
{
    public static class Extensions
    {
        public static bool isImage(this HttpPostedFileBase file)
        {
            return file.ContentType == "image/jpg" ||
                file.ContentType == "image/jpeg" ||
                file.ContentType == "image/png" ||
                file.ContentType == "image/gif";
        }
        public static string Save(this HttpPostedFileBase image,string subfolder)
        {
            string newFileName = subfolder + "/" + Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);

            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), newFileName);

            WebImage photo = new WebImage(image.InputStream);
            photo.Resize(800, 400, true);
            photo.Save(fullPath);

            return newFileName;
        }
    }
}