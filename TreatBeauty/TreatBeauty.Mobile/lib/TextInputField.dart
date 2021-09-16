import 'package:flutter/material.dart';
import 'package:treatbeauty/pallete.dart';
import 'package:treatbeauty/services/APIService.dart';


class TextInputField extends StatelessWidget {
  const TextInputField({
    required this.icon,
    required this.hint,
    required this.inputType,
    required this.inputAction,
    required this.message,
  }) : super();

  final Icon icon;
  final String hint;
  final TextInputType inputType;
  final TextInputAction inputAction;
  final String message;

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 10.0),
      child: Container(
        height: size.height * 0.08,
        width: size.width * 0.8,
        child: Center(
          child: TextFormField(
            onChanged: (txt){
              if (hint == 'UserName'){
                APIService.username = txt;
              }
              if (hint == 'Email'){
                APIService.username = txt;
              }
              if (hint == 'LastName'){
                APIService.lastName = txt;
              }
              if (hint == 'FirstName'){
                APIService.firstName = txt;
              }
            },
            validator: (value) {
              if (value == null || value.isEmpty) {
                return message;
              }
              return null;
            },
            decoration: InputDecoration(
              border: UnderlineInputBorder(
                borderSide: BorderSide(width: 1, color: Colors.grey),
              ),
              errorStyle: TextStyle(color: Colors.pink[100],fontWeight: FontWeight.bold,fontSize: 14),
              prefixIcon: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20.0),
                child: Icon(
                  icon.icon,
                  size: 28,
                  color: kWhite,
                ),
              ),
              hintText: hint,
              hintStyle: kBodyText,
            ),
            style: kBodyText,
            keyboardType: inputType,
            textInputAction: inputAction,
          ),
        ),
      ),
    );
  }
}
