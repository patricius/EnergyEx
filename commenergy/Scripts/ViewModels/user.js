var UserVM = {
    Article: ko.observableArray([]),
    Username: ko.observable(),

    loadArticles: function () {
        var self = this;

        $.ajax({

            url: "Articles/UserInfo",
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
    ko.applyBindings(UserVM);
    UserVM.loadArticles();
});