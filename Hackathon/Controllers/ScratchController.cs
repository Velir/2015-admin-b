using System.Collections.Generic;
using System.Web.Mvc;
using Hackathon.AchievementTracker;
using Hackathon.Models;
using Hackathon.Profile;
using Sitecore;

namespace Hackathon.Controllers
{
    public class ScratchController : Controller
    {
        // GET: Scratch
        public ActionResult Index()
        {
            Scratch scratch = new Scratch();
            return View(scratch);
        }

        [HttpPost]
        public ActionResult Index(string submit)
        {
            Scratch scratch = new Scratch();
            AchievementManager achievementManager = new AchievementManager(Context.User);

            if (submit == "ShowAchievements")
            {
                List<string> achievements = achievementManager.Achievements;
                scratch.OutputOne = achievements;
                scratch.OutputTwo = Context.User.Profile.GetCustomProperty("achievements");
            }

            if (submit == "ClearAchievements")
            {
                achievementManager.ClearAchievements();
            }

            if (submit == "AddCreateFirstABTestAchievement")
            {
                achievementManager.SetCustomAchievement(AchievementTrackerIDs.FirstAbTestAchievementId);
            }

            if (submit == "AddCreateFirstPersonalizationRuleAchievement")
            {
                achievementManager.SetCustomAchievement(AchievementTrackerIDs.FirstPersonalizationRuleAchievementId);
            }

            if (submit == "AddProfileFirstContentItemAchievement")
            {
                achievementManager.SetCustomAchievement(AchievementTrackerIDs.SetFirstProfileCardId);
            }

            return View(scratch);
        }
    }
}