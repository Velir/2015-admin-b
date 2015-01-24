define(["sitecore"], function (Sitecore) {
  var model = Sitecore.Definitions.Models.ControlModel.extend({
    initialize: function (options) {
    	this._super();
	    this.set("output", "");
    	$.ajax({
    		url: "/api/sitecore/achievement/getachievements",
    		type: "GET",
    		context: this,
    		success: function (data) {
    			this.set("output", data);
    		}
    	});
    }
  });

  var view = Sitecore.Definitions.Views.ControlView.extend({
    initialize: function (options) {
    	this._super();
	    

    }
  });

  Sitecore.Factories.createComponent("AchievementDashboard", model, view, ".sc-AchievementDashboard");
});
