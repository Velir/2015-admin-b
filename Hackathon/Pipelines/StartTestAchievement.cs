using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.ContentTesting.Pipelines.StartTest;

namespace Hackathon.Pipelines
{
    public class StartTestAchievement : StartTestProcessor
    {
        public override void Process(StartTestArgs args)
        {
            if (args.Test == null)
                return;
            var comment = Sitecore.Context.User.Profile.Comment;
            comment += "Test started.";
            Sitecore.Context.User.Profile.Comment = comment;
            Sitecore.Context.User.Profile.Save();
        }
    }
}