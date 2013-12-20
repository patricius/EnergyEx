var urlPath = window.location.href;


var indexVM = {    
    Results: ko.observableArray([]),
    PageCount: ko.observable(),
    PageSize: ko.observable(),
    RowCount: ko.observable(),
    URLTo: ko.observable(),
    Title: ko.observable(),
    Body: ko.observable(),
    Key: ko.observable(),
    Comments: ko.observableArray([]),
    
    loadArticles: function() {
        var self = this;

        $.ajax({

            url: "Articles/ArticleLists/",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data) {
                self.Results(data.Results);
            },
            error: function(err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    }
};
    
$(function () {
    ko.applyBindings(indexVM);
    indexVM.loadArticles();
});