function guardarActuador() {
    if ($("#form_faq").valid()) {
        event.preventDefault();
    }

    const model = obtenerModelo();

    if (model.idActuador != 0 && model.posicion != null) {
        $.ajax({
            url: "/Operaciones/Actuador/ComprobarPosicion",
            type: "get",
            cache: false,
            data: { idActuador: model.idActuador, posicion: model.posicion },
        }).done((result) => {
            if (result) {
                Swal.fire({
                    html: "¿Ya existe una pregunta con la misma posición?<br>Si continua, se asignará la posición a la pregunta editada y se borrará la posición a la anterior pregunta",
                    title: "Actualizar pregunta",
                    icon: 'question',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    cancelButtonText: 'No',
                    confirmButtonText: 'Sí'
                }).then((result) => {
                    if (result.isConfirmed)
                        guardar(model, true);
                });
            } else {
                guardar(model, false);
            }
        });
    } else {
        guardar(model, false);
    }
}

function guardar(model, actualizarPosicion) {
    $.ajax({
        url: "/Operaciones/Faq/Grabar",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        type: 'POST',
        cache: false,
        data: { model: model, actualizarPosicion: actualizarPosicion },
        success: (result) => {
            if (result.success) {
                $("#modalNuevoFaq").modal('hide');
                new MvcGrid(document.querySelector('.mvc-grid')).reload();
                toastr.success("Faq guardada");
            } else {
                if (result.message != undefined) {
                    Swal.fire({
                        icon: 'error',
                        text: result.message,
                        timerProgressBar: false,
                    })
                }
            }
        }
    })
}

function bindButtonsGrid() {
    $("body").delegate('.btnVer', 'click', (e) => { verFaq(e) });
    $("body").delegate('.btnEditar', 'click', (e) => { editarFaq(e) });
    $("body").delegate('.btnEliminar', 'click', (e) => { eliminarFaq(e) });
}

function editarFaq(e) {
    const idFaq = e.target.dataset["id"];
    obtenerDatos(idFaq);
    document.getElementById("btnGuardar").hidden = false;
    document.getElementById("btnCerrar").hidden = true;

    habilitarDeshabilitarControles(true);
}

function verFaq(e) {
    const idFaq = e.target.dataset["id"];
    obtenerDatos(idFaq);
    document.getElementById("btnGuardar").hidden = true;
    document.getElementById("btnCerrar").hidden = false;

    habilitarDeshabilitarControles(false);
}

function habilitarDeshabilitarControles(edicion) {
    const elements = document.getElementsByClassName("modal-control");

    if (edicion) {
        Array.from(elements).forEach(node => node.removeAttribute("readonly"));
    } else {
        Array.from(elements).forEach(node => node.setAttribute("readonly", "readonly"));
    }
}

function obtenerDatos(idFaq) {
    $.ajax({
        url: "/Operaciones/Faq/ObtenerFaq",
        data: { idFaq: idFaq },
        type: 'get',
        cache: false
    }).done((result) => {
        $("#modalNuevoFaq").modal("show");
        cargarDatos(result);
    }).fail(() => {
        Swal.fire({
            icon: 'error',
            text: 'Error al obtener faq',
        })
    });
}

function obtenerModelo() {
    var model = {
        idFaq: document.getElementById("FaqVM_IdFaq").value,
        titulo: document.getElementById("FaqVM_Titulo").value,
        descripcion: document.getElementById("FaqVM_Descripcion").value,
        posicion: document.getElementById("FaqVM_Posicion").value
    };

    return model;
}

function cargarDatos(result) {
    document.getElementById("FaqVM_IdFaq").value = result.idFaq;
    document.getElementById("FaqVM_Titulo").value = result.titulo;
    document.getElementById("FaqVM_Posicion").value = result.posicion;
    document.getElementById("FaqVM_Descripcion").value = result.descripcion;
}

function resetDatos() {
    document.getElementById("FaqVM_IdFaq").value = "";
    document.getElementById("FaqVM_Titulo").value = "";
    document.getElementById("FaqVM_Posicion").value = "";
    document.getElementById("FaqVM_Descripcion").value = "";
}

function eliminarFaq(e) {
    const idFaq = e.target.dataset["id"];

    Swal.fire({
        text: "¿Desea eliminar la pregunta seleccionada? ",
        title: "Eliminar pregunta",
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
        confirmButtonText: 'Sí'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: "/Operaciones/Faq/Eliminar",
                data: { idFaq: idFaq },
                type: "post",
                cache: false
            }).done((result) => {
                if (result.success) {
                    toastr.success("Pregunta eliminada");
                    new MvcGrid(document.querySelector('.mvc-grid')).reload();
                    resetValues();
                } else {
                    Swal.fire({
                        icon: 'error',
                        test: "No se ha podido eliminar la pregunta",
                        timerProgressBar: false,
                    })
                }
            }).fail((result) => {
                Swal.fire({
                    icon: 'error',
                    text: 'Error: ' + result,
                    timerProgressBar: false,
                })
            });
        }
    })
}