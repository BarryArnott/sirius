$(document).ready(function () {
    $('.btn-primary').click(function () {
        var url = "/Photography/DisplayImageById";
        var id = $(this).attr('data-id'); // determine image id
        $.get(url + '/' + id, function (data) {
            $('#imageDetailsContainer').html(data);
            $('#imageDetailsModal').modal('show');
        });
    });
});