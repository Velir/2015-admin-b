using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;

namespace Hackathon.sitecore.shell.client.YourApps.hackathon2015_admin_b
{
	public class AchievementController:Controller
	{
		public JsonResult GetAchievements()
		{
			Database db = Sitecore.Data.Database.GetDatabase("master");
			Item item = db.GetItem("{F9810B88-B838-4AE9-BA5B-9E3CB151F05B}");
			return Json(new List<Achievement> { new Achievement { Name = item.GetField("Title"), Image = ThemeManager.GetImage(item.GetField("Icon"), 32,32) }, new Achievement { Name = "blah2", Image = "http://placekitten.com/g/200/300" } }, JsonRequestBehavior.AllowGet);
		}
	}

	public class Achievement
	{
		public string Name { get; set; }
		public string Image { get; set; }
	
	}
}