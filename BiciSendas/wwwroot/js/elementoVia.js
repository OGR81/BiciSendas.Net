/*
 * Función que guarda un nuevo elemento de vía
 */ 
function guardarElementoVia() {

    if ($("#form_elemento").valid()) {
        event.preventDefault();
    }

    $.ajax({
        url: "/Operaciones/ElementoVia/Grabar",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        data: $("#form_elemento").serialize(),
        type: 'POST',
        cache: false,
        success: function (result) {
            if (!result.success) {
                if (result.errors != undefined) {
                    //Creamos un elemento de tipo lista para guardar los errores
                    const ul = document.createElement("ul");
                    ul.setAttribute("align", "left");
                    result.errors.forEach(x => {
                        const li = document.createElement("li");
                        li.innerHTML = x;
                        ul.appendChild(li);
                    })

                    Swal.fire({
                        icon: 'error',
                        html: ul,
                        timerProgressBar: false,
                    })
                } 
            } else {
                toastr.success("Elemento vía guardado");
                resetValues();
                new MvcGrid(document.querySelector('.mvc-grid')).reload();
            }
        }
    })
}

/*
 * Función que elimina el elemento de vía seleccionado
 */ 
function removeElemento(e) {
    const id = e.target.dataset["id"];
    Swal.fire({
        text: "¿Desea eliminar el elemento vía: " + e.target.dataset["nombre"] + "? ",
        title: "Eliminar elemento vía",
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
        confirmButtonText: 'Sí'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: "/Operaciones/ElementoVia/Eliminar",
                data: { idElementoVia : id },
                type: "post",
                cache: false
            }).done((result) => {
                if (result.success) {
                    toastr.success("Elemento vía eliminado");
                    new MvcGrid(document.querySelector('.mvc-grid')).reload();
                    resetValues();
                } else {
                    Swal.fire({
                        icon: 'error',
                        test: "No se ha podido eliminar el elemento de vía",
                        timerProgressBar: false,
                    })
                }
            }).fail(() => {
                Swal.fire({
                    icon: 'error',
                    text: 'Error al eliminar elemento vía',
                    timerProgressBar: false,
                })
            });
        }
    })   
}

/*
 * Reseteamos los valores del formulario una vez guardado el elemento de vía
 */
function resetValues() {
    document.getElementById("Nombre").value = "";
    document.getElementById("TipoElemento").value = "";
    document.getElementById("Identificador").value = "";
}

$(document).ready(() => {
    $("body").delegate('.btnRemove', 'click', (e) => { removeElemento(e) })
});