var bikeLines = {
    "type": "FeatureCollection",
    "features": [
        {
            "type": "Feature",
            "geometry": {
                "type": "LineString",
                "coordinates": [
                    [2.041835, 41.348421],
                    [2.038442, 41.350112],
                    [2.036156, 41.352514],
                    [2.035931, 41.353223]
                ]
            },
            "properties": {
                "popupContent": "Carril bici 1",
                "style": {
                    weight: 5,
                    color: "#126609",
                    opacity: 1
                }
            },
            "id": 1
        },
        {
            "type": "Feature",
            "geometry": {
                "type": "LineString",
                "coordinates": [
                    [2.05177, 41.34721],
                    [2.04538, 41.33492],
                    [2.03233, 41.32462]
                ]
            },
            "properties": {
                "popupContent": "Carril bici 2",
                "style": {
                    weight: 5,
                    color: "#2ea122",
                    opacity: 1
                }
            },
            "id": 2
        },
        {
            "type": "Feature",
            "geometry": {
                "type": "LineString",
                "coordinates": [
                    [2.043010, 41.332901],
                    [2.039372, 41.335673],
                    [2.030402, 41.340452],
                    [2.030013, 41.341300],
                    [2.030099, 41.343220],
                    [2.028408, 41.345803],
                    [2.026917, 41.351795],
                    [2.027185, 41.353696],
                    [2.026723, 41.354067],
                    [2.023827, 41.355444]
                ]
            },
            "properties": {
                "popupContent": "Carril bici 3",
                "style": {
                    weight: 5,
                    color: "#2281a1",
                    opacity: 1
                }
            },
            "id": 3
        },
        {
            "type": "Feature",
            "geometry": {
                "type": "LineString",
                "coordinates": [
                    [2.045581, 41.335486],
                    [2.041340, 41.338407],
                    [2.035471, 41.344228],
                    [2.035186, 41.345808]
                ]
            },
            "properties": {
                "popupContent": "Carril bici 4",
                "style": {
                    weight: 5,
                    color: "#d111be",
                    opacity: 1
                }
            },
            "id": 4
        },
        {
            "type": "Feature",
            "geometry": {
                "type": "LineString",
                "coordinates": [
                    [2.030392, 41.342965],
                    [2.030900, 41.343636],
                    [2.031536, 41.343813],
                    [2.032122, 41.344605],
                    [2.033277, 41.345089],
                    [2.035226, 41.345948],
                    [2.036694, 41.347101],
                    [2.037692, 41.348255]
                ]
            },
            "properties": {
                "popupContent": "Carril bici 5",
                "style": {
                    weight: 5,
                    color: "#d68615",
                    opacity: 1
                }
            },
            "id": 5
        },
        {
            "type": "Feature",
            "geometry": {
                "type": "LineString",
                "coordinates": [
                    [2.041609, 41.349123],
                    [2.037614, 41.348319],
                    [2.034587, 41.350795],
                    [2.031520, 41.351070],
                    [2.027798, 41.350394],
                    [2.026184, 41.350034],
                    [2.025047, 41.349575],
                    [2.023538, 41.348667]
                ]
            },
            "properties": {
                "popupContent": "Carril bici 6",
                "style": {
                    weight: 5,
                    color: "#e00b0b",
                    opacity: 1
                }
            },
            "id": 6
        },
        {
            "type": "Feature",
            "geometry": {
                "type": "LineString",
                "coordinates": [
                    [2.032371, 41.324949],
                    [2.028881, 41.327797],
                    [2.039441, 41.335431],
                    [2.041404, 41.338428]
                ]
            },
            "properties": {
                "popupContent": "Carril bici 7",
                "style": {
                    weight: 5,
                    color: "#99590f",
                    opacity: 1
                }
            },
            "id": 7
        }
    ]
};
var incidenciasList = {
    "type": "FeatureCollection",
    "features": [
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.027798, 41.350394]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Incidencia"
            },
            "id": 51
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.041340, 41.338407]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Incidencia"
            },
            "id": 52
        }
    ]
};
var puntosNegrosList = {
    "type": "FeatureCollection",
    "features": [
        {
            "geometry": {
                "type": "MultiPolygon",
                "coordinates": [
                    [
                        [
                            [2.040028, 41.348831],
                            [2.039983, 41.349448],
                            [2.041526, 41.349148],
                            [2.041526, 41.348641]
                        ]
                    ]
                ]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Punto Negro"
            },
            "id": 1
        },
        {
            "geometry": {
                "type": "MultiPolygon",
                "coordinates": [
                    [
                        [
                            [2.034579, 41.345863],
                            [2.035083, 41.346194],
                            [2.035536, 41.345834],
                            [2.035019, 41.345585]
                        ]
                    ]
                ]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Punto Negro"
            },
            "id": 2
        }
    ]
}

