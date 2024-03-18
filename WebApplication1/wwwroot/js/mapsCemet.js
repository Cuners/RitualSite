ymaps.ready(init);

function init() {
    var myMap = new ymaps.Map('map', {
        center: [55.818128, 49.098001],
        zoom: 10
    });

    // Первая метка
    addMarker('Казань ул. Мамадышский тракт, Самосыровское кладбище');

    // Добавление других меток
    addMarker('Казань, кладбище Киндери');
    addMarker('Казань ул. Пригородная 1');
    addMarker('Казань ул. Песочная 1а');


    function addMarker(address) {

        ymaps.geocode(address, {
            results: 1
        }).then(function (res) {

            var firstGeoObject = res.geoObjects.get(0),
                coords = firstGeoObject.geometry.getCoordinates(),
                bounds = firstGeoObject.properties.get('boundedBy');

            firstGeoObject.options.set('preset', 'islands#darkBlueDotIconWithCaption');
            firstGeoObject.properties.set('iconCaption', firstGeoObject.getAddressLine());

            myMap.geoObjects.add(firstGeoObject);
            console.log('Данные геообъекта: ', firstGeoObject.properties.getAll());
        });
    }
}