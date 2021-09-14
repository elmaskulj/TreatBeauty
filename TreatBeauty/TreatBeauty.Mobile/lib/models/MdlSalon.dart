import 'dart:convert';

class MdlSalon {
  final int id;
  final String name;
  final String description;
  final String createdAt;
  final String location;
  final int cityId;
  final List<int> photo;
  final double lat;
  final double lng;

  MdlSalon({
    required this.id,
    required this.name,
    required this.photo,
    required this.description,
    required this.cityId,
    required this.createdAt,
    required this.location,
    required this.lat,
    required this.lng,
  });

  factory MdlSalon.fromJson(Map<String, dynamic> json) {
    String stringByte = json["photo"] as String;
    List<int> bytes = base64.decode(stringByte);
    return MdlSalon(
      id: json["id"],
      name: json["name"],
      photo: bytes,
      description: json["description"],
      location: json["location"],
      cityId: json["cityId"],
      lat: json["lat"],
      lng: json["lng"],
      createdAt: DateTime.parse(json["createdAt"]).toString(),
    );
  }
}