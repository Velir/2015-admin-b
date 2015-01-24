using Sitecore.Buckets.Pipelines.BucketOperations.CreateBucket;

namespace AchievementTracker.Pipelines
{
    public class CreateBucketAchievement: CreateBucketProcessor
    {
        public override void Process(CreateBucketArgs args)
        {
            Sitecore.Diagnostics.Log.Info("Create Bucket Achievement unlocked!!", this);
        }
    }
}