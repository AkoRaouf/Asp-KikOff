using ASP.NET.Core.WebApp.Data;
using ASP.NET.Core.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASP.NET.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(int id) => View(repository[id] ?? repository.People.First());

        public ViewResult Create() => View(new Person());
        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);
        public ViewResult DisplaySummary(AddressSummary summary) => View(summary);

    }
}
