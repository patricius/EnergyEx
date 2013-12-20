var display = {
    Title: ko.observable(),
    CreatedOn: ko.observable(),
    Email: ko.observable(),
    Id: ko.observable(),
    url: ko.observable(),
    URLTo: ko.observable(),
    Body: ko.observable(),
    Key: ko.observable(),
    Author: ko.observable(),
    IpAddress: ko.observable(),
    Comments: ko.observableArray([]),

    loadArticle: function () {
        var self = this;

        $.ajax({

            url: "/Displays/" ,
            contentType: "application/json; charset=utf-8",
          
            dataType: "json",
            success: function (data) {
                self.Article(data.Article);
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    }
};

$(function () {
    ko.applyBindings(display, document.getElementById("Display"));
    display.loadArticle();
});