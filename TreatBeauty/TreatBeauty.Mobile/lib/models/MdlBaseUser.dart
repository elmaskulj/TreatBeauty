import 'dart:convert';

class MdlBaseUser {
  final int id;
  final String email;
  final String phoneNumber;
  final String firstName;
  final String lastName;

MdlBaseUser({
    required this.id,
    required this.email,
    required this.firstName,
    required this.lastName,
    required this.phoneNumber,
  });

  factory MdlBaseUser.fromJson(Map<String, dynamic> json) {
    return MdlBaseUser(
      id: json["id"],
      email: json["email"],
      firstName: json["firstName"],
      lastName: json["lastName"],
      phoneNumber: json["phoneNumber"],
    );
  }
}