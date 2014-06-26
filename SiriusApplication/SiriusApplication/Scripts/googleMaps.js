$('.panel-collapse').on('shown.bs.collapse', function (e) {
    var increment = e.currentTarget.id.slice(-1);
    var latitude = $('#latitude' + increment).attr("value");
    var longitude = $('#longitude' + increment).attr("value");
    
    GoogleMapInitialise(increment, latitude, longitude);
});
 
function GoogleMapInitialise(collapseLocation, latitude, longitude) {

    // Tell the api to use the new UI
    window.google.maps.visualRefresh = true;
    var latitudeLongitude = new window.google.maps.LatLng(latitude, longitude);

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 14,
        center: latitudeLongitude,
        mapTypeId: window.google.maps.MapTypeId.G_NORMAL_MAP
    };

    // This makes the div with id "map_canvas" a google map
    // TODO: Need to remove harcoding of 3 cases and refactor to be more dynamic
    var map;
    switch (collapseLocation) {
        case '0':
            var map0 = new window.google.maps.Map(document.getElementById('map_canvas0'), mapOptions);
            map = map0;
            break;
        case '1':
            var map1 = new window.google.maps.Map(document.getElementById('map_canvas1'), mapOptions);
            map = map1;
            break;
        case '2':
            var map2 = new window.google.maps.Map(document.getElementById('map_canvas2'), mapOptions);
            map = map2;
            break;
        case '3':
            var map3 = new window.google.maps.Map(document.getElementById('map_canvas3'), mapOptions);
            map = map3;
            break;
        case '4':
            var map4 = new window.google.maps.Map(document.getElementById('map_canvas4'), mapOptions);
            map = map4;
            break;
        case '5':
            var map5 = new window.google.maps.Map(document.getElementById('map_canvas5'), mapOptions);
            map = map5;
            break;
        case '6':
            var map6 = new window.google.maps.Map(document.getElementById('map_canvas6'), mapOptions);
            map = map6;
            break;
        case '7':
            var map7 = new window.google.maps.Map(document.getElementById('map_canvas7'), mapOptions);
            map = map7;
            break;
        case '8':
            var map8 = new window.google.maps.Map(document.getElementById('map_canvas8'), mapOptions);
            map = map8;
            break;
        case '9':
            var map9 = new window.google.maps.Map(document.getElementById('map_canvas9'), mapOptions);
            map = map9;
            break;
        case '10':
            var map10 = new window.google.maps.Map(document.getElementById('map_canvas10'), mapOptions);
            map = map10;
            break;
        default:
            map = map0;
            break;
    }

    GoogleMapMarkerInitialise(latitudeLongitude, map);
}

function GoogleMapMarkerInitialise(latitudeLongitude, map) {
    
    //initialise marker based on model latitude and longitude
    var marker = new window.google.maps.Marker({
        position: latitudeLongitude,
        map: map,
        title: 'Hello World!',
        animation: window.google.maps.Animation.DROP
    });
}