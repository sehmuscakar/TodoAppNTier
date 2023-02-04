using AutoMapper;
using Business.İnterfaces;
using Common.ResponseObjects;
using Dtos.WorkDtos;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers
{//wwwroot a bişet eklemek iisitiyrsan clinet cide library dan bootstrapı yukleyebilirsin
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;
        //private readonly IMapper _mapper; // IDto yu yaptığımız için buna gerek klamadı

		public HomeController(IWorkService workService /*IMapper mapper*/)
		{
			_workService = workService;
			//_mapper = mapper;
		}

		public async Task<IActionResult> Index()
        {
           var response= await _workService.GetAll();
			return View(response.Data);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {   
			var response =await _workService.Create(dto);
            return this.ResponseRedirectToAction(response, "Index");// burda biz extensionsta controllerı genişletik asıl kodlar orda 
           
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return this.ResponseView(response);
          
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            var response = await _workService.Update(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
           var response= await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
		}

        public IActionResult NotFound(int code)//hata sayfası 
        {
            return View();
        }
    }
}
