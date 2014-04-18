// TODO: This is a horrible, hacky and static implementation. Complete refactor required to be more dynamic.

// Initialise map when collapse location div is shown
$('#collapseLocation0').on('shown.bs.collapse', function () {
    var count = 0;
    
    GoogleMapInitialise(count);
});

// RInitialise map when collapse location div is shown
$('#collapseLocation1').on('shown.bs.collapse', function () {
    var count = 1;
    
    GoogleMapInitialise(count);
});

// Initialise map when collapse location div is shown
$('#collapseLocation2').on('shown.bs.collapse', function () {
    var count = 2;

    GoogleMapInitialise(count);
});
 
function GoogleMapInitialise(collapseLocation) {

    // Tell the api to use the new UI
    window.google.maps.visualRefresh = true;
    var latitudeLongitude = new window.google.maps.LatLng(window.latitude, window.longitude);

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 14,
        center: latitudeLongitude,
        mapTypeId: window.google.maps.MapTypeId.G_NORMAL_MAP
    };

    // This makes the div with id "map_canvas" a google map

    switch (collapseLocation) {
        case 0:
            var map0 = new window.google.maps.Map(document.getElementById('map_canvas0'), mapOptions);
            break;
        case 1:
            var map1 = new window.google.maps.Map(document.getElementById('map_canvas1'), mapOptions);
            break;
        case 2:
            var map2 = new window.google.maps.Map(document.getElementById('map_canvas2'), mapOptions);
            break;
        default:
            break;
    }
}