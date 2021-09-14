import 'dart:convert';

class MdlTerm {
  final String? serviceName;
  final String start;
  final String end;
  final String date;
  final bool reserved;
  final int? serviceId;
  final int? customerId;
  final int? employeeId;

  MdlTerm({
    required this.serviceName,
    required this.start,
    required this.end,
    required this.date,
    required this.reserved,
    required this.serviceId,
    required this.customerId,
    required this.employeeId,
  });

  factory MdlTerm.fromJson(Map<String, dynamic> json) {
    return MdlTerm(
      serviceName: json["serviceName"],
      start: json["start"] ,
      end: json["end"],
      date: DateTime.parse(json["date"]).toString(),
      reserved: json["reserved"],
      serviceId: json["serviceId"],
      customerId: json["customerId"],
      employeeId: json["employeeId"]
    );
  }
}