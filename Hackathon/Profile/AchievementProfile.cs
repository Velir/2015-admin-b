using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Sitecore.Mvc.Controllers;

namespace Hackathon.Profile
{
    public class AchievementProfile
    {
        private Sitecore.Security.Accounts.User _user;

        public AchievementProfile(Sitecore.Security.Accounts.User user)
        {
            _user = user;
        }

        private string _achievements
        {
            get
            {
                return _user.Profile.GetCustomProperty("achievements");
            }
            set
            {
                _user.Profile.SetCustomProperty("achievements", value);
                _user.Profile.Save();
            }
        }

        public List<string> Achievements
        {
            get
            {
                List<string> returnList = new List<string>();
                string propertyValues = _achievements;
                if (String.IsNullOrEmpty(propertyValues))
                {
                    return returnList;
                }

                return JsonConvert.DeserializeObject<List<String>>(propertyValues);
            }
        }

        

        public void ClearAchievements()
        {
            _achievements = string.Empty;
        }

        public void ActivateFirstABTestAchievement()
        {
            const string createFirstAbTestGuid = "{F9810B88-B838-4AE9-BA5B-9E3CB151F05B}";
            _achievements = SetCustomAchievement(createFirstAbTestGuid);
        }

        public void ActivateFirstPersonalizationRuleAchievement()
        {
            const string createFirstPersonalizationRuleGuid = "{6C3DC925-CD85-4A9D-A6B6-AE4259537A62}";
            _achievements = SetCustomAchievement(createFirstPersonalizationRuleGuid);
        }

        public void ActivateProfileFirstContentItemAchievement()
        {
            const string profileFirstContentItemGuid = "{C247CC31-0079-45A6-9BF0-6FDA6BE1F4C2}";
            _achievements = SetCustomAchievement(profileFirstContentItemGuid);
        }

        private string SetCustomAchievement(string achievementGuid)
        {
            string propertyValues = _achievements;

            List<String> achievements = JsonConvert.DeserializeObject<List<String>>(propertyValues);

            if (achievements == null)
            {
                achievements = new List<string>();
            }

            if (!achievements.Contains(achievementGuid))
            {
                achievements.Add(achievementGuid);
            }

            return JsonConvert.SerializeObject(achievements);
        }


    }
}