/// <reference path="bootstrap.min.js" />
var urlPath = window.location.href;


function index(data) {    
    this.Results = ko.observableArray([]);
    this.PageCount = ko.observable();
    this.CurrentPage =  ko.observable();
    this.PageSize = ko.observable(),
    this.RowCount =  ko.observable();
    this.URLTo = ko.observable();
    this.Title = ko.observable();
    this.Abstract = ko.observable();
    this.Body =  ko.observable();
    this.Key = ko.observable();
    this.UserId = ko.observable(),
    this.Comments = ko.observableArray([]);
}

var indexVM = new index(); 
    
var loadArticles = function() {
    var self = this;
 
    $.ajax({

        url: "Articles/ArticleLists/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data) {
            indexVM.Results(data.Results);
            indexVM.CurrentPage(data.CurrentPage);
        },

        error: function(err) {
            alert(err.status + " : " + err.statusText);
        }
    });
};

var loadNext = function(number) {
    var self = this;

        $.ajax({
            type: 'post',
            url: "Articles/ArticleNavNext", 
            dataType: "json",
            data: ko.toJSON({ CurrentPage: indexVM.CurrentPage }),
            contentType: "application/json; charset=utf-8",
            success: function(data) {
                indexVM.Results(data.Results);
                indexVM.CurrentPage(data.CurrentPage);
            },
            error: function(err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    }



var loadPrevious = function (number) {
    var self = this;

    $.ajax({
        type: 'post',
        url: "Articles/ArticleNavPrev",
        dataType: "json",
        data: ko.toJSON({ CurrentPage: indexVM.CurrentPage }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            indexVM.Results(data.Results);
            indexVM.CurrentPage(data.CurrentPage);
        },
        error: function (err) {
            alert(err.status + " : " + err.statusText);
        }
    });
}

    
$(function () {
    ko.applyBindings(indexVM);
    loadArticles();
});