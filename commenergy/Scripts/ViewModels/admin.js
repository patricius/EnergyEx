function ArticleViewModel() { 
 
    //Make the self as 'this' reference 
    var self = this; 
    self.Id = ko.observable(""); 
    self.Title = ko.observable(""); 
    self.Body = ko.observable(""); 
    self.MetaDescription = ko.observable();
 
    var Article = { 
        Id: self.Id, 
        Title: self.Title, 
        MetaDescription: self.MetaDescription, 
        Key: self.Key
    }; 
 
    self.Article = ko.observable(); 
    self.Results = ko.observableArray([]);  
 
    // Initialize the view-model 
    $.ajax({ 
        url: '/Articles/GetAllArticles', 
        cache: false, 
        type: 'GET', 
        contentType: 'application/json; charset=utf-8', 
       
        success: function (data) { 
            self.Results(data.Results);
           //Put the response in ObservableArray
        } 
    }); 
 

 
    //Add New Item 
    self.create = function () { 
        if (Article.Title() != "" && Article.Body() != "" && Article.Key() != "") { 
            $.ajax({ 
                url: 'Article/Create', 
                cache: false, 
                type: 'POST', 
                contentType: 'application/json; charset=utf-8', 
                data: ko.toJSON(Article), 
                success: function (data) { 
                    // alert('added'); 
                    self.Articles.push(data); 
                    self.Title(""); 
                    self.Key(""); 
                    self.MetaDescription(""); 
 
                } 
            }).fail( 
                 function (xhr, textStatus, err) { 
                     alert(err); 
                 }); 
 
        } 
        else { 
            alert('Please Enter All the Values !!'); 
        } 
 
    } 
    // Delete product details 
    self.delete = function (Article) { 
        if (confirm('Are you sure to Delete "' + Article.Title + '" this article? ??')) { 
            var id = Article.Id; 
 
            $.ajax({ 
                url: 'Articles/Delete', 
                cache: false, 
                type: 'POST', 
                contentType: 'application/json; charset=utf-8', 
                data: ko.toJSON(Article.Id), 
                success: function (data) { 
                    self.Articles.remove(Article); 
                    //   alert("Record Deleted Successfully"); 
                } 
            }).fail( 
             function (xhr, textStatus, err) { 
                 alert(err); 
             }); 
        } 
    } 
 
    // Edit product details 
 
    self.edit = function (Article) { 
        self.Article(Article); 
 
    } 
 
    // Update product details 
    self.update = function () { 
        var Article = self.Article(); 
 
        $.ajax({ 
            url: '@Url.Action("Edit", "Articles")', 
            cache: false, 
            type: 'PUT', 
            contentType: 'application/json; charset=utf-8', 
            data: ko.toJSON(Article), 
            success: function (data) { 
                self.Article.removeAll(); 
                self.Article(data); //Put the response in ObservableArray 
                self.Article(null); 
                alert("Record Updated Successfully"); 
                            
            } 
        }) 
    .fail( 
    function (xhr, textStatus, err) { 
        alert(err); 
    }); 
    } 
 
 
    // Reset product details 
    self.reset = function () { 
        self.Title(""); 
        self.Key(""); 
        self.MetaDescription(""); 
    } 
 
    // Cancel product details 
 
    self.cancel = function () { 
        self.Article(null); 
 
    } 
} 
var viewModel = new ArticleViewModel(); 
ko.applyBindings(viewModel); 
 
