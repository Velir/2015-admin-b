using System.Linq;

using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.Save;

namespace Hackathon.Pipelines
{
    public class SaveItemAchievements
    {
        private const string _conditionTag = "<condition ";

        public void Process(SaveArgs args)
        {
            foreach (var item in args.Items)
            {
                Item oldItem = Sitecore.Client.ContentDatabase.GetItem(item.ID);
                if (oldItem == null) continue;
                 
                string oldLayout = oldItem[FieldIDs.LayoutField];
                string oldFinalRendering = oldItem[FieldIDs.FinalLayoutField];
                 
                 
                SaveArgs.SaveField newLayout = item.Fields.FirstOrDefault(field => field.ID == FieldIDs.LayoutField);
                SaveArgs.SaveField newFinal = item.Fields.FirstOrDefault(field => field.ID == FieldIDs.FinalLayoutField);
                 
                if (!oldLayout.Contains(_conditionTag) && !oldFinalRendering.Contains(_conditionTag) &&
                    (HasConditionTag(newLayout) || HasConditionTag(newFinal)))
                {
                    Sitecore.Diagnostics.Log.Info("Personalizaton rule added", this);  //TODO Fire achievement instead.
                }
            }
           
        }

        private static bool HasConditionTag(SaveArgs.SaveField savedField)
        {
            return savedField != null && savedField.Value.Contains(_conditionTag);
        }
    }
}