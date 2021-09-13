import 'package:treatbeauty/models/MdlServices.dart';

class MdlSalonServices {
  final int salonServicesId;
  final int salonId;
  final int serviceId;

  MdlSalonServices({
    required this.salonServicesId,
    required this.salonId,
    required this.serviceId,
  });

  factory MdlSalonServices.fromJson(Map<String, dynamic> json) {
    return MdlSalonServices(
      salonServicesId: json["salonServicesId"],
      salonId: json["salonId"],
      serviceId: json["serviceId"],
    );
  }
}