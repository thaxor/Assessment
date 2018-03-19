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
using Microsoft.EntityFrameworkCore;

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

        [Authorize(Roles = "Worker,Reviewer,Approver")]
        public IActionResult Index()
        {
            var caseQuery = _context.Cases.Include(c => c.Comments).Include(c => c.Worker);

            var model = new CaseListViewModel();
            model.NeedReview = caseQuery.Where(c => c.Reviewer == null).ToList();
            model.NeedApproval = caseQuery.Where(c => c.Reviewer != null && c.Approver == null).ToList();
            model.Completed = caseQuery.Where(c => c.Approver != null).ToList();

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

        [HttpPost]
        [Authorize(Roles = "Worker,Reviewer,Approver")]
        public IActionResult AddComment(AddCommentViewModel model)
        {
            var caseData = _context.Cases.First(c => c.CaseId == model.CaseId);

            var comment = new Comment();
            comment.CommentText = model.Comment;
            comment.Case = caseData;
            _context.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}