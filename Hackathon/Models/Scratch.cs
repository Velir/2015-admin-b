using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Hackathon.Models
{
    public class Scratch : RenderingModel
    {
        public List<String> OutputOne { get; set; }
        public string OutputTwo { get; set; }
    }
}