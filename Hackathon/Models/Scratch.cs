using System;
using System.Collections.Generic;

using Sitecore.Mvc.Presentation;

namespace AchievementTracker.Models
{
    public class Scratch : RenderingModel
    {
        public List<String> OutputOne { get; set; }
        public string OutputTwo { get; set; }
    }
}