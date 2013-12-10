var viewModel = {
   Articles: ko.observableArray([]),
    currentPage: ko.observable(-1)
};

$(document).ready(function () {
    ko.applyBindings(viewModel);
    getData(viewModel.currentPage() + 1);
    $(window).scroll(function (evt) {
        evt.preventDefault();
        if ($(window).scrollTop() >= $(document).height() - $(window).height()) {
            console.log("Scroll Postion" + $(window).scrollTop());
            getData(viewModel.currentPage() + 1);
        }
    });
});

function getData(pageNumber) {
    if (viewModel.currentPage() != pageNumber) {
        console.log("Scroll Postion begin getData" + $(window).scrollTop());
        $.ajax({
            url: "/Articles/Index",
            type: "get",
            contentType: "application/json",
            data: { id: pageNumber }
        }).done(function (data) {
            if (data.length > 0) {
                viewModel.currentPage(viewModel.currentPage() + 1);
                for (i = 0; i < data.length; i++) {
                    viewModel.Articles.push(data[i]);
                    console.log("Scroll Postion looping ViewModel" + $(window).scrollTop());
                }
            }
        });
    }
}