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
		private ToDoContext context;
		public HomeController(ToDoContext ctx) => context = ctx;
		public IActionResult Index(string id)
		{
			var filters = new Filters(id);
			ViewBag.Filters = filters;
			ViewBag.SprintNums = context.SprintNums.ToList();
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
			ViewBag.SprintNums = context.SprintNums.ToList();
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
				ViewBag.SprintNums = context.SprintNums.ToList();
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
