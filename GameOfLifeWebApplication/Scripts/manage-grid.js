$(document).ready(function () {
    $(".cell").click(function () {
        $(this).toggleClass('clicked');
    });

    $('#reset').click(function () {
        alert("clicked");
    });
   
});

