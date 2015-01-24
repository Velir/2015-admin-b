using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hackathon.Profile;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Web;

namespace Hackathon.sitecore.shell.client.YourApps.hackathon2015_admin_b
{
	public class AchievementController:Controller
	{
		public JsonResult GetAchievements()
		{
			Database db = Sitecore.Data.Database.GetDatabase("master");
			var items = db.GetItems("{4233AB87-4CF3-46F2-9909-230510ECF4C6}").Where(i => i.TemplateID == new ID("{23AC8ACA-6407-4DF8-A548-53F62BB9ADDC}"));
			return Json(items.Select(item => new Achievement { Name = item.GetField("Title"), Image = ThemeManager.GetImage(item.GetField("Icon"), 32,32) }), JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetMyAchievements()
		{
			AchievementManager achievementManager = new AchievementManager(Sitecore.Context.User);
		    List<string> achievementsList = achievementManager.Achievements;
            if (achievementsList == null)
			{
				return null;
			}

			List<Achievement> achievements = new List<Achievement>();
            foreach (string achievementGuid in achievementsList)
			{
				Database db = Sitecore.Data.Database.GetDatabase("master");
				var item = db.GetItem(achievementGuid);
				achievements.Add(new Achievement { Name = item.GetField("Title"), Image = ThemeManager.GetImage(item.GetField("Icon"), 32, 32) });
			}
			return Json(achievements, JsonRequestBehavior.AllowGet);
		}
	}

	public class Achievement
	{
		public string Name { get; set; }
		public string Image { get; set; }
	
	}
}