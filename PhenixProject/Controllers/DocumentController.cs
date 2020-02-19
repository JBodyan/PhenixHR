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
using X.PagedList;

namespace PhenixProject.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private const int PageSize = 3;
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
        public async Task<IActionResult> Index(string searchString,int? page)
        {
            IEnumerable<DocumentViewModel> models;
            try
            {
                models = (await _documentService.GetDocumentsAsync()).Where(x=>!x.IsArchived);
                ViewBag.CurrentUserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
                if (!string.IsNullOrEmpty(searchString))
                {
                    
                    searchString = searchString.ToUpper();
                    models = models.Where(
                        x => x.Name.ToUpper().Contains(searchString)
                             || x.Description.ToUpper().Contains(searchString)
                             || x.ToString().ToUpper().Contains(searchString)
                    );
                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            var pageNumber = (page ?? 1);
            return View(await models.ToPagedListAsync(pageNumber, PageSize));
        }

        [HttpPost]
        public async Task<ActionResult> DocumentSearch(string searchString, int? page)
        {
            var models = (await _documentService.GetDocumentsAsync()).Where(x => !x.IsArchived);
            ViewBag.CurrentUserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            if (!string.IsNullOrEmpty(searchString))
            {

                searchString = searchString.ToUpper();
                models = models.Where(
                    x => x.Name.ToUpper().Contains(searchString)
                         || x.Description.ToUpper().Contains(searchString)
                         || x.ToString().ToUpper().Contains(searchString)
                );

            }

            var pageNumber = (page ?? 1);
            return PartialView("_DocumentSearchPartial", await models.ToPagedListAsync(pageNumber, PageSize));
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

        [HttpGet]
        public async Task<ActionResult> AddTagModal(Guid id)
        {
            ViewBag.DocumentId = id;
            if (id != Guid.Empty)
                return PartialView("AddTagModal");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AddTag(DocumentTagViewModel model)
        {
            try
            {
                await _documentService.AddTagAsync(model.DocumentId, model);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty,exception.Message);
                return View("Index");
            }
            
            return RedirectToAction("EditDocument",new{id = model.DocumentId});
        }

        [HttpGet]
        public async Task<ActionResult> EditTagModal(Guid documentId, Guid tagId)
        {
            var tag = await _documentService.GetTagByIdAsync(tagId);
            ViewBag.DocumentId = documentId;
            if (tag != null)
                return PartialView("EditTagModal",tag);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> EditDocument(Guid id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            if (document != null)
                return View(document);

            ModelState.AddModelError(string.Empty,"Document not found");
            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditDocument(DocumentViewModel model)
        {
            try
            {
                await _documentService.UpdateDocumentAsync(model);
                return RedirectToAction("EditDocument",new{id = model.Id});
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditTag(DocumentTagViewModel model)
        {
            var documentId = model.DocumentId;
            try
            {
                await _documentService.UpdateTagAsync(model);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View("Index");
            }

            return RedirectToAction("EditDocument",new{id = documentId});
        }

        [HttpPost]
        public async Task<ActionResult> RemoveTag(DocumentTagViewModel model)
        {
            var documentId = model.DocumentId;
            try
            {
                await _documentService.RemoveTagAsync(model.Id);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View("Index");
            }

            return RedirectToAction("EditDocument", new { id = documentId });
        }

        [HttpPost]
        public async Task<ActionResult> RemoveDocument(DocumentViewModel model)
        {
            try
            {
                await _documentService.RemoveDocumentAsync(model.Id);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View("Index");
            }

            return RedirectToAction("Index");
        }
    }
}