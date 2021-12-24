using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.BLL.DTO;
using NewsWebApp.BLL.Infrastructure;
using NewsWebApp.BLL.Interfaces;
using NewsWebApp.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.PL.Controllers
{
    public class HomeController : Controller
    {
        private INewsManagerService _newsManagerService;
        public HomeController(INewsManagerService newsManagerService)
        {
            _newsManagerService = newsManagerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<NewsDTO> newsDTOs = _newsManagerService.GetNews();
            var mapper = new MapperConfiguration(config => config.CreateMap<NewsDTO, NewsViewModel>()).CreateMapper();
            var news = mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(newsDTOs);

            var mapper1 = new MapperConfiguration(conf => conf.CreateMap<HeadingDTO, HeadingViewModel>()).CreateMapper();
            IEnumerable<HeadingViewModel> headings = mapper1.Map<IEnumerable<HeadingDTO>, IEnumerable<HeadingViewModel>>(_newsManagerService.GetHeading());
            return View(new ViewPage { News = news, Headings = headings});
        }

        public IActionResult SearchName(ViewPage viewPage)
        {
            IEnumerable<NewsDTO> newsDTOs = _newsManagerService.GetNewsByName(viewPage.Filter.Name);
            var mapper = new MapperConfiguration(config => config.CreateMap<NewsDTO, NewsViewModel>()).CreateMapper();
            var news = mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(newsDTOs);
            return View("Index", new ViewPage { News = news, Headings = viewPage.Headings });
        }

        public IActionResult SearchTopyc(ViewPage viewPage)
        {
            IEnumerable<NewsDTO> newsDTOs = _newsManagerService.GetNewsByTopic(viewPage.Filter.Topyc);
            var mapper = new MapperConfiguration(config => config.CreateMap<NewsDTO, NewsViewModel>()).CreateMapper();
            var news = mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(newsDTOs);
            return View("Index", new ViewPage { News = news, Headings = viewPage.Headings });
        }

        public IActionResult SearchHeading(ViewPage viewPage)
        {
            IEnumerable<NewsDTO> newsDTOs = _newsManagerService.GetNewsByHeading(viewPage.Filter.HeadingId);
            var mapper = new MapperConfiguration(config => config.CreateMap<NewsDTO, NewsViewModel>()).CreateMapper();
            var news = mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(newsDTOs);
            return View("Index", new ViewPage { News = news, Headings = viewPage.Headings });
        }
        

      [HttpGet]
        public IActionResult ViewNews(NewsViewModel newsViewModel)
        {
            try
            {
                AuthorDTO authorDTO = _newsManagerService.GetAuthor(newsViewModel.AuthorId);
                newsViewModel.Author = new AuthorViewModel
                {
                    Id = authorDTO.Id,
                    Username = authorDTO.Username,
                    Firstname = authorDTO.Firstname,
                    Lastname = authorDTO.Lastname,
                    RegistrationDate = authorDTO.RegistrationDate,
                    Email = authorDTO.Email,
                    Status = "OK"
                };
            }
            catch(Exception e)
            {
                throw new ValidationException("Author was not found!", e.Message); 
            }

            try
            {
                HeadingDTO headingDTO = _newsManagerService.GetHeading(newsViewModel.HeadingId);
                newsViewModel.Heading = new HeadingViewModel
                {
                    Id = headingDTO.Id,
                    Name = headingDTO.Name
                };
            }
            catch(Exception e)
            {
                throw new ValidationException("Heading was not found!", e.Message);
            }
            return View(newsViewModel);
        }

        [HttpGet]
        public RedirectResult Autorisation()
        {
            return Redirect("/Autorisation/Autorisation");
        }

        protected override void Dispose(bool disposing)
        {
            _newsManagerService.Dispose();
            base.Dispose(disposing);
        }
    }
}
