using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhenixProject.Data;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _webHost;
        private readonly IMimeMappingService _mimeMappingService;
        public DocumentController(IDocumentService service, IMapper mapper, UserManager<AppUser> userManager, IHostingEnvironment webHost, IMimeMappingService mimeMappingService)
        {
            _documentService = service;
            _mapper = mapper;
            _webHost = webHost;
            _userManager = userManager;
            _mimeMappingService = mimeMappingService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<DocumentViewModel> models;
            try
            {
                models = (await _documentService.GetDocumentsAsync());
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromForm]UploadFileViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                ModelState.AddModelError(string.Empty, "Current user not found.");
                return RedirectToAction("Index", "Home");
            }
            if (model.File != null)
            {

                var path = "/Documents/" + currentUser.Id + model.File.FileName;

                using (var fileStream = new FileStream(_webHost.WebRootPath + path, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                    var document = new DocumentViewModel
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Description = model.Description,
                        Path = path,
                        UploadTime = DateTime.Now,
                        OriginalName = model.File.FileName,
                        UserId = currentUser.Id
                    };
                    await _documentService.AddDocumentAsync(document);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error uploading document");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> UploadDocumentModal()
        {
            return PartialView("UploadDocumentModal");
        }

        [HttpGet]
        public async Task<ActionResult> DownloadDocument(Guid id)
        {
            var file = await _documentService.GetDocumentByIdAsync(id);
            if (file.Path != null)
            {
                var mimeType = _mimeMappingService.Map(file.Path);
                return PhysicalFile(_webHost.WebRootPath + file.Path, mimeType, file.OriginalName);
            }
            else
            {
                ModelState.AddModelError(string.Empty,"Path not found");
                return View("Index");
            }
        }
    }
}