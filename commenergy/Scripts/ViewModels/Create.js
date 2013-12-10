/// <reference path="Create.js" />


function Article(data) {
    this.Key = ko.observable(data.Key);
    this.Title = ko.observable(data.Title);
    this.Body = ko.observable(data.Body);
    this.MetaDescription = ko.observable(data.MetaDescription);
}

function ArticleViewModel() {
    var self = this;
    self.Key = ko.observable();
  
    self.Title = ko.observable();
    self.MetaDescription = ko.observable();
    self.Body = ko.observable();
    self.addArticle = function() {
        var newarticle = new Article({
            Key: this.Key(),
            Title: this.Title(),
            Body: this.Body(),
            MetaDescription: this.MetaDescription(),
        });


        $.ajax({
            url: window.location.href,
            type: 'post',
            dataType: 'json',
            data: ko.toJSON(newarticle),
            contentType: 'application/json',
            success: function(result) {
                console.log("Created Article");
            },
            error: function(err) {
                if (err.responseText == "success") {
                    window.location.href = urlPath + '/';
                } else {
                    console.log(err.responseText);
                }
            },
            complete: function() {
            }
        });
    };
}



var vm = new ArticleViewModel();
        ko.applyBindings(vm);
  