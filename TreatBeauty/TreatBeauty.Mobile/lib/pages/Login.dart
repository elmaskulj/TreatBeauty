import 'package:flutter/material.dart';
import 'package:treatbeauty/PasswordInput.dart';
import 'package:treatbeauty/TextInputField.dart';
import 'package:treatbeauty/models/MdlBaseUser.dart';
import 'package:treatbeauty/pages/Register.dart';
import 'package:treatbeauty/pallete.dart';
import 'package:treatbeauty/services/APIService.dart';

String? validateInputText(String text) {
  if (text.length == 0) return 'Username is required';
  return null;
}

String? validatePassword(String text) {
  if (text.length == 0) return 'Password is required';
  return null;
}

var result;
var resultCustomer;
GlobalKey<FormState> _formKeyLogin = new GlobalKey<FormState>();

class Login extends StatefulWidget {
  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Stack(
      children: [
        Container(
          decoration: BoxDecoration(
              image: DecorationImage(
                  image: AssetImage('assets/beauty.png'),
                  fit: BoxFit.fitWidth,
                  colorFilter:
                  ColorFilter.mode(Colors.black54, BlendMode.darken))),
        ),
        Form(
          key: _formKeyLogin,
          child: Scaffold(
            backgroundColor: Colors.transparent,
            body: Column(
              children: [
                Flexible(
                  child: Center(),
                ),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: [
                    TextInputField(
                        icon: Icon(Icons.supervised_user_circle),
                        hint: 'UserName',
                        inputType: TextInputType.name,
                        inputAction: TextInputAction.next,
                        message: 'Molimo unesite svoje korisničko ime'),
                    PasswordInput(
                        icon: Icon(Icons.lock_open),
                        hint: 'Password',
                        inputAction: TextInputAction.next,
                        inputType: TextInputType.name),
                    Container(
                      height: size.height * 0.08,
                      width: size.width * 0.8,
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(16),
                        color: Colors.pinkAccent[200],
                      ),
                      child: TextButton(
                        onPressed: () async {
                          if (_formKeyLogin.currentState!.validate()) {
                            await get();
                            if (result != null && resultCustomer != null) {
                              Navigator.of(context)
                                  .pushReplacementNamed('/home');
                            }
                            if (result == null &&
                                APIService.username != "" &&
                                APIService.password != "") _showDialog(context);
                            result = null;
                          }
                        },
                        child: Text(
                          'Login',
                          style:
                          kBodyText.copyWith(fontWeight: FontWeight.bold),
                        ),
                      ),
                    ),
                    SizedBox(
                      height: 25,
                    ),
                  ],
                ),
                GestureDetector(
                  onTap: () => {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => Register()),
                    ),
                    APIService.username = '',
                    APIService.password = ''
                  },
                  child: Container(
                    child: Text(
                      'Kreiraj novi nalog',
                      style: kBodyText,
                    ),
                    decoration: BoxDecoration(
                        border: Border(
                            bottom: BorderSide(width: 1, color: kWhite))),
                  ),
                ),
                SizedBox(
                  height: 20,
                ),
              ],
            ),
          ),
        )
      ],
    );
  }
}

void _showDialog(BuildContext context) {
  showDialog(
    context: context,
    builder: (BuildContext context) {
      return AlertDialog(
        title: new Text("Greška!!"),
        content: new Text("Pogrešan username ili password"),
        actions: <Widget>[
          // ignore: deprecated_member_use
          new FlatButton(
            child: new Text("OK"),
            onPressed: () {
              Navigator.of(context).pop();
            },
          ),
        ],
      );
    },
  );
}

Future<int?> fetchKorisnik() async {
  Map<String,String> queryParams = {'Email': APIService.username};
  var korisnik = await APIService.Get('Customer', queryParams );
  if (korisnik != null)
    return korisnik.map((e) => MdlBaseUser.fromJson(e)).first.id;
  else
    return null;
}

Future<void> get()async{
  if (APIService.username != "" && APIService.password != ""){
    result = await APIService.Get('BaseUser', null);
    resultCustomer = await fetchKorisnik();
  }
}

