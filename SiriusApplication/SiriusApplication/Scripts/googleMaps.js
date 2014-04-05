// This code tells the browser to execute the "Initialize" method only when the complete document model has been loaded
$(document).ready(function () {
    Initialize();
});

$('#barry0').click(function () {
    Initialize();
});

$('#barry1').click(function () {
    Initialize();
});

$('#barry2').click(function () {
    Initialize();
});

// Where all the fun happens 
function Initialize() {

    alert("Initialize Called.");

    // Google has tweaked their interface somewhat - this tells the api to use that new UI
    window.google.maps.visualRefresh = true;
    var Liverpool = new window.google.maps.LatLng(53.408841, -2.981397);

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 14,
        center: Liverpool,
        mapTypeId: window.google.maps.MapTypeId.G_NORMAL_MAP
    };

    // This makes the div with id "map_canvas" a google map
    var map0 = new window.google.maps.Map(document.getElementById('map_canvas0'), mapOptions);
    
    var map1 = new window.google.maps.Map(document.getElementById('map_canvas1'), mapOptions);
    
    var map2 = new window.google.maps.Map(document.getElementById('map_canvas2'), mapOptions);
}