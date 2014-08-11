$(document).ready(function () {

    //resets the modal content in order to remove previous remote data
    $('body').on('hidden.bs.modal', '.modal', function () {
        $(this).removeData('bs.modal');
        }
    );

    $('.main-thumbnail').hover(
        function () {
            $(this).find('.main-caption').fadeIn(400); //.fadeIn(250)
        },
        function () {
            $(this).find('.main-caption').fadeOut(400); //.fadeOut(205)
        }
    );
});