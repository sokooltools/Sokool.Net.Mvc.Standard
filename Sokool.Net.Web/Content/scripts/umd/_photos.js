function display(img) {
    var modal = $("#divimage");
    modal.css("display", "block");
    $("#modalimg").attr("src", img.src);
    $("#caption").html(img.alt);
    modal.click(function () {
        modal.css("display", "none");
    });
}

//function activate(id) {
//    $(".nav-tabs a").click(function() {
//        $(this).tab("show");
//    });
//}

//function activate(id, event) {
//    $(`a#${id}.nav-link`).tab("show");
//};

//function activatetab(id) {
//    const phototab = localStorage.getItem("phototab");
//    if(phototab){
//        $(`.nav-tabs a[href="${phototab}"]`).tab("show");
//    }
//};

$(document).ready(function () {

    $(`#phototab .nav-link`).on("click", function (e) {
        sessionStorage.setItem("phototab", $(e.target).attr("href"));
    });

    (function () {
        const phototab = sessionStorage.getItem("phototab");
        if (phototab) {
            $(`.nav-tabs a[href="${phototab}"]`).tab("show");
            if (window.location.pathname !== phototab)
                window.location.pathname = phototab;
        }
    })();

    //$(`#phototab .nav-link`).on("shown.bs.tab", function (e) {
    //    alert("New tab visible now!");
    //});

    //$(".nav-tabs a").on("shown.bs.tab", function (e) {
    //    alert("New tab visible now!");
    //    //event.preventDefault();
    //});

    //$(".navbar-nav .nav-link").click(function () {
    //    $(".navbar-nav .nav-link").removeClass("active");
    //    $(this).addClass("active");
    //});

});
