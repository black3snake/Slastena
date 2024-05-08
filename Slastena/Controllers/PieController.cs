﻿using Microsoft.AspNetCore.Mvc;
using Slastena.Models;
using Slastena.ViewModels;

namespace Slastena.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        
        public IActionResult List() 
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            //return View(_pieRepository.AllPies);

            PieListViewModel pieListViewModel = new PieListViewModel( _pieRepository.AllPies, "Cheese cakes");
            return View(pieListViewModel);

        }

        public IActionResult Details(int id) 
        { 
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }

}