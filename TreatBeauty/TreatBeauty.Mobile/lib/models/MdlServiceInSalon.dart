class MdlServiceInSalon {
  final int serviceId;
  final String serviceName;
  final double servicePrice;
  final String termDate;
  final int termId;
  MdlServiceInSalon({
    required this.serviceId,
    required this.serviceName,
    required this.servicePrice,
    required this.termDate,
    required this.termId,
  });
  factory MdlServiceInSalon.fromJson(Map<String, dynamic> json) {
    return MdlServiceInSalon(
        serviceId: json["serviceId"],
        serviceName: json["serviceName"],
        servicePrice: json["servicePrice"],
        termDate: DateTime.parse(json["termDate"]).toString(),
        termId : json["termId"]
    );
  }
}