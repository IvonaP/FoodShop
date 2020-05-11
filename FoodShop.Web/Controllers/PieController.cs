using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodShop.Web.Models;
using FoodShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Web.Controllers
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

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.GetAllPies.OrderBy(p => p.PieId);

                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.GetAllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);

                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View( new PiesListViewModel
                {
                   Pies = pies,
                   CurrentCategory = category
                   
                });
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if(pie == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}