var obrasList = {
    "type": "FeatureCollection",
    "features": [
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.02998, 41.35955]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Obra"
            },
            "id": 20
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04852, 41.35095]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Obra"
            },
            "id": 21
        }
        
    ]
};


var talleresList = {
    "type": "FeatureCollection",
    "features": [
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.10546, 41.33432]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 30
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.09804, 41.32523]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 31
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.09323, 41.32301]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 32
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.09310, 41.33107]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 33
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.08945, 41.33181]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 34
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.07492, 41.36572]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 35
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.09551, 41.36768]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 36
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.10032, 41.37129]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 37
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04650, 41.33291]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 38
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.03895, 41.33136]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Taller"
            },
            "id": 39
        }
    ]
};

var parkingList = {
    "type": "FeatureCollection",
    "features": [
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04371, 41.35800]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 40
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.03410, 41.35439]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 41
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04165, 41.35327]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 42
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04646, 41.35298]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 43
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04783, 41.33919]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 44
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.01281, 41.32657]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 45
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.01418, 41.32657]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 46
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04440, 41.35232]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 47
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.01212, 41.32657]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 48
        },
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.02929, 41.32779]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Parking"
            },
            "id": 49
        }
    ]
};

var estacionTrenList = {
    "type": "FeatureCollection",
    "features": [
        {
            "geometry": {
                "type": "Point",
                "coordinates": [2.04302, 41.35748]
            },
            "type": "Feature",
            "properties": {
                "popupContent": "Estacion"
            },
            "id": 50
        }

    ]
};


var carriles = L.layerGroup([]);
var incidencias = L.layerGroup([]);
var puntosNegros = L.layerGroup([]);
var obras = L.layerGroup([]);
var parking = L.layerGroup([]);
var estacionTren = L.layerGroup([]);
var talleres = L.layerGroup([]);


