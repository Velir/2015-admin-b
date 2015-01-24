using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Profile
{
    public class AchievementProfile : Sitecore.Security.UserProfile
    {
        public string Achievement
        {
            get
            {
                return GetCustomProperty("achievement");
            }
            set
            {
                SetCustomProperty("achievement", value);
                Save();
            }
        }
    }
}