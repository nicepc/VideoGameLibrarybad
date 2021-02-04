// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#rentModal').on('show.bs.modal', event => {
    let button = $(event.relatedTarget); // Button that triggered the modal
    let game = button.data('game'); // Extract info from data-* attributes
    $('.modal-game-title').text(game);
    $('#gameidRent').val(button.data('gameid'));
});


$('#deleteModal').on('show.bs.modal', event => {
    let button = $(event.relatedTarget); // Button that triggered the modal
    let game = button.data('game'); // Extract info from data-* attributes
    $('#deleteModalLabel').text("Delete Game: " + game );
    $('#gameidDelete').val(button.data('gameid'));
});

