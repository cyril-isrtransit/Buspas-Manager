
/////////////////////////////////Fonctions/////////////////////////////////





////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////Fonction INIT//////////////////////////////////////


//Div contenant la carte
var mapHover = document.querySelector('#map');

//Couche contenant le heatmap
var heatmapLayer;
var i = 0;
var j = 0;

//Valeur maximale d'intensité
var maxIntensite = 350;

//Tableau des points actif
var dataPoints = new Array;

//Rayon du point dun vehicule
var rayonPoint = 0.0008;

//Fond de carte
var map;

var osmUrl = 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
var osmAttrib = '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, &copy; <a href="http://cartodb.com/attributions">CartoDB</a>';
var osm = new L.TileLayer(osmUrl, { minZoom: 1, maxZoom: 20, attribution: osmAttrib });


var tooltip = document.querySelector('.tooltip2');

//Configuration normale
var cfg = {
    scaleRadius: true,
    useLocalExtrema: true,
    latField: 'lat',
    lngField: 'lng',
    valueField: 'count',
    blur: 0.9
};


//Couche points normaux
heatmapLayer = new HeatmapOverlay(cfg);

//Definition de la map principale
map = new L.map('map', {
    center: new L.LatLng(25.7742700, -80.1936600),
    zoom: 14,
    layers: [osm, heatmapLayer]
});





//Fonction appelé pour rafraichir toute la map
function refresh_map() {
    //chargement des donnees en ajax
    $.ajax({
        url: "/HeatMap/Get_Liste_Coordonne/",
        type: "POST",
        dataType: "json",
        success: function (result) {
            switch (result) {
                case true:
                    processResponse(result);
                    break;
                default:
                    j = 0;

                    //Nettoyage des tableaux
                    while (dataPoints.length > 0) {
                        dataPoints.pop();
                    }

                    for (i in result) {
                        if (result[i].Lat != null && result[i].Lon != null){
                            var dataPoint = { lat: result[i].Lat, lng: result[i].Lon, radius: .0002 };
                            dataPoints[j] = dataPoint;
                            j++;
                        }
                    }

                    //Si il existe des point actifs
                    if (dataPoints.length > 0) {
                        var data = { data: dataPoints };
                        heatmapLayer.setData(data);
                    }

                    //On redessine
                    heatmapLayer._draw();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //alert(xhr.status);
            //alert(thrownError);
        }
    });
}




//Fonction d'initialisation
function initMap() {
    
    //Premier appel de la fonction pour affichage
    refresh_map();

    setInterval(function () {
        //chargement des donnees en ajax
        $.ajax({
            url: "/HeatMap/Get_Liste_Coordonne/",
            type: "POST",
            dataType: "json",
            success: function (result) {
                switch (result) {
                    case true:
                        processResponse(result);
                        break;
                    default:
                        j = 0;

                        //Nettoyage des tableaux
                        while (dataPoints.length > 0) {
                            dataPoints.pop();
                        }

                        for (i in result) {
                            var dataPoint = { lat: result[i].Lat, lng: result[i].Lon, radius: .0002};
                            dataPoints[j] = dataPoint;
                            j++;
                        }

                        //Si il existe des point actifs
                        if (dataPoints.length > 0) {
                            var data = { max: maxIntensite, data: dataPoints };
                            heatmapLayer.setData(data);
                        }

                        //On redessine
                        heatmapLayer._draw();
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                //alert(xhr.status);
                //alert(thrownError);
            }
        });

    }, 20000);


    //Ajout de l'indicateur de coordonnees
    L.control.coordinates({
        position: "topright"
    }).addTo(map);

}

