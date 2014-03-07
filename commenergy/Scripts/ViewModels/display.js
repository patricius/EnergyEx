$(function () {
    DisplayVM.loadArticle();
    ko.applyBindings(DisplayVM, document.getElementById("d"));


});
var DisplayVM = {
    Article: ko.observableArray([]),

    loadArticle: function () {
        var self = this;

        $.ajax({

            url: window.location.href+"/display",
            contentType: "application/json; charset=utf-8",
        
            dataType: "json",
            success: function (data) {
                self.Article(data);
            },
           
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    }};





function Article(data) {
    Article.Title = ko.observable(data.Title);
    Article.Body = ko.observable(data.Body);
    Article.Key = ko.observable(data.Key);
    Article.Comments = ko.observableArray(data.Comments);
}

//function Articles(Articles)  {
//    Articles: ko.observableArray([]),
//    Title: ko.observable(),
//    CreatedOn: ko.observable(),
//    Email: ko.observable(),
//    Id: ko.observable(),
//    url: ko.observable(),
//    URLTo: ko.observable(),
//    Body: ko.observable(),
//    Key: ko.observable(),
//    Author: ko.observable(),
//    IpAddress: ko.observable(),
//    Comments: ko.observableArray([]),
