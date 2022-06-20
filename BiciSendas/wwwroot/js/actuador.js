const comboTipoActuador = document.getElementById("TipoActuador");
const tblActuadores = document.getElementById("tblActuadores");

/*
 * Reseteamos los valores del filtro
 */
function resetFiltro() {

    comboTipoActuador.selectedIndex = "0";

    filtrar();
}

/*
 * Filtra los actuadores según filtro
 */
function filtrar() {
    var model = {

        TipoActuador: comboTipoActuador.value
        
    };

    var grid = new MvcGrid(document.querySelector('.mvc-grid'), {
        url: "/Operaciones/Actuadores/CargarActuadores",
        query: "filtroIndex=" + JSON.stringify(model)
    });

    //Recarga la lista
    grid.reload();
    bindeventBtnVer();

    //borramos la query al finalizar la busqueda
    new MvcGrid(document.querySelector('.mvc-grid'), {
        url: "/Operaciones/Actuadores/CargarActuadores",
        query: "filtroIndex="
    });
}

function mostrarDetalle(e) {
    mostrarCargando();
    $.ajax({
        url: "/Operaciones/Actuadores/ObtenerActuadores",
        data: { idActuador: e.target.dataset["id"] },
        type: "get",
        cache: false
    }).done((result) => {
        Swal.close();
        document.getElementById("tipoInformacion").innerHTML = result.tipoActuador;
        document.getElementById("descripcion").innerHTML = result.descripcion;
        $("#modalActuador").modal("show");
    }).fail(() => {
        mostrarError();
    });
}

function mostrarCargando() {
    Swal.fire({
        title: 'Cargando...',
        html: '',
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading()
        }
    })
}

function mostrarError() {
    Swal.fire({
        icon: 'error',
        text: 'Error al obtener el actuador!',
    })
}

function bindeventBtnVer() {
    //Utilizamos delegate porquel el botón btnVer al finalizar la carga de la página, todavía no es visible
    //y el bind con 'on' no funciona
    $("body").delegate('.btnVer', 'click', (e) => { mostrarDetalle(e) })
}

$(document).ready(function () {
    bindeventBtnVer();
});