import 'dart:convert';
import 'package:treatbeauty/models/MdlServiceInSalon.dart';
class MdlCustom {
  final int salonId;
  final String salonName;
  final String cityName;
  final String location;
  final List<int> salonPhoto;
  final List<MdlServiceInSalon> services;
  MdlCustom({
    required this.salonId,
    required this.location,
    required this.salonName,
    required this.cityName,
    required this.salonPhoto,
    required this.services,
  });
  factory MdlCustom.fromJson(Map<String, dynamic> json) {
    String stringByte = json["salonPhoto"] as String;
    List<int> bytes = base64.decode(stringByte);
    var data  = json['services'] as List;
    var a = data.map((e) => MdlServiceInSalon.fromJson(e)).toList();
    return MdlCustom(
        salonId: json["salonId"],
        salonName: json["salonName"],
        cityName: json["cityName"],
        salonPhoto: bytes,
        location : json["location"],
        services : a
    );
  }
}