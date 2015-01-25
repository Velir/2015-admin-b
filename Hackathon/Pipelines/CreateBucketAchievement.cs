using AchievementTracker.AchievementTracker;

using Sitecore.Buckets.Pipelines.BucketOperations.CreateBucket;
using Sitecore.Buckets.Pipelines.UI;

namespace AchievementTracker.Pipelines
{
    public class CreateBucketAchievement
    {
        public void Process(BucketArgs args)
        {
            AchievementManager achievementManager = new AchievementManager(Sitecore.Context.User);
            achievementManager.SetCustomAchievement(AchievementTrackerIDs.CreateFirstBucket);
            Sitecore.Diagnostics.Log.Info("Create Bucket Achievement unlocked!!", this);
        }
    }
}