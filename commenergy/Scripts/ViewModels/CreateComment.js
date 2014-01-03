/// <reference path="../knockout.command.js" />



function Comment(data) {
    this.ArticleId = ko.observable(data.ArticleId);
    this.Author = ko.observable(data.Author);
    this.Body = ko.observable(data.Body);
 
    this.Email = ko.observable(data.Email);
    this.IpAddress = ko.observable(data.IpAddress);
    this.Url = ko.observable(data.Url);

}



var CommentViewModel = {
  
    ArticleId: ko.observable(),
    Author: ko.observable(),
    Body: ko.observable(),
    Email: ko.observable(),
    IpAddress: ko.observable(),
    Url: ko.observable(),

    addComment: function () {
        $.getJSON(window.location.href + "/display", {}, function (data) {
         CommentViewModel.ArticleId = ko.observable(data.Id);
        });


        var Comment1 = new Comment({
            
            ArticleId: CommentViewModel.ArticleId,
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
    }
};




   

    ko.applyBindings(CommentViewModel,document.getElementById("Comment"));
  
