import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';


class Mape extends StatefulWidget {
  Mape({required this.longitude, required this.latitude}) :super();
  final double longitude;
  final double latitude;

  @override
  _MapeState createState() => _MapeState();
}


class _MapeState extends State<Mape> {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Polyline example',
      theme: ThemeData(
        primarySwatch: Colors.orange,
      ),
      home: MapScreen(widget.latitude, widget.longitude),
    );
  }
}

class MapScreen extends StatefulWidget {
  MapScreen(this.longitude, this.latitude);

  final double longitude;
  final double latitude;

  @override
  _MapScreenState createState() => _MapScreenState();
}

class _MapScreenState extends State<MapScreen> {
  late GoogleMapController mapController;
  Map<MarkerId, Marker> markers = {};
  double latitude = 0;
  double longitude = 0;

  @override
  void initState() {
    super.initState();
    latitude = widget.latitude;
    longitude = widget.longitude;

    /// destination marker
    _addMarker(LatLng(widget.latitude, widget.longitude), "destination",
        BitmapDescriptor.defaultMarkerWithHue(90));
  }


  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
          body:
          // body: latitude == 0 && longitude == 0
          //     ? Center(
          //   child: Column(
          //     mainAxisAlignment: MainAxisAlignment.center,
          //     crossAxisAlignment: CrossAxisAlignment.center,
          //     children: [
          //       Icon(Icons.location_on, size: 46.0, color: Colors.blue),
          //       SizedBox(
          //         height: 10.0,
          //       ),
          //       Text(
          //         'Učitavanje mape...',
          //         style: TextStyle(
          //             fontSize: 26.0, fontWeight: FontWeight.bold),
          //       )
          //     ],
          //   ),
          // )
          GoogleMap(
            initialCameraPosition: CameraPosition(
                target: LatLng(latitude, longitude), zoom: 15),
            myLocationEnabled: true,
            tiltGesturesEnabled: true,
            compassEnabled: true,
            scrollGesturesEnabled: true,
            zoomGesturesEnabled: true,
            onMapCreated: _onMapCreated,
            markers: Set<Marker>.of(markers.values),
          )),
    );
  }

  void _onMapCreated(GoogleMapController controller) {
    mapController = controller;
  }

  _addMarker(LatLng position, String id, BitmapDescriptor descriptor) async {
    MarkerId markerId = MarkerId(id);
    Marker marker =
    Marker(markerId: markerId, icon: descriptor, position: position);
    markers[markerId] = marker;
  }
}