function mostrarMapa() {
    window.L_DISABLE_3D = true;
    //var mymap = L.map('mymap').setView([41.53042945, 1.9402494], 15);

    var osm = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        id: 'osm',
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    });
    var maptiler_satellite = L.tileLayer('https://api.maptiler.com/maps/hybrid/{z}/{x}/{y}.jpg?key=YdMrAsJAp5DIjM1uCn6Q', {
        id: 'maptiler_satellite',
        zoomOffset: -1,
        tileSize: 512,
        attribution: '<a href="https://www.maptiler.com/copyright/" target="_blank">? MapTiler</a> <a href="https://www.openstreetmap.org/copyright" target="_blank">? OpenStreetMap contributors</a>'
    });

    var baseMaps = {
        "Open Street Maps": osm,
        "Satellite": maptiler_satellite
    }

    var overlayMaps = {
        "Carriles": carriles,
        "Incidencias": incidencias,
        "Puntos Negros": puntosNegros,
        "Obras": obras,
        "Talleres": talleres,
        "Parking": parking,
        "Estacion de tren": estacionTren
    };

    var map = L.map('map', {
        center: [41.339909, 2.041107],
        zoom: 14,
        layers: [osm, carriles, incidencias, puntosNegros, obras, parking, estacionTren, talleres], //afegir els layerGroups al mapa
        scrollWheelZoom: false
    });

    $(window).on("resize", function () {
        $("#map").height($(window).height() - 200);
        map.invalidateSize();
    }).trigger("resize");

    //Afegir els mapTiles i els layerGroups a un control per a poder-los activar/desactivar
    L.control.layers(baseMaps, overlayMaps).addTo(map);

    //Crear iconos a mostrar
    var incidenciaIcon = L.icon({
        iconUrl: '/images/warning.png',
        iconSize: [40, 40],
        iconAnchor: [16, 37],
        popupAnchor: [0, -28]
    });
    var obraIcon = L.icon({
        iconUrl: '/images/obra.png',
        iconSize: [40, 40],
        iconAnchor: [16, 37],
        popupAnchor: [0, -28]
    });
    var tallerIcon = L.icon({
        iconUrl: '/images/taller.png',
        iconSize: [40, 40],
        iconAnchor: [16, 37],
        popupAnchor: [0, -28]
    });
    var parkingIcon = L.icon({
        iconUrl: '/images/parking.png',
        iconSize: [40, 40],
        iconAnchor: [16, 37],
        popupAnchor: [0, -28]
    });
    var estacionTrenIcon = L.icon({
        iconUrl: '/images/estacion.png',
        iconSize: [40, 40],
        iconAnchor: [16, 37],
        popupAnchor: [0, -28]
    });

    L.geoJSON(bikeLines, {
        style: function (feature) {
            return feature.properties && feature.properties.style;
        },
        onEachFeature: onEachFeatureBikeLanes
    }).addTo(map);

    L.geoJSON(incidenciasList, {

        onEachFeature: onEachFeatureIncidencias,

        pointToLayer: function (feature, latlng) {
            return L.marker(latlng, { icon: incidenciaIcon });
        }
    }).addTo(map);

    L.geoJSON(puntosNegrosList, {
        style: {
            weight: 2,
            color: "#000000",
            opacity: 0.8,
            fillColor: "#000000",
            fillOpacity: 0.2
        },
        onEachFeature: onEachFeaturePuntosNegros
    }).addTo(map);

    L.geoJSON(obrasList, {

        onEachFeature: onEachFeatureObras,

        pointToLayer: function (feature, latlng) {
            return L.marker(latlng, { icon: obraIcon });
        }
    }).addTo(map);

    L.geoJSON(talleresList, {

        onEachFeature: onEachFeatureTalleres,

        pointToLayer: function (feature, latlng) {
            return L.marker(latlng, { icon: tallerIcon });
        }
    }).addTo(map);

    L.geoJSON(parkingList, {

        onEachFeature: onEachFeatureParking,

        pointToLayer: function (feature, latlng) {
            return L.marker(latlng, { icon: parkingIcon });
        }
    }).addTo(map);

    L.geoJSON(estacionTrenList, {

        onEachFeature: onEachFeatureEstacionTren,

        pointToLayer: function (feature, latlng) {
            return L.marker(latlng, { icon: estacionTrenIcon });
        }
    }).addTo(map);

}

var popupOptions = { 'className': 'customPopUp' };

// Bike Lanes
function onEachFeatureBikeLanes(feature, layer) {
    if (feature.properties && feature.properties.popupContent) {
        var popupContent = feature.properties.popupContent;
    }
    layer.bindPopup(popupContent);
    carriles.addLayer(layer);
}

// Incidencias
function onEachFeatureIncidencias(feature, layer) {
    if (feature.properties && feature.properties.popupContent) {
        var popupContent = feature.properties.popupContent;
    }
    layer.bindPopup(popupContent);
    incidencias.addLayer(layer);
}

//Puntos Negros
function onEachFeaturePuntosNegros(feature, layer) {
    if (feature.properties && feature.properties.popupContent) {
        var popupContent = feature.properties.popupContent;
    }
    layer.bindPopup(popupContent);
    puntosNegros.addLayer(layer);
}

//Obras
function onEachFeatureObras(feature, layer) {
    if (feature.properties && feature.properties.popupContent) {
        var popupContent = feature.properties.popupContent;
    }
    layer.bindPopup(popupContent);
    obras.addLayer(layer);
}

// Talleres
function onEachFeatureTalleres(feature, layer) {
    if (feature.properties && feature.properties.popupContent) {
        var popupContent = feature.properties.popupContent;
    }
    layer.bindPopup(popupContent);
    talleres.addLayer(layer);
}

// Parking
function onEachFeatureParking(feature, layer) {
    if (feature.properties && feature.properties.popupContent) {
        var popupContent = feature.properties.popupContent;
    }
    layer.bindPopup(popupContent);
    parking.addLayer(layer);
}

// Estacion de tren
function onEachFeatureEstacionTren(feature, layer) {
    if (feature.properties && feature.properties.popupContent) {
        var popupContent = feature.properties.popupContent;
    }
    layer.bindPopup(popupContent);
    estacionTren.addLayer(layer);
}

mostrarMapa();

