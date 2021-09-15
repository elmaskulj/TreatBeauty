import 'dart:convert';

class MdlBaseUser {
  final int id;

MdlBaseUser({
    required this.id,
  });

  factory MdlBaseUser.fromJson(Map<String, dynamic> json) {
    return MdlBaseUser(
      id: json["id"]
    );
  }
}