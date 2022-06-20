const comboTipoSensor = document.getElementById("TipoSensor");
const comboEstadoSensor = document.getElementById("EstadoSensor");
const tblSensores = document.getElementById("tblSensores");

/*
 * Reseteamos los valores del filtro
 */
function resetFiltro() {

    comboTipoSensor.selectedIndex = "0";
    comboEstadoSensor.selectedIndex = "0";

    filtrar();
}

/*
 * Filtra las sensores según filtros
 */
function filtrar() {
    var model = {
        
        EstadoSensor: comboEstadoSensor.value,
        TipoSensor: comboTipoSensor.value
    };

    var grid = new MvcGrid(document.querySelector('.mvc-grid'), {
        url: "/Monitorizacion/Sensores/CargarSensores",
        query: "filtroIndex=" + JSON.stringify(model)
    });

    //Recarga la lista
    grid.reload();
    bindeventBtnVer();

    //borramos la query al finalizar la busqueda
    new MvcGrid(document.querySelector('.mvc-grid'), {
        url: "/Monitorizacion/Sensores/CargarSensores",
        query: "filtroIndex="
    });
}

function mostrarGrafica(e) {
    mostrarCargando();
    $.ajax({
        url: "/Monitorizacion/Sensores/ObtenerSensor",
        data: { idSensor: e.target.dataset["id"] },
        type: "get",
        cache: false
    }).done((result) => {
        Swal.close();
    
        $("#modalSensor").modal("show");
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
        text: 'Error al obtener el sensor!',
    })
}

function bindeventBtnVer() {
    //Utilizamos delegate porquel el botón btnVer al finalizar la carga de la página, todavía no es visible
    //y el bind con 'on' no funciona
    $("body").delegate('.btnVer', 'click', (e) => { mostrarGrafica(e) })
}

$(document).ready(function () {
    bindeventBtnVer();
});