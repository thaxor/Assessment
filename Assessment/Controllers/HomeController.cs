using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assessment.Models;
using Assessment.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            IEnumerable<UserCaseLoad> result;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                result = connection.Query<UserCaseLoad>("spUserCaseLoadReport", new { }, commandType: System.Data.CommandType.StoredProcedure);
            };

            return View(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
