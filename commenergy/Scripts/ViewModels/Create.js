/// <reference path="Create.js" />
var urlPath = window.location.pathname;

function Article(data) {
    this.Key = ko.observable(data.Key);
    this.Title = ko.observable(data.Title);
    this.Body = ko.observable(data.Body);
    this.MetaDescription = ko.observable(data.MetaDescription);
    this.ImagePath = ko.observable(data.ImagePath);
    
}

function ArticleViewModel() {
    var self = this;
    self.Key = ko.observable();
   
    self.Title = ko.observable();
    self.MetaDescription = ko.observable();
    self.Body = ko.observable();
    self.ImagePath = ko.observable();
    self.file = ko.observable();
    self.addArticle = function() {
        var newarticle = new Article({
            Key: this.Key(),
            Title: this.Title(),
            Body: this.Body(),
            MetaDescription: this.MetaDescription(),
            ImagePath: $('input[type=file]').val().replace(/C:\\fakepath\\/i, ''),
            File: this.file()
        });


        $.ajax({
            url: window.location.href,
            type: 'post',
            dataType: 'json',
            data: ko.toJSON(newarticle),
            contentType: 'application/json',
            success: function(result) {
                window.location.href = urlPath + '/';
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
  

window.onload = function () {
    document.getElementById('uploader').onsubmit = function () {
        var formdata = new FormData(); //FormData object
        var fileInput = document.getElementById('fileInput');
        //Iterating through each files selected in fileInput
        for (i = 0; i < fileInput.files.length; i++) {
            //Appending each file to FormData object
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }
        //Creating an XMLHttpRequest and sending
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Articles/Upload');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                alert(xhr.response);
                //Article.ImagePath = ko.observable(xhr.responseText.substring(1, xhr.responseText.length - 1));
                
            }
        }
        return false;
    }
}



$(function () {
    ko.bindingHandlers.file = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var $element = $(element);
            var value = valueAccessor();

            value.binaryString = ko.observable();
            value.text = ko.observable();
            value.arrayBuffer = ko.observable();
            value.dataURL = ko.observable();

            $element.change(function () {
                var file = this.files[0];
                if (ko.isObservable(value)) {
                    value(file);
                }
            });
        },

        update: function (element, valueAccessor, allBindingsAccessor) {
            var value = valueAccessor();
            var file = ko.utils.unwrapObservable(value);

            function read(type) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    value[type](e.target.result);
                }
                reader['readAs' + type[0].toUpperCase() + type.slice(1, type.length)](file);
            }

            if (!file) {
                value.binaryString(null);
                value.text(null);
                value.arrayBuffer(null);
                value.dataURL(null);
            } else {
                read('binaryString');
                read('text');
                read('arrayBuffer');
                read('dataURL');
            }
        }
    }
});




