// Initialize and add the map
function startMap(cityShops) {
    // The map, centered at Uluru
    if (cityShops !== undefined && cityShops !== null &&  cityShops.city !== undefined && cityShops.city !== null) {
        uluru = { lat: cityShops.city.latitud, lng: cityShops.city.longitud };
        var map = new google.maps.Map(
            document.getElementById('map'), { zoom: 12, center: uluru });
        for (var i = 0; i < cityShops.shops.length; i++) {
            var marker = new google.maps.Marker({ position: { lat: cityShops.shops[i].latitud, lng: cityShops.shops[i].longitud}, map: map, icon: cityShops.shops[i].brand.marker });
        }
    }
}

function initMap() {
    // The map, centered at Uluru
    $.ajax({
        url: "/Home/GetCityShops",
        data: { city: $('#Ciudades').val() },
        success: function (result) {
            startMap(result);
        }
    });
}