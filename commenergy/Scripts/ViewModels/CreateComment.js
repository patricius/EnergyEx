/// <reference path="../knockout.command.js" />


function Comment(data) {
    this.ArticleId = ko.observable(data.ArticleId);
    this.Author = ko.observable(data.Author);
    this.Body = ko.observable(data.Body);
    this.Email = ko.observable(data.Email);
    this.IpAddress = ko.observable(data.IpAddress);
    this.Url = ko.observable(data.Url);

}

function CommentViewModel() {
    var self = this;
    self.Author = ko.observable();
    self.ArticleId = ko.observable();
    self.Body = ko.observable();
    self.Email = ko.observable();
    self.IpAddress = ko.observable();
    self.Url = ko.observable();
    self.addComment = function () {
        var Comment1 = new Comment({
           ArticleId: this.ArticleId(), 
           Author: this.Author(),
           Body: this.Body(),
           Email: this.Email(),
           IpAddress: this.IpAddress(),
           Url: this.Url(),
        });


        $.ajax({
            url: "/Articles/Comment",
            type: 'post',
            dataType: 'json',
            data: ko.toJSON(Comment1),
            contentType: 'application/json',
            success: function (result) {
                console.log("Comment submitted");
            },
            error: function (err) {
                if (err.responseText == "success") {
                    window.location.href = urlPath + '/';
                } else {
                    console.log(err.responseText);
                }
            },
            complete: function () {
            }
        });
    };
}



var cm = new CommentViewModel();
ko.applyBindings(cm,document.getElementById("Comment"));
