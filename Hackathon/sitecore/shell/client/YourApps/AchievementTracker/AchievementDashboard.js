define(["sitecore"], function (Sitecore) {
	var model = Sitecore.Definitions.Models.ControlModel.extend({
		refresh: function (method) {
			$.ajax({
				url: "/api/sitecore/achievement/" + method,
				type: "GET",
				context: this,
				success: function (data) {
					this.set("output", data);
				}
			});
		},
		initialize: function (options) {
			this._super();
			this.set("input", "");
			this.set("output", "");
			this.refresh("getmyachievements");
		}
	});

	var view = Sitecore.Definitions.Views.ControlView.extend({
		initialize: function (options) {
			this._super();


		}
	});

	Sitecore.Factories.createComponent("AchievementDashboard", model, view, ".sc-AchievementDashboard");
});
