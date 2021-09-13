import 'dart:convert';

class MdlCustom {
  final int terminId;
  final int salonId;
  final String salonName;
  final String cityName;
  final List<int> salonPhoto;
  final String serviceName;
  final double? servicePrice;
  final int serviceId;
  final String termDate;

  MdlCustom({
    required this.terminId,
    required this.salonId,
    required this.salonName,
    required this.cityName,
    required this.salonPhoto,
    required this.serviceName,
    required this.servicePrice,
    required this.serviceId,
    required this.termDate,
  });

  factory MdlCustom.fromJson(Map<String, dynamic> json) {
    String stringByte = json["salonPhoto"] as String;
    List<int> bytes = base64.decode(stringByte);
    return MdlCustom(
      terminId: json["terminId"],
      salonId: json["salonId"],
      salonName: json["salonName"],
      cityName: json["cityName"],
      salonPhoto: bytes,
      serviceName : json["serviceName"],
      servicePrice : json["servicePrice"],
      serviceId : json["serviceId"],
      termDate: DateTime.parse(json["termDate"]).toString(),
    );
  }
}