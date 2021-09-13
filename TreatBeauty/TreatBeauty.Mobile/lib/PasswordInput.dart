import 'package:flutter/material.dart';
import 'package:treatbeauty/pallete.dart';
import 'package:treatbeauty/services/APIService.dart';


class PasswordInput extends StatelessWidget {
  const PasswordInput({
    required this.icon,
    required this.hint,
    required this.inputType,
    required this.inputAction,
  }) : super();

  final Icon icon;
  final String hint;
  final TextInputType inputType;
  final TextInputAction inputAction;

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
            validator: (value) {
              if(icon.icon.toString() == 'IconData(U+0E3B0)' && value!.isNotEmpty)
                return null;

              if(hint == 'Password' && value!.length>0 && value.length< 6) return 'Lozinka mora biti duža od 6 karaktera';

              if (value == null || value.isEmpty) {
                return 'Molimo unesite vašu lozinku';
              }
              else if(APIService.password != APIService.confirmPassword){
                return 'Lozinke moraju biti iste';
              }
              return null;
            },
            onChanged: (txt){
              if (hint == "Password") APIService.password = txt;
              if (hint == "Confirm Password") APIService.confirmPassword = txt;
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
            obscureText: true,
            style: kBodyText,
            keyboardType: inputType,
            textInputAction: inputAction,
          ),
        ),
      ),
    );
  }
}