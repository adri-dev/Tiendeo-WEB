$('#Ciudades').on('change', {}, function () {
    $("#TiendasVisibles").children().remove();
    initMap();
});

$('#TiendasVisibles').on('change', {}, function () {
    initMap();
});