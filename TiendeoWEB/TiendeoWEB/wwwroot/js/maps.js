function startMap(cityShops) {
    if (cityShops !== undefined && cityShops !== null) {
        var city = { lat: cityShops.latitud, lng: cityShops.longitud };
        var map = new google.maps.Map(
            document.getElementById('map'), { zoom: 12, center: city });
        for (var i = 0; i < cityShops.tiendas.length; i++) {
            var marker = new google.maps.Marker({ position: { lat: cityShops.tiendas[i].latitud, lng: cityShops.tiendas[i].longitud }, map: map, icon: cityShops.tiendas[i].marker });
        }
        var dropDownNumero = $("#TiendasVisibles");
        for (var i = 1; i <= cityShops.numeroTotalTiendas; i++) {
            $(dropDownNumero).append($("<option />").val(i).text(i));
        }
        $(dropDownNumero).find("option[value=" + cityShops.tiendas.length + "]").last().attr("selected", '');
    } 
}

function initMap() {
    $.ajax({
        url: "/Home/GetCityShops",
        data: {top: $("#TiendasVisibles").val(), city: $('#Ciudades').val() },
        success: function (result) {
            startMap(result);
        }
    });
}