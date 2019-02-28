<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lwm.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="icon" href="data:;base64,iVBORw0KGgo=" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.4.0/leaflet.css" />
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.2/css/bootstrap-select.min.css" />
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/leaflet.draw/1.0.4/leaflet.draw.css" />
    <link rel="stylesheet"
        href="scripts/leaflet-icon-pulse-master/dist/L.Icon.Pulse.css" />
    <style>
        .animated-icon-red{
          background-color: rgba(255, 0, 0, 0.7) !important;
        }
        .animated-icon-yellow{
          background-color: rgba(255, 216, 0, 0.7) !important;
        }
        .animated-icon-green{
          background-color: rgba(0, 255, 33, 0.7) !important;
        }
    </style>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"
        integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
        crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.4.0/leaflet.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/leaflet.draw/1.0.4/leaflet.draw.js"></script>
    <script
        src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.2/js/bootstrap-select.min.js">
    </script>
    <script src="scripts/leaflet-icon-pulse-master/dist/L.Icon.Pulse.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.24.0/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.24.0/locale/tr.js"></script>
    
    <script src="<%= ResolveClientUrl("~/scripts/jquery.signalR-2.4.0.min.js") %>" ></script>
    <script src="<%= ResolveClientUrl("~/signalr/hubs") %>" ></script>
    
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="row">
                    <div class="form-group">
                        <label for="labelUserName">User Name</label>
                        <input class="form-control"
                            id="inputUserName" aria-describedby="labelUserName" />
                        <small id="userIdHelp" class="form-text text-muted">User Name.
                        </small>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label for="labelLat">Lat</label>
                        <input type="number" class="form-control"
                            id="inputLat" aria-describedby="latHelp"
                            pattern="^\d*(\.\d{0,2})? Lat"
                            placeholder="Latitude"
                            readonly />
                        <small id="latHelp" class="form-text text-muted">Clicked Latitude point on map.
                        </small>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label for="labelLon">Lon</label>
                        <input type="number" class="form-control"
                            id="inputLon" aria-describedby="lonHelp"
                            pattern="^\d*(\.\d{0,2})? Lon"
                            placeholder="Longitude"
                            readonly />
                        <small id="LonHelp" class="form-text text-muted">Clicked Longitude point on map.
                        </small>
                    </div>
                </div>
                <div class="row">
                    <%--<select class="selectpicker" id="selectMType">
                    </select>--%>

                    <div class="form-group">
                        <label for="selectMType">Select Type</label>
                        <select class="form-control" id="selectMType">
                            <option value="1">Info</option>
                            <%--sarı--%>
                            <option value="2">Error</option>
                            <%--kırmızı--%>
                            <option value="3">OK</option>
                            <%--yeşil--%>
                        </select>
                    </div>

                </div>
                <div class="row">
                    <label for="labelTimeout">Timeout</label>
                    <input type="number" class="form-control"
                        id="inputTimeout" aria-describedby="helpTimeout"
                        placeholder="Timeout (seconds)" />
                    <small id="helpTimeout" class="form-text text-muted">Timeout seconds for clear marker.
                    </small>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <button class="btn btn-danger" id="btnSend">Send!</button>
                    </div>
                    <div class="col-md-6">
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="media mt-3 shadow-textarea">
                            <div class="form-group basic-textarea rounded-corners">
                                <textarea class="form-control z-depth-1" id="textServerLogs"
                                    rows="10" placeholder="Server logs..."
                                    style="width: 100%; height: 100%; min-height: 100px; min-width: 400px;"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div id="mapDiv" style="width: 100%">
                </div>
            </div>
        </div>
    </div>
    <script src="<%= ResolveClientUrl("~/scripts/App.js") %>?v=<%Response.Write(DateTime.Now.ToString("yyyyMMddHHmmss"));%>"></script>
    <script>
        $(document).ready(function () {
            App.Startup();
        });
    </script>
</body>
</html>
