$(document).ready(function () {
    $(`#navtab .nav-link`).on("click", function (e) {
        sessionStorage.setItem("navtab", $(e.target).attr("id"));
    });

    (function () {
        var current = getInitPath(window.location.pathname.toLowerCase());
        $(".navbar-nav a").each(function () {
            const $this = $(this);
            const next = getInitPath($this.attr("href")).toLowerCase();
            if (next === current) {
                $this.addClass("active");
                $this.tab("show");
            } else {
                $this.removeClass("active");
            }
        });

        function getInitPath(path) {
            const idx = path.indexOf("/video"); // Special handling for "video/show/xxxx"
            if (idx > -1)
               return "/video/index";
            const arr = path.split("/");
            if (arr.length > 2)
                return `/${arr[1]}/${arr[2]}`;
            else
                return "/";
        }
    })();
});


function GoBack() {
    //const path = $("#navtab a.active").attr("href");
    //setTimeout(function () { document.location.href = path; }, 250);
    setTimeout(function () { window.history.go(-1); }, 250);
}
