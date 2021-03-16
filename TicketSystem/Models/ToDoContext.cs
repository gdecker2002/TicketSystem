using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Models
{
	public class ToDoContext : DbContext
	{
		public ToDoContext(DbContextOptions<ToDoContext> options)
			: base(options) { }
		public DbSet<ToDo> ToDos { get; set; }
		public DbSet<SprintNum> SprintNums { get; set; }
		public DbSet<Point> Points { get; set; }
		public DbSet<Status> Statuses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SprintNum>().HasData(
				new SprintNum { SprintNumId = "a", Name = "0" },
				new SprintNum { SprintNumId = "b", Name = "1" },
				new SprintNum { SprintNumId = "c", Name = "2" },
				new SprintNum { SprintNumId = "d", Name = "3" },
				new SprintNum { SprintNumId = "e", Name = "4" },
				new SprintNum { SprintNumId = "f", Name = "5" },
				new SprintNum { SprintNumId = "g", Name = "6" },
				new SprintNum { SprintNumId = "h", Name = "7" },
				new SprintNum { SprintNumId = "i", Name = "8" },
				new SprintNum { SprintNumId = "j", Name = "9" },
				new SprintNum { SprintNumId = "k", Name = "10" },
				new SprintNum { SprintNumId = "l", Name = "11" },
				new SprintNum { SprintNumId = "m", Name = "12" },
				new SprintNum { SprintNumId = "n", Name = "13" },
				new SprintNum { SprintNumId = "o", Name = "14" },
				new SprintNum { SprintNumId = "p", Name = "15" },
				new SprintNum { SprintNumId = "q", Name = "16" },
				new SprintNum { SprintNumId = "r", Name = "17" },
				new SprintNum { SprintNumId = "s", Name = "18" },
				new SprintNum { SprintNumId = "t", Name = "19" },
				new SprintNum { SprintNumId = "u", Name = "20" }
			);
			modelBuilder.Entity<Point>().HasData(
				new Point { PointId = "a", Name = "1" },
				new Point { PointId = "b", Name = "2" },
				new Point { PointId = "c", Name = "3" },
				new Point { PointId = "d", Name = "4" },
				new Point { PointId = "e", Name = "5" },
				new Point { PointId = "f", Name = "6" },
				new Point { PointId = "g", Name = "7" },
				new Point { PointId = "h", Name = "8" },
				new Point { PointId = "i", Name = "9" },
				new Point { PointId = "j", Name = "10" },
				new Point { PointId = "k", Name = "11" },
				new Point { PointId = "l", Name = "12" },
				new Point { PointId = "m", Name = "13" },
				new Point { PointId = "n", Name = "14" },
				new Point { PointId = "o", Name = "15" },
				new Point { PointId = "p", Name = "16" },
				new Point { PointId = "q", Name = "17" },
				new Point { PointId = "r", Name = "18" },
				new Point { PointId = "s", Name = "19" },
				new Point { PointId = "t", Name = "20" }
			);
			modelBuilder.Entity<Status>().HasData(
				new Status { StatusId = "todo", Name = "To Do" },
				new Status { StatusId = "inprog", Name = "In Progress" },
				new Status { StatusId = "qa", Name = "Quality Assurance" },
				new Status { StatusId = "closed", Name = "Done" }
			);
		}
	}
}
