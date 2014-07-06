$(document).ready(function () {
    $('.btn-primary').click(function () {
        var url = "/Photography/DisplayImageById";
        var id = $(this).attr('data-id'); // determine image id
        $.get(url + '/' + id, function (data) {
            $('#imageDetailsContainer').html(data);
            $('#imageDetailsModal').modal('show');
        });
    });

    $('.thumbnail').hover(
        function () {
            $(this).find('.caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').slideUp(250); //.fadeOut(205)
        }
    );
});