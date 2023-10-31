/*автоматическое дополнение адреса при вводе и отображение на карте*/
ymaps.ready(init);
function init() {
    var myMap;
    var suggestView1 = new ymaps.SuggestView("suggest");

    $('#toggle').bind({
        click: function () {
            var searchControl = new ymaps.control.SearchControl({
                options: {
                    noSelect: true
                }
            });
            if (!myMap) {
                myMap = new ymaps.Map('map', {
                    center: [55.76, 37.64],
                    zoom: 8
                });

                ymaps.geocode(document.getElementById("suggest").value, {
                    results: 1
                }).then(function (res) {
                    var firstGeoObject = res.geoObjects.get(0),
                        coords = firstGeoObject.geometry.getCoordinates(),
                        bounds = firstGeoObject.properties.get('boundedBy');

                    firstGeoObject.options.set('preset', 'islands#darkBlueDotIconWithCaption');
                    firstGeoObject.properties.set('iconCaption', firstGeoObject.getAddressLine());

                    myMap.geoObjects.add(firstGeoObject);
                    myMap.setBounds(bounds, {
                        checkZoomRange: true
                    });
                });

                $("#toggle").attr('value', 'Скрыть карту');
            }
            else {
                myMap.destroy();
                myMap = null;
                $("#toggle").attr('value', 'Показать карту');
            }
        }
    });
}
