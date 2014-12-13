function UserViewModel() {

    //Make the self as 'this' reference 
    var self = this;

    self.FirstName = ko.observable("");
    self.UserName = ko.observable("");
    self.RoleName = ko.observable("");
    self.Selected = ko.observable("");
    self.Roles = ko.observableArray([]);



    var User = {
        FirstName: self.FirstName,
        Username: self.UserName,
        RoleName: self.RoleName,
        Roles: self.Roles,
        Email: self.Email,
        Selected: self.Selected,
    };

    self.User = ko.observable();
    self.User = ko.observableArray([]);


    $.ajax({
        url: '/Account/UserIndex',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',

        success: function (data) {
            self.User(data.User);
            //Put the response in ObservableArray
            self.User(data);
        }
    });



    //Add New Item 
    self.create = function () {
        if (User.FirstName() != "" && User.LastName() != "" && User.RoleId != "") {
            $.ajax({
                url: 'Account/Create',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(Article),
                success: function (data) {
                    // alert('added'); 
                    self.User.push(data);
                    self.FirstName("");
                    self.RoleId();


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
    //} 
    // Delete product details 
    self.delete = function (User) {
        if (confirm('Are you sure to Delete "' + User.UserName + '" this user? ??')) {

            var token = $('[name=__RequestVerificationToken]').val();
            var headers = {};
            headers["__RequestVerificationToken"] = token;

            $.ajax({
                url: '/Account/DeleteConfirmed',
                type: 'POST',
                headers: headers,
          
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

        var token = $('[name=__RequestVerificationToken]').val();
        var headers = {};
        headers["__RequestVerificationToken"] = token;

        $.ajax({
            url: '/Account/UserRoles',
            cache: false,
            type: 'POST',
           headers: headers,
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(User),
            success: function (data) {

                //Put the response in ObservableArray
                self.Roles(data);
                self.User(data);
            }
        });
    }

    //// Upd,ate product details 
    self.update = function () {
        var User = self.User;
        var token = $('[name=__RequestVerificationToken]').val();
        var headers = {};
        headers["__RequestVerificationToken"] = token;
        $.ajax({
            url: '/Account/UserRoleEdit',
            cache: false,
            type: 'POST',
            headers: headers,
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(User),
            success: function (data) {
                
                self.User(data); //Put the response in ObservableArray 
                
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



    self.cancel = function () {
        self.User(null);

    }


}


    var viewModel = new UserViewModel();
    ko.applyBindings(viewModel);
