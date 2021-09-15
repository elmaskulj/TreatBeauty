import 'dart:convert';

class MdlCoupon {
  final int id;
  final String title;
  final double value;

  MdlCoupon({
    required this.id,
    required this.title,
    required this.value,
  });

  factory MdlCoupon.fromJson(Map<String, dynamic> json) {
    return MdlCoupon(
      id: json["id"],
      title: json["title"],
      value: json["value"],
    );
  }
}