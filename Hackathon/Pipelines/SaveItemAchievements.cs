using System.Linq;

using AchievementTracker.AchievementTracker;

using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.Save;

namespace AchievementTracker.Pipelines
{
    public class SaveItemAchievements
    {
        private const string _conditionTag = "<condition ";

        private static ID TrackingFieldId = new ID("{B0A67B2A-8B07-4E0B-8809-69F751709806}");

        public void Process(SaveArgs args)
        {
            foreach (var item in args.Items)
            {
                Item oldItem = Sitecore.Client.ContentDatabase.GetItem(item.ID);
                if (oldItem == null) continue;
                 
                RecordPersonalizationAchievement(oldItem, item);
                RecordSetFirstProfileCard(oldItem, item);
            }
           
        }

        private void RecordSetFirstProfileCard(Item oldItem, SaveArgs.SaveItem item)
        {
            string oldTracking = oldItem[TrackingFieldId];

            SaveArgs.SaveField newTracking = item.Fields.FirstOrDefault(field => field.ID == TrackingFieldId);


            if (string.IsNullOrEmpty(oldTracking) && newTracking != null && !string.IsNullOrEmpty(newTracking.Value))
            {
                AchievementManager achievementManager = new AchievementManager(Sitecore.Context.User);
                achievementManager.SetCustomAchievement(AchievementTrackerIDs.SetFirstProfileCardId);
                Sitecore.Diagnostics.Log.Info("Profile Card added.", this);
            }

        }

        private void RecordPersonalizationAchievement(Item oldItem, SaveArgs.SaveItem item)
        {
            string oldLayout = oldItem[FieldIDs.LayoutField];
            string oldFinalRendering = oldItem[FieldIDs.FinalLayoutField];

            SaveArgs.SaveField newLayout = item.Fields.FirstOrDefault(field => field.ID == FieldIDs.LayoutField);
            SaveArgs.SaveField newFinal = item.Fields.FirstOrDefault(field => field.ID == FieldIDs.FinalLayoutField);

            if (!oldLayout.Contains(_conditionTag) && !oldFinalRendering.Contains(_conditionTag)
                && (HasConditionTag(newLayout) || HasConditionTag(newFinal)))
            {
                AchievementManager achievementManager = new AchievementManager(Sitecore.Context.User);
                achievementManager.SetCustomAchievement(AchievementTrackerIDs.FirstPersonalizationRuleAchievementId);
                Sitecore.Diagnostics.Log.Info("Personalizaton rule added", this); //TODO Fire achievement instead.
            }
        }

        private static bool HasConditionTag(SaveArgs.SaveField savedField)
        {
            return savedField != null && savedField.Value.Contains(_conditionTag);
        }
    }
}