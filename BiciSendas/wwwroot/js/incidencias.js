const btnBuscar = document.getElementById("btnBuscar");
const btnBorrar = document.getElementById("btnBorrar");
const dtpFechaDesde = document.getElementById("FechaDesde");
const dtpFechaHasta = document.getElementById("FechaHasta");
const txtPoblacion = document.getElementById("Poblacion");
const comboEstado = document.getElementById("Estado");
const tblIncidencias = document.getElementById("tblIncidencias");



/*
 * Reseteamos los valores del filtro
 */ 
function resetFiltro() {
    txtPoblacion.value = "";
    dtpFechaDesde.value = "";
    dtpFechaHasta.value = "";
    comboEstado.selectedIndex = "0";

    filtrar();
}

/*
 * Filtra las incidencias según filtros
 */ 
function filtrar() {
    var model = {
        FechaDesde: dtpFechaDesde.value,
        FechaHasta: dtpFechaHasta.value,
        Estado: comboEstado.value,
        Poblacion: txtPoblacion.value
    };

    var grid = new MvcGrid(document.querySelector('.mvc-grid'), {
        url: "/Monitorizacion/Incidencia/CargarIncidencias",
        query: "filtroIndex=" + JSON.stringify(model)
    });

    //Recarga la lista
    grid.reload();
    bindeventBtnVer();

    //borramos la query al finalizar la busqueda
    new MvcGrid(document.querySelector('.mvc-grid'), {
        url: "/Monitorizacion/Incidencia/CargarIncidencias",
        query: "model="
    });
}

function mostrarDetalle(e) {
    mostrarCargando();
    $.ajax({
        url: "/Monitorizacion/Incidencia/ObtenerIncidencia",
        data: { idIncidencia: e.target.dataset["id"] },
        type: "get",
        cache: false
    }).done((result) => {
        Swal.close();
        document.getElementById("title").innerHTML = result.tipoIncidencia;
        document.getElementById("descripcion").innerHTML = result.descripcion;
        document.getElementById("fecha").innerHTML = result.fecha;
        document.getElementById("imagenIncidencia").setAttribute("src", result.imagen);
        $("#modalIncidencia").modal("show");
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
        text: 'Error al obtener la incidencia!',
    })
}

function bindeventBtnVer() {
    //Utilizamos delegate porquel el botón btnVer al finalizar la carga de la página, todavía no es visible
    //y el bind con 'on' no funciona
    $("body").delegate('.btnVer', 'click', (e) => { mostrarDetalle(e) })
}

$(document).ready(function () {
    bindeventBtnVer();

    btnBuscar.addEventListener("click", () => filtrar());
    btnBorrar.addEventListener("click", () => resetFiltro());
});



