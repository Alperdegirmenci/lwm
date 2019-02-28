App = {
    DefaultValues: {
        Latitude: 39,
        Longitude: 32,
        Zoom: 6
    },
    BaseMaps: {
        basarMap: L.tileLayer("http://bms.basarsoft.com.tr/Service/api/v1/map/promap?z={z}&x={x}&y={y}", {
            maxZoom: 20,
            attribution: "Başarsoft BMS"
        }),
        gmapSatellite: L.tileLayer("https://{s}.google.com/vt/lyrs=y&x={x}&y={y}&z={z}", {
            maxZoom: 20,
            subdomains: ["mts0", "mts1", "mts2", "mts3"],
            attribution: "Başarsoft"
        }),
        googleSat: L.tileLayer("http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}", {
            maxZoom: 20,
            subdomains: ["mts0", "mts1", "mts2", "mts3"],
            attribution: "Başarsoft"
        }),
        atlas: L.tileLayer("https://{s}.harita.gov.tr/wms/ortofoto/ortho_layer/{z}/{x}/{y}.jpg", {
            maxZoom: 24,
            subdomains: ["atlast1", "atlast2", "atlast3", "atlast4"],
            attribution: "Başarsoft"
        }),
    },
    Map: null,
    DrawnFeatures: null,
    ServerFeatures: null,
    SignalRMapHub: null,
    ReSizeTimer:null,
    DTO: {
        DTOMapPoint: function () {
            return {
                Id: -1,
                UserName: "",
                Lon: -1,
                Lat: -1,
                Type: -1,
                TimeOut: -1
            }
        }
    }
};

App.InitSignalR = function () {
    App.SignalRMapHub = $.connection.hub;
    App.SignalRMapHub.proxies.maphub.client.receiveNotification = function (message) {

        App.ParseAddMarker(JSON.parse(message));

        message = '\n' +
            moment().format('MMMM Do YYYY, h:mm:ss a') + ':' + message;
        $('#textServerLogs').appendVal(message);
    };
    App.SignalRMapHub.start();
};

App.Startup = function () {
    App.InitMap();
    App.InitControls();
    App.InitSignalR();
};

App.InitMap = function () {
    App.Map = L.map("mapDiv", {
        zoom: App.DefaultValues.Zoom,
        maxZoom: 20,
        center: new L.LatLng(
            App.DefaultValues.Latitude,
            App.DefaultValues.Longitude),
        layers: [App.BaseMaps.atlas]
    });

    App.DrawnFeatures = L.featureGroup().addTo(App.Map);
    App.ServerFeatures = L.featureGroup().addTo(App.Map);
    
    L.control.layers(App.BaseMaps,
        {
            'Gönderilenler': App.DrawnFeatures,
            'Alınanlar': App.ServerFeatures
        }).addTo(App.Map);

    App.Map.addControl(new L.Control.Draw({
        edit: {
            featureGroup: App.DrawnFeatures,
            edit: true
        }
    }));

    App.Map.on(L.Draw.Event.CREATED, App.FinishMapProcess);
    App.Map.on(L.Draw.Event.EDITED, App.FinishMapProcess);

    $(window).resize(function () {
        clearTimeout(App.ReSizeTimer);
        App.ReSizeTimer = setTimeout(function () {
            App.RefreshMapSize();
        }, 250);
    })

    App.RefreshMapSize();
};

App.FinishMapProcess = function (event) {
    var layer = null;
    if (event.type === "draw:edited") {
        var layers = event.layers;
        layers.eachLayer(function (ll) {
            if (ll instanceof L.Marker) {
                layer = ll;
            }
        });
    }
    else {
        if (event.layerType === "marker") 
            layer = event.layer;
    }
    if (layer != null) {
        $('#inputLon')[0].value = layer._latlng.lng;
        $('#inputLat')[0].value = layer._latlng.lat;
        App.DrawnFeatures.addLayer(layer);
    }
    else
        alert("Sadece nokta ekleyiniz!");
}

App.InitControls = function () {
    $('#btnSend').click(function () {
        App.Send();
    });

    $.fn.appendVal = function (TextToAppend) {
        return $(this).val(
            TextToAppend + $(this).val() 
        );
    };
};

App.Send = function () {
    if ($('#inputLon')[0].value.trim() === "" || $('#inputLat')[0].value.trim() === "")
        return;
    
    var DTOMapPoint = new App.DTO.DTOMapPoint();
    DTOMapPoint.Id = -1;
    DTOMapPoint.UserName = $('#inputUserName')[0].value;
    DTOMapPoint.Lon = $('#inputLon')[0].value;
    DTOMapPoint.Lat = $('#inputLat')[0].value;
    DTOMapPoint.Type = $('#selectMType')[0].value;
    DTOMapPoint.TimeOut = $('#inputTimeout')[0].value.trim() === "" ? -1 : $('#inputTimeout')[0].value.trim();
    DTOMapPoint = { 'DTOMapPoint': DTOMapPoint };
    App.AsyncMethodCallWithUrl('default.aspx/InsertPoint',
        App.onSuccessSend,
        DTOMapPoint,
        App.onErrorAjaxMethodCall);
};

App.ParseAddMarker = function (jsonMarker) {
    var pulsingIcon = L.icon.pulse({
        iconSize: [20, 20],
        color: jsonMarker.Type === 1 ? 'yellow' : jsonMarker.Type === 2 ? 'red' : 'green',
        fillColor: jsonMarker.Type === 1 ? 'rgba(255, 216, 0, 0.5)' : jsonMarker.Type === 2 ? 'rgba(255, 0, 0, 0.5)' : 'rgba(0, 255, 33, 0.5)',
        totalcount: jsonMarker.Timeout
    });
    
    var marker = L.marker([jsonMarker.Lat, jsonMarker.Lon], { icon: pulsingIcon });
    
    marker.addTo(App.ServerFeatures)
        .bindPopup(JSON.stringify(jsonMarker, null, '\t'))
        .openPopup();
}

App.onSuccessSend = function (data) {
    if (data.d) {
        if (data.d.ResultCode === 200) {
            App.ParseAddMarker(data.d);
            App.SignalRMapHub.proxies.maphub.server.send(
                $('#inputUserName')[0].value,
                JSON.stringify(data.d));
            App.DrawnFeatures.clearLayers();
        }
        else {
            
        }
    }
};

App.RefreshMapSize = function () {
    $("#mapDiv").css({ "height": $(document).height() });
    $("#mapDiv").css({ "width": ($(document).width() / 2) - 16 });
    App.Map.invalidateSize();
};

App.AsyncMethodCallWithUrl = function (url, onSuccesFunction, params, onErrorFunction) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccesFunction,
        error: onErrorFunction
    });
};

App.onErrorAjaxMethodCall = function (e, x, settings, exception, callback) {
    var message;
    var statusErrorMap = {
        '400': "Server understood the request, but request content was invalid.",
        '401': "Unauthorized access.",
        '403': "Forbidden resource can't be accessed.",
        '500': "Internal server error.",
        '503': "Service unavailable."
    };
    if (x.status) {
        message = statusErrorMap[x.status];
        if (!message) {
            message = "Unknown Error \n.";
        }
    } else if (exception === 'parsererror') {
        message = "Error.\nParsing JSON Request failed.";
    } else if (exception === 'timeout') {
        message = "Request Time out.";
    } else if (exception === 'abort') {
        message = "Request was aborted by the server";
    } else {
        message = "Unknown Error \n.";
        return;
    }
    alert(message);
};
