using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Data;
using Assessment.Models;
using Assessment.Models.CaseViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class CaseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CaseController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles = "Admin,Worker,Reviewer,Approver")]
        public IActionResult Index()
        {
            var model = new CaseListViewModel();
            model.NeedReview = _context.Cases.Where(c => c.Reviewer == null).ToList();
            model.NeedApproval = _context.Cases.Where(c => c.Reviewer != null && c.Approver == null).ToList();
            model.Completed = _context.Cases.Where(c => c.Approver != null).ToList();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Worker")]
        public IActionResult AddCase()
        {
            var model = new Case();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> AddCase(Case model)
        {
            var user = await _userManager.GetUserAsync(User);

            var newCase = new Case
            {
                Message = model.Message,
                Worker = user
            };

            _context.Add(newCase);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Reviewer")]
        public async Task<IActionResult> ReviewCase([FromQuery] int caseId)
        {
            var user = await _userManager.GetUserAsync(User);

            var caseToReview = _context.Cases.First(c => c.CaseId == caseId);
            caseToReview.Reviewer = user;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Approver")]
        public async Task<IActionResult> ApproveCase([FromQuery] int caseId)
        {
            var user = await _userManager.GetUserAsync(User);

            var caseToReview = _context.Cases.First(c => c.CaseId == caseId);
            caseToReview.Approver = user;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}