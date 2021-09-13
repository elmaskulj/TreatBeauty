import 'dart:convert';

class MdlCategory {
  final int id;
  final String name;
  final List<int> photo;

  MdlCategory({
    required this.id,
    required this.name,
    required this.photo,
  });

  factory MdlCategory.fromJson(Map<String, dynamic> json) {
    String stringByte = json["photo"] as String;
    List<int> bytes = base64.decode(stringByte);
    return MdlCategory(
      id: json["id"],
      name: json["name"],
      photo: bytes,
    );
  }
}