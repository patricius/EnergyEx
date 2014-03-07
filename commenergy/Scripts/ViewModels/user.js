
$(function () {
    DisplayVM.loadArticle();
    ko.applyBindings(DisplayVM, document.getElementById("d"));


});
var DisplayVM = {
    Article: ko.observableArray([]),

    loadArticle: function () {
        var self = this;

        $.ajax({

            url: "/Articles/UserInfo",
            contentType: "application/json; charset=utf-8",

            dataType: "json",
            success: function (data) {
                self.Article(data);
            },

            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    }
};





function Article(data) {
    Article.Title = ko.observable(data.Title);
    Article.Body = ko.observable(data.Body);
    Article.Key = ko.observable(data.Key);
    Article.Comments = ko.observableArray(data.Comments);
}




//$(document).ready(function () {
//    UserVM.loadArticles();
//    ko.applyBindings(UserVM, document.getElementById("m"));


//});

//var UserVM = {
//    Article: ko.observableArray([]),
       

//    loadArticles: function () {
//        var self = this;

//        $.ajax({
//            url: "/Articles/UserInfo",
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            success: function (data) {
//                self.Article(data.Article);
//            },
//            error: function (err) {
//                alert(err.status + " : " + err.statusText);
//            }
//        });
//    }
//};

//function Article(data) {
//    Article.Title = ko.observable(data.Title);
//    Article.Body = ko.observable(data.Body);
//    Article.Author = ko.observable(data.Author);
//    Article.Key = ko.observable(data.Key);
//}