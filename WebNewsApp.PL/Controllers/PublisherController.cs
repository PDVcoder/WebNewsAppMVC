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
    public class PublisherController : Controller
    {
        private readonly INewsPublishService _newsPublishService;
        public PublisherController(INewsPublishService newsPublishService)
        {
            _newsPublishService = newsPublishService;
        }
        [HttpGet]
        public IActionResult PublishPage(int id)
        {
            var user = _newsPublishService.GetAuthor(id);
            AuthorViewModel authorViewModel = new AuthorViewModel
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Mobile = user.Mobile,
                RegistrationDate = user.RegistrationDate,
                Username = user.Username
            };

            var mapper = new MapperConfiguration(conf => conf.CreateMap<HeadingDTO, HeadingViewModel>()).CreateMapper();
            IEnumerable<HeadingViewModel> headings = mapper.Map<IEnumerable<HeadingDTO>, IEnumerable<HeadingViewModel>>(_newsPublishService.GetHeadings());
            return View("PublishPage", new PublishViewModel 
            { 
                AuthorModel = authorViewModel, 
                NewsModel = null, 
                HeadingListModel = headings 
            });
        }

        [HttpPost]
        public IActionResult PublishNews(PublishViewModel model)
        {
            string result = string.Empty;
            try
            {
                NewsDTO newsDTO = new NewsDTO
                {
                    NewsName = model.NewsModel.NewsName,
                    NewsText = model.NewsModel.NewsText,
                    HeadingId = model.NewsModel.HeadingId,
                    AuthorId = model.AuthorModel.Id,
                    Topyc = model.NewsModel.Topyc
                };
                _newsPublishService.PublishNews(newsDTO);
                result = "News Was publish successful";
            } 
            catch(ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            ViewBag.Result = result;
            return Ok(result);
        }
    }
}
