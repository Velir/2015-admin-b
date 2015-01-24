using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Managers;

namespace AchievementTracker.AchievementTracker
{
	public class AchievementController:Controller
	{
		public JsonResult GetAchievements()
		{
			Database db = Sitecore.Data.Database.GetDatabase("master");
			var items = db.GetItems("{4233AB87-4CF3-46F2-9909-230510ECF4C6}").Where(i => i.TemplateID == new ID("{23AC8ACA-6407-4DF8-A548-53F62BB9ADDC}"));

			AchievementManager userProfile = new AchievementManager(Sitecore.Context.User);
				userProfile.SetCustomAchievement("{9F8DF07B-FCEC-4607-BE3F-4576F4C3A4CC}");
			return Json(items.Select(item => new Achievement { Name = item.GetField("Title"), Image = ThemeManager.GetImage(item.GetField("Icon"), 32, 32), Description = item.GetField("Description") }), JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetMyAchievements()
		{
			AchievementManager achievementManager = new AchievementManager(Sitecore.Context.User);
			return Json(GetAchievements(achievementManager), JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetUsers()
		{
			var users = Sitecore.Security.Accounts.UserManager.GetUsers();
			List<UserAchievements> userAchievements  = new List<UserAchievements>();
			foreach (var user in users)
			{
				userAchievements.Add(new UserAchievements { Name = user.Name, Achievements = GetAchievements(new AchievementManager(user)) });
			}
			return Json(userAchievements, JsonRequestBehavior.AllowGet);
		}

		private List<Achievement> GetAchievements(AchievementManager userProfile)
		{if (userProfile == null)
			{
				return null;
			}

			List<Achievement> achievements = new List<Achievement>();
            foreach (string achievementGuid in userProfile.Achievements)
			{
				Database db = Sitecore.Data.Database.GetDatabase("master");
				var item = db.GetItem(achievementGuid);
				achievements.Add(new Achievement { Name = item.GetField("Title"), Image = ThemeManager.GetImage(item.GetField("Icon"), 32, 32, "", "", item.GetField("Description"),"", true), Description = item.GetField("Description") });
			}
			return achievements;
		}
	}

	public class Achievement
	{
		public string Name { get; set; }
		public string Image { get; set; }
		public string Description { get; set; }
	
	}

	public class UserAchievements
	{
		public string Name { get; set; }
		public List<Achievement> Achievements { get; set; } 
	}
}