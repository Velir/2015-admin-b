# Sitecore Achievement Tracker
The Sitecore Achievement Tracker incorporates gamification into the Sitecore editor experience. Sitecore 8 offers a wide variety of new features for both Content Editors and Marketers and the Achievement Tracker incentivizes new and experienced Sitecore users to explore various aspects of the system. The tracker has been built in an extensible fashion, allowing module users to cater achievements to their specific needs.

## Sitecore Package
1. Install Sitecore package: **Achievement Tracker.zip**
2. No publishing is required, since all items are in core or master databases.

## Technical Details
Achievement data is currently stored as a custom user profile property in the ASP.NET Membership Database.

Achievements are triggered through Custom Pipeline handlers.  Any event that can inferred through the pipeline could is a candidate for an achievement.  

Logging of achievements is enabled.  

## Available Achievements
Currently, the following achievements are enabled:  
1. Create an A/B Test.  This is awarded when the test is started.
2. Create an item bucket.
3. Add a personalization rule. This is awarded when the personalization rule is installed.

## How to Add an Achievement
1. Add a pipeline processor to record the achievement.
2. Optional: Add a logging message to confirm the achievement fires as expected. This can be done by adding this line:
Sitecore.Diagnostics.Log.Info(“Achievement XXXX earned!”, this);
3. Create a content item in System/Modules/Achievement Tracker


## Future Improvements
1. Add on-screen notifications for achievements. Currently a user is required to go to the Achievements application on the dashboard.
2. Add a counting ability for achievements.  This way you can award users when they publish 50 tests, or tag 100 pieces of content with a user profile.  This would help to keep incentives relevant for experienced users over time.
3. Roll incentive data into an administrative report, given business owners insight into Sitecore utilization and staff expertise.  This could be used to provide analytics on feature use by individual staff and roles.  
4. Use as a training mechanism.  Achievements can provide a certification that certain tasks have been completed.  Design achievements so that a wide breath of features are explored and used.
5. Move persistence mechanism from ASP.NET membership to MongoDB to allow for richer gamification scenarios.
6. Enable achievements for non-pipeline related actions.

## Note: 
This module was created by team **admin/b** (Dan Solovay, Alex Jackson, Corey Caplette) as part of the 2015 Sitecore Hackathon. It was the winning entry in the "Best Business  User Experience Module" category.


