function exibirAlertaDeErro(mensagem) {
    $("#alert-text").text(mensagem);
    $("#alert-erro").removeClass("hide").addClass("show")
}
function fecharAlertaDeErro() {
    $('#alert-erro').removeClass('show').addClass('hide');
}