$(document).ready(function () {
    $('.btn-primary').click(function () {
        var url = "/Photography/DisplayImageById";
        var id = $(this).attr('data-id'); // determine image id
        $.get(url + '/' + id, function (data) {
            $('#imageDetailsContainer').html(data);
            $('#imageDetailsModal').modal('show');
        });
    });

    $('.main-thumbnail').hover(
        function () {
            $(this).find('.main-caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.main-caption').slideUp(250); //.fadeOut(205)
        }
    );
});