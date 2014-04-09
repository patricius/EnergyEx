/// <reference path="../knockout.command.js" />

ko.bindingHandlers.rateit = {
    init: function (element, valueAccessor) {
        var local = ko.toJS(valueAccessor()),
            options = {};

        if(typeof local === 'number') {
            local = {
                value: local
            };
        }

        ko.utils.extend(options, ko.bindingHandlers.rateit.options);
        ko.utils.extend(options, local);

        $(element).rateit(options);
        //register an event handler to update the viewmodel when the view is updated.
        $(element).bind('rated', function (event, value) {
            var floa = parseFloat(value.toFixed(1));
            var observable = valueAccessor();
            if(ko.isObservable(observable)) {
                observable(floa);
            } else {
                if(observable.value !== undefined && ko.isObservable(observable.value)) {
                    observable.value(floa);
                }
            }
        });
    },
    update: function(element, valueAccessor) {
        var local = ko.toJS(valueAccessor());
        
        if (typeof local === 'number') {
            local = {
                value: local
            };
        }
        if (local.value !== undefined) {
            var floa = parseFloat(local.value.toFixed(1));
            $(element).rateit('value', floa);
        }
        
    },
    options: {
        //this section is to allow users to override the rateit defaults on a per site basis.
        //override by adding ko.bindingHandlers.rateit.options = { ... }
    }
};

function Rating(data) {
    this.Id = ko.observable(data.Id);
    this.Rating = ko.observable(data.Rating);
    //this.Body = ko.observable(data.Body);
 
    //this.Email = ko.observable(data.Email);
    //this.IpAddress = ko.observable(data.IpAddress);
    //this.Url = ko.observable(data.Url);

}



var RatingViewModel = {
  
    Id: ko.observable(),
    Rating: ko.observable(),
  

    rateity: function () {
        $.getJSON(window.location.href + "/display", {}, function (data) {
         RatingViewModel.Id = ko.observable(data.Id);
        });


        var Comment1 = new Rating({

            Id: RatingViewModel.Id,
            Rating: this.Rating()
        });

     
        $.ajax({
            url: "/Articles/SaveRating",
            type: 'post',
            dataType: 'json',
            data: ko.toJSON(Comment1),
            contentType: 'application/json',
            success: function (result) {
                console.log("Rating submitted");
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




   
$(function () {
    $.ready(ko.applyBindings(RatingViewModel,document.getElementById("Rating")));
  
})