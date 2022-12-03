using LabsLibrary;
using dk_lab5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;

namespace dk_lab5.Controllers
{
	[Authorize]
	public class LabsController : Controller
	{
		private readonly ILogger<LabsController> _logger;

		public LabsController(ILogger<LabsController> logger)
		{
			_logger = logger;
		}

		public IActionResult Lab1()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Lab1(Lab1DataModel model)
		{
			var labRunner = new Lab1Runner(model.InputNumber);

			try
			{
				model.Calculated = labRunner.RunLab();
			}
			catch (ArgumentException e)
			{
				model.ErrorValue = e.Message;
			}
			catch (Exception e)
			{
				model.ErrorValue = e.Message;
			}

			return View(model);
		}

		public IActionResult Lab2()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Lab2(Lab2DataModel model)
		{
			var labRunner = new Lab2Runner(model.FirstLine, model.SecondLine, model.ThirdLine);

			try
			{
				model.Calculated = labRunner.RunLab();
			}
			catch (ArgumentException e)
			{
				model.ErrorValue = e.Message;
			}
			catch (Exception e)
			{
				model.ErrorValue = e.Message;
			}

			return View(model);
		}

		public IActionResult Lab3()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Lab3(Lab3DataModel model)
		{
			var labRunner = new Lab3Runner(model.FirstLine, model.SecondLine, model.ThirdLine, model.StartElement, model.FinishElement);

			try
			{
				model.Calculated = labRunner.RunLab();
			}
			catch (ArgumentException e)
			{
				model.ErrorValue = e.Message;
			}
			catch (Exception e)
			{
				model.ErrorValue = e.Message;
			}

			return View(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}