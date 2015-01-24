using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon.Models;
using Hackathon.Profile;
using Microsoft.Ajax.Utilities;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;

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
            AchievementProfile achievementProfile = new AchievementProfile(Sitecore.Context.User);

            if (submit == "ShowAchievements")
            {
                List<string> achievements = achievementProfile.Achievements;
                scratch.OutputOne = achievements;
                scratch.OutputTwo = Sitecore.Context.User.Profile.GetCustomProperty("achievements");
            }

            if (submit == "ClearAchievements")
            {
                achievementProfile.ClearAchievements();
            }

            if (submit == "AddCreateFirstABTestAchievement")
            {
                achievementProfile.ActivateFirstABTestAchievement();
            }

            if (submit == "AddCreateFirstPersonalizationRuleAchievement")
            {
                achievementProfile.ActivateFirstPersonalizationRuleAchievement();
            }

            if (submit == "AddProfileFirstContentItemAchievement")
            {
                achievementProfile.ActivateProfileFirstContentItemAchievement();
            }

            return View(scratch);
        }
    }
}