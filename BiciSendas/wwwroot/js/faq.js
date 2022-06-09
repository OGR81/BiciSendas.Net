function guardarFaq() {
    var modelo[] = {
        pregunta = document.getElementById("Titulo").value,
        respuesta = document.getElementById("Descripcion").value,
        posicion = document.getElementById("Posicion").value
    };
    console.log($("#form_faq").serialize());
    $.ajax({
        url: "/Operaciones/Faq/Grabar",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        type: 'POST',
        cache:false,
        data: $("#form_faq").serialize(),
        success: (result) => {
            alert('result');
            $("#modalNuevoFaq").modal('hide');
        }
    })
}

$(document).ready(() => {

})