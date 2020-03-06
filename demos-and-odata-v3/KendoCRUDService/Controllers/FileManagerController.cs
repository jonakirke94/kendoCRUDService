using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoCRUDService.Models;
using KendoCRUDService.Models.FileManager;

namespace KendoCRUDService.Controllers
{
    public class FileManagerController : Controller
    {
        private const string contentFolderRoot = "~/Content/";
        private const string prettyName = "Files/";
        private static readonly string[] foldersToCopy = new[] { "~/Content/filemanager/" };
        private const string DefaultFilter = "*.txt,*.doc,*.docx,*.xls,*.xlsx,*.ppt,*.pptx,*.zip,*.rar,*.jpg,*.jpeg,*.gif,*.png";

        public class FileManagerDto
        {
            public int? FolderId { get; set; }
            public string Name { get; set; }
            public long Size { get; set; }
            public string Path { get; set; }
            public string Extension { get; set; }
            public bool IsDirectory { get; set; }
            public bool HasDirectories { get; set; }
            public DateTime Created { get; set; }
            public DateTime CreatedUtc { get; set; }
            public DateTime Modified { get; set; }
            public DateTime ModifiedUtc { get; set; }
        }

        public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
                base.OnActionExecuting(filterContext);
            }
        }

        [AllowCrossSiteJsonAttribute]
        public virtual JsonResult Read(string target)
        {
            var items = new List<FileManagerDto>
            {
                new FileManagerDto()
                {
                    FolderId = 10,
                    Name = "Folder",
                    IsDirectory = true,
                    HasDirectories = false,
                    Path = "Folder",
                    Extension = "",
                    Size = 0,
                    CreatedUtc = new DateTime(),
                },

                new FileManagerDto()
                {
                    FolderId = 20,
                    Name = "Images",
                    IsDirectory = true,
                    HasDirectories = false,
                    Path = "Images",
                    Extension = "",
                    Size = 0,
                    CreatedUtc = new DateTime(),
                }
            };

            return Json(items);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [AllowCrossSiteJsonAttribute]
        public virtual ActionResult Create(string target, FileManagerEntry entry)
        {
            return Json(new
            {
                FolderId = 110,
                Name = "NewFolder",
                IsDirectory = true,
                HasDirectories = false,
                Path = "NewFolder",
                Extension = "",
                Size = 0,
                CreatedUtc = new DateTime(),
            });
        }
    }
}
