using AchievementTracker.AchievementTracker;
using Sitecore.ContentTesting.Pipelines.StartTest;

namespace AchievementTracker.Pipelines
{
    public class StartTestAchievement : StartTestProcessor
    {
        public override void Process(StartTestArgs args)
        {
            if (args.Test == null)
                return;

            AchievementManager achievementManager = new AchievementManager(Sitecore.Context.User);
            achievementManager.SetCustomAchievement(AchievementTrackerIDs.FirstAbTestAchievementId);
            Sitecore.Diagnostics.Log.Info("StartTestAchievement earned", this);
            
            
            


        }
    }
}