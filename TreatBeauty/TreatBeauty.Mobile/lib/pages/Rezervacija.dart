
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class Rezervacija extends StatefulWidget {
  @override
  _RezervacijaState createState() => _RezervacijaState();
}

class _RezervacijaState extends State<Rezervacija> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Rezervacija'),
        backgroundColor: Colors.pink[200],
      ),
      body: Column(children: [
        Container(
          height: 400,
          child: CupertinoDatePicker(
            minimumDate: DateTime.now(),
            initialDateTime: DateTime.now(),
            onDateTimeChanged: (DateTime value) {},
          ),
        ),
        Container(
          height: 75,
          // ignore: deprecated_member_use
          child: RaisedButton(
            onPressed: () async {},
            color: Colors.pink[200],
            child: Center(
              child: Text(
                'Zakažite termin',
                style: TextStyle(fontSize: 23, color: Colors.white),
              ),
            ),
          ),
        )
      ]),
    );
  }
}

