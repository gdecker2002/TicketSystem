using System;
using Xunit;
using Moq;
using TicketSystem.Models;
using TicketSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace TicketUnitTest
{
    public class UnitTest1
    {
		[Fact]
		public void IndexRedirect()
		{
			var temp = new Mock<ITempDataDictionary>();
			controller.TempData = temp.Object;
			var unit = new Mock<ToDo>();
			var controller = new HomeController();
			ToDo tk = new ToDo { ToDo.Id = new ToDo.Id() };

			Assert.IsType<RedirectToActionResult>(result);
		}
	}
}
