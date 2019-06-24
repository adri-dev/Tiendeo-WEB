var dropDownNumero = "#TiendasVisibles";
var ciudadesDropDowm = '#Ciudades';
/**
 * @description Inits the Shup Number DropDown
 * @param {any} numberShops total number of Shops
 * @param {any} selectedValue selected value
 */
function initShopNumber(numberShops, selectedValue) {
    for (var i = 1; i <= numberShops; i++) {
        $(dropDownNumero).append($("<option />").val(i).text(i));
    }
    $(dropDownNumero).find("option[value=" + selectedValue + "]").last().attr("selected", '');
}

/**
 * @description: Inits Google Maps Map
 * @param {any} cityShops City and Shops Information
 */
function startMap(cityShops) {
    if (cityShops !== undefined && cityShops !== null && cityShops.ciudad !== undefined && cityShops.ciudad !== null) {
        var city = { lat: cityShops.ciudad.latitud, lng: cityShops.ciudad.longitud };
        var map = new google.maps.Map(
            document.getElementById('map'), { zoom: 12, center: city });
        for (var i = 0; i < cityShops.tiendas.length; i++) {
            var marker = new google.maps.Marker({ position: { lat: cityShops.tiendas[i].latitud, lng: cityShops.tiendas[i].longitud }, map: map, icon: cityShops.tiendas[i].marker });
        }
        initShopNumber(cityShops.numeroTotalTiendas, cityShops.tiendas.length);
    } 
}
/**
 * @description Gets Data to Init Google Maps Map
 */
function initMap() {
    $.ajax({
        url: "/Home/GetCityShops",
        data: { top: $(dropDownNumero).val(), city: $(ciudadesDropDowm).val() },
        success: function (result) {
            startMap(result);
        }
    });
}

$(ciudadesDropDowm).on('change', {}, function () {
    $(dropDownNumero).children().remove();
    initMap();
});

$(dropDownNumero).on('change', {}, function () {
    initMap();
});