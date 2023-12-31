﻿using DependencyInjectionPlay.Models;
using DependencyInjectionPlay.Services;
using DependencyInjectionPlay.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionPlay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService _blogService;

        public HomeController(ILogger<HomeController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var posts = _blogService.GetAllPosts();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details(int id)
        {
            var post = _blogService.GetPost(id);

            return View(post);
        }
    }
}