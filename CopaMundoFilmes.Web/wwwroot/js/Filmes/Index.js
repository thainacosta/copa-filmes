function contarSelecionados() {
    var selecionados = $("input[type='checkbox']:checked").length;
    $("#spanSelecionados").text(selecionados);
}

function enviarFormulario() {
    var selecionados = $("input[type='checkbox']:checked").length;
    if (selecionados != 8) {        
        exibirAlertaDeErro("Selecione 8 filmes."); 
        return false;
    }
    return true;
}

