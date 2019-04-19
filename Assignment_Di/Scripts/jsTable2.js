$(document).ready(function () {
    $('#pList tbody tr:even').addClass("silver");
    $('#pList tbody tr').mouseover(function () {
        $(this).addClass('dataHover');
    });
    $('#pList tbody tr').mouseout(function () {
        $(this).removeClass('dataHover');
    });
});