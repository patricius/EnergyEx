var viewModel = {
    Articles: ko.observableArray()
};

$(document).ready(function () {
  
    var data = JSON.parse($("#serverJSON").val());
    $(data).each(function (index, element) {
        var mappedItem =
            {
                Id: ko.observable(element.Id),
                Key: ko.observable(element.Key),
                Title: ko.observable(element.Value),
                Mode: ko.observable("display"),
                Edit: function (current) {
                    //var current = ko.dataFor(this);
                    current.Mode("edit");
                },
                Update: function (current) {
                    //var current = ko.dataFor(this);
                    saveData(current);
                    current.Mode("display");
                }
            };
        viewModel.lookupCollection.push(mappedItem);
    });
    ko.applyBindings(viewModel);
    //}).error(function (ex) {
    //    alert("Error");
    //});

    //$(document).on("click", ".kout-edit", null, function (ev) {

    //});

    //$(document).on("click", ".kout-update", null, function (ev) {

    //});

    $(document).on("click", "#create", null, function (ev) {
        var current = {
            Id: ko.observable(0),
            Key: ko.observable(),
            Value: ko.observable(),
            Mode: ko.observable("edit")
        };
        viewModel.lookupCollection.push(current);
    });

    function saveData(currentData) {
        var postUrl = "";
        var submitData = {
            Id: currentData.Id(),
            Key: currentData.Key(),
            Value: currentData.Value(),
            __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
        };

        if (currentData.Id && currentData.Id() > 0) {
            postUrl = "/Articles/Edit";
        }
        else {
            postUrl = "/Articles/Create";
        }
        $.ajax({
            type: "POST",
            //contentType: "application/json",
            contentType: "application/x-www-form-urlencoded",
            url: postUrl,
            // data: JSON.stringify(submitData)
            data: submitData
        }).done(function (id) {
            currentData.Id(id);
        }).error(function (ex) {
            alert("ERROR Saving");
        })
    }
});