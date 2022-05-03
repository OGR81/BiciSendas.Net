// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#language li a').on('click', function () {
    $(this).parents(".dropdown").find(".btn").html($(this).html());
});
