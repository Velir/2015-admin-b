﻿define(["sitecore"], function (Sitecore) {
  var AchievementPageCode = Sitecore.Definitions.App.extend({
  	updateListing:function() {

  		var app = this;
  		var method;
  		if (app.ToggleButton1.attributes.isOpen) {
  			method = "getachievements";
  			app.ToggleButton1.attributes.Text = "All achievements";
  		} else {
  			method = "getmyachievements";
  			app.ToggleButton1.attributes.Text = "My achievements";
  		}

  		app.AchievementDashboard1.refresh(method);
  	}
  });

  return AchievementPageCode;
});