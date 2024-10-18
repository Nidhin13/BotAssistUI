using BotAssistUI.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BotAssistUI.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly UserService _userService;
		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
			_userService = new UserService();

		}
		public string DataPoints { get; private set; }
		public int TotalUsers { get; private set; }
		public int ActiveUsers { get; private set; }

		public void OnGet()
		{
			DataPoints = GetDataPoints();
			TotalUsers = _userService.GetTotalUsers();
			ActiveUsers = _userService.GetActiveUsers();
		}
		public string GetDataPoints()
		{
			List<DataPoint> dataPoints = new List<DataPoint>
			{
				new DataPoint("NXP", 14),
				new DataPoint("Infineon", 10),
				new DataPoint("Renesas", 9),
				new DataPoint("STMicroelectronics", 8),
				new DataPoint("Texas Instruments", 7),
				new DataPoint("Bosch", 5),
				new DataPoint("ON Semiconductor", 4),
				new DataPoint("Toshiba", 3),
				new DataPoint("Micron", 3),
				new DataPoint("Osram", 2),
				new DataPoint("Others", 35)
			};

			return JsonConvert.SerializeObject(dataPoints);
		}
	}
}
