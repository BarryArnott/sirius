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