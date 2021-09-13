import 'dart:convert';

class MdlNews {
  final int id;
  final String title;
  final String description;
  final String createdAt;
  final bool active;
  final int salonId;
  final List<int> photo;

  MdlNews({
    required this.id,
    required this.title,
    required this.photo,
    required this.description,
    required this.salonId,
    required this.createdAt,
    required this.active
  });

  factory MdlNews.fromJson(Map<String, dynamic> json) {
    String stringByte = json["photo"] as String;
    List<int> bytes = base64.decode(stringByte);
    return MdlNews(
      id: json["id"],
      title: json["title"],
      photo: bytes,
      description: json["description"],
      active: json["active"],
      salonId: json["salonId"],
      createdAt: DateTime.parse(json["createdAt"]).toString(),
    );
  }
}