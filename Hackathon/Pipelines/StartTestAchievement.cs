using Sitecore.ContentTesting.Pipelines.StartTest;

namespace AchievementTracker.Pipelines
{
    public class StartTestAchievement : StartTestProcessor
    {
        public override void Process(StartTestArgs args)
        {
            if (args.Test == null)
                return;
            Sitecore.Diagnostics.Log.Info("StartTestAchievement earned", this);
            var comment = Sitecore.Context.User.Profile.Comment;
            //var profile = new Hackathon.Profile.AchievementProfile();
            //profile.Achievement += "{798F4733-43BD-4B4A-B741-1098F9A05603}";
            comment += "Test started 2.";
            


        }
    }
}