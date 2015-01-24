using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sitecore.Security.Accounts;

namespace Hackathon.Profile
{
    /// <summary>
    /// Achievement Manager handles saving and retrieving of User based achievements.  
    /// </summary>
    public class AchievementManager
    {
        private User _user;

        public AchievementManager(User user)
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

        public void SetCustomAchievement(string achievementGuid)
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

            _achievements = JsonConvert.SerializeObject(achievements);
        }


    }
}