using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Controllers
{
	public class HomeController : Controller
	{
		public JsonResult CheckPoint(
			string pointid, [FromServices]Point point){
			validate.CheckPoint(pointid, point);
		}
		public JsonResult CheckSprint(
			string sprintnumid, [FromServices] SprintNum sprint)
		{
			validate.CheckPoint(sprintnumid, sprint);
		}
		public JsonResult CheckStatus(
			string statusid, [FromServices] Status status)
		{
			validate.CheckPoint(statusid, status);
		}
		private Point point { get; set; }
		private SprintNum sprint { get; set; }
		private Status status { get; set; }


		private ToDoContext context;
		public HomeController(ToDoContext ctx) => context = ctx;
		public IActionResult Index(string id)
		{
			
			var filters = new Filters(id);
			ViewBag.Filters = filters;
			ViewBag.SprintNum = context.SprintNum.ToList();
			ViewBag.Points = context.Points.ToList();
			ViewBag.Statuses = context.Statuses.ToList();

			IQueryable<ToDo> query = context.ToDos.Include(t => t.SprintNum).Include(t => t.Point).Include(t => t.Status);
			if (filters.HasSprint)
			{
				query = query.Where(t => t.SprintNumId == filters.SprintNumId);
			}
			if (filters.HasPoint)
			{
				query = query.Where(t => t.PointId == filters.PointId);
			}
			if (filters.HasStatus)
			{
				query = query.Where(t => t.StatusId == filters.StatusId);
			}
			var tasks = query.OrderBy(t => t.Status).ToList();
			return View(tasks);
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.SprintNum = context.SprintNum.ToList();
			ViewBag.Points = context.Points.ToList();
			ViewBag.Statuses = context.Statuses.ToList();

			return View();
		}

		[HttpPost]
		public IActionResult Add(ToDo task)
		{
			if (ModelState.IsValid)
			{
				context.ToDos.Add(task);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.SprintNums = context.SprintNum.ToList();
				ViewBag.Points = context.Points.ToList();
				ViewBag.Statuses = context.Statuses.ToList();
				return View(task);
			}
		}

		[HttpPost]
		public IActionResult Filter(string[] filter)
		{
			string id = string.Join('-', filter);
			return RedirectToAction("Index", new { ID = id });
		}

		[HttpPost]
		public IActionResult Edit([FromRoute] string id, ToDo selected)
		{
			if (selected.StatusId == null)
			{
				context.ToDos.Remove(selected);
			}
			else
			{
				string newStatusId = selected.StatusId;
				selected = context.ToDos.Find(selected.Id);
				selected.StatusId = newStatusId;
				context.ToDos.Update(selected);
			}
			context.SaveChanges();

			return RedirectToAction("Index", new { ID = id });
		}
	}
}
