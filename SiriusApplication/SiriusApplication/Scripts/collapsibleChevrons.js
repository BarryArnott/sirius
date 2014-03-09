$(document).ready(function () {
    
        $('#accordion .panel-collapse').on('shown.bs.collapse', function () {
            $(this).prev().find(".glyphicon").removeClass("glyphicon-chevron-right").addClass("glyphicon-chevron-down");
        });

        //The reverse of the above on hidden event:
        $('#accordion .panel-collapse').on('hidden.bs.collapse', function () {
            $(this).prev().find(".glyphicon").removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-right");
        });
    });