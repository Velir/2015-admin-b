using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Profile
{
    public class AchievementProfile : Sitecore.Security.UserProfile
    {
        private static string CreateFirstTestGuid = "{F9810B88-B838-4AE9-BA5B-9E3CB151F05B}";
        private static string delimiter = "|";

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

        public string CreateFirstTestAchievement
        {
            set
            {
                string propertyValues = Achievement;
                if (String.IsNullOrEmpty(propertyValues))
                {
                    return;
                }

                List<string> propertyValueList = propertyValues.Split('|').ToList();
                if (!propertyValues.Contains(CreateFirstTestGuid))
                {
                    propertyValueList.Add(CreateFirstTestGuid);
                }
                propertyValues = String.Join(delimiter, propertyValues);
                Achievement = propertyValues;
                Save();
            }
        }

	    public List<string> Achievements
	    {
		    get
			{
				string propertyValues = Achievement;
				if (propertyValues == null)
				{
					return new List<string>();
				}

				return  propertyValues.Split('|').ToList();
		    }
	    }

    }
}