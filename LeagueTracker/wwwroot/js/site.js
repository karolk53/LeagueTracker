// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.club-name').click(function () {
        var clubId = $(this).data('club-id');
        $.ajax({
            url: '/Club/GetClubMatchesById/',
            type: 'GET',
            data: {clubId: clubId},
            success: function (data) {
                $('#club-matches').html(data);
            }
        });
    });
});