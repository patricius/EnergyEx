function UserViewModel() { 
 
    //Make the self as 'this' reference 
    var self = this; 
    //Declare observable which will be bind with UI  
    self.FirstName = ko.observable(""); 
    self.UserName = ko.observable(""); 
   
 
 
    var IdentityUser = { 
        FirstName: self.FirstName, 
        Username: self.UserName
    }; 
 
    self.User = ko.observable([]); 
  // Contains the list of products 
 
    // Initialize the view-model 
    $.ajax({ 
        url: '/Account/UserIndex', 
        cache: false, 
        type: 'GET', 
        contentType: 'application/json; charset=utf-8', 
       
        success: function (data) { 
            self.User(data);
           //Put the response in ObservableArray
        } 
    }); 
 

 
    ////Add New Item 
    //self.create = function () { 
    //    if (Article.Title() != "" && Article.Body() != "" && Article.Key() != "") { 
    //        $.ajax({ 
    //            url: 'Article/Create', 
    //            cache: false, 
    //            type: 'POST', 
    //            contentType: 'application/json; charset=utf-8', 
    //            data: ko.toJSON(Article), 
    //            success: function (data) { 
    //                // alert('added'); 
    //                self.Articles.push(data); 
    //                self.Title(""); 
    //                self.Key(""); 
    //                self.MetaDescription(""); 
 
    //            } 
    //        }).fail( 
    //             function (xhr, textStatus, err) { 
    //                 alert(err); 
    //             }); 
 
    //    } 
    //    else { 
    //        alert('Please Enter All the Values !!'); 
    //    } 
 
    //} 
    // Delete product details 
    self.delete = function (User) { 
        if (confirm('Are you sure to Delete "' + User.UserName + '" this article? ??')) { 
           
            var token = $('[name=__RequestVerificationToken]').val();
            var headers = {};
            headers["__RequestVerificationToken"] = token;

            $.ajax({ 
                url: '/Account/DeleteConfirmed', 
                
                headers: headers,
                type: 'POST',
                data: ko.toJSON(User),
                contentType: 'application/json; charset=utf-8', 
                success: function (data) { 
                    self.User.remove(User); 
                    alert("Record Deleted Successfully"); 
                } 
            }).fail( 
             function (xhr, textStatus, err) { 
                 alert(err); 
             }); 
        } 
    } 
 
   //Edit User details 
 
    self.edit = function (User) { 
        self.Article(Article); 
 
    } 
 
    //// Update product details 
    self.update = function () { 
    //    var Article = self.Article(); 
 
    //    $.ajax({ 
    //        url: '@Url.Action("Edit", "Articles")', 
    //        cache: false, 
    //        type: 'PUT', 
    //        contentType: 'application/json; charset=utf-8', 
    //        data: ko.toJSON(Article), 
    //        success: function (data) { 
    //            self.Article.removeAll(); 
    //            self.Article(data); //Put the response in ObservableArray 
    //            self.Article(null); 
    //            alert("Record Updated Successfully"); 
                            
    //        } 
    //    }) 
    //.fail( 
    //function (xhr, textStatus, err) { 
    //    alert(err); 
    //}); 
    //} 
 
 
    //// Reset product details 
    //self.reset = function () { 
    //    self.Title(""); 
    //    self.Key(""); 
    //    self.MetaDescription(""); 
    //} 
 
    //// Cancel product details 
 
    //self.cancel = function () { 
    //    self.Article(null); 
 
    //} 
} 
var viewModel = new UserViewModel(); 
ko.applyBindings(viewModel); 
 
