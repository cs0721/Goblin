$(document).ready(function () {
    $('#data tbody tr:even').css('background-color', 'lightgray');

    $('#data tbody tr:even').addClass("lightgray");

    $('#data tbody tr').mouseover(function () {
        $(this).addClass('dataHover');
    });
    $('#data tbody tr').mouseout(function () {
        $(this).removeClass('dataHover');
    });
});