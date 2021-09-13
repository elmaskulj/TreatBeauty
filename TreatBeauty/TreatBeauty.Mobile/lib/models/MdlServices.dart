import 'dart:convert';

class MdlServices {
  final int id;
  final String? name;
  final double? price;
  final double? duration;
  final List<int>? photo;
  final int categoryId;

  MdlServices({
    required this.id,
     this.name,
     this.price,
     this.duration,
     this.photo,
    required this.categoryId
  });

  factory MdlServices.fromJson(Map<String, dynamic> json) {
    String stringByte = json["photo"] as String;
    List<int> bytes = base64.decode(stringByte);
    return MdlServices(
        id: json["id"],
        name: json["name"],
        price: json["price"],
        duration: json["duration"],
        photo: bytes,
        categoryId : json["categoryId"],
    );
  }
}