import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:jiffy/jiffy.dart';
import 'package:treatbeauty/models/MdlSalon.dart';
import 'package:treatbeauty/pages/MapScreen.dart';
import 'package:treatbeauty/services/APIService.dart';
import 'package:treatbeauty/services/Payment.dart';

class Rezervacija extends StatefulWidget {
  final String serviceName;
  final String start;
  final String date;
  final String salonName;
  final int salonId;
  final double price;
  const Rezervacija({Key? key,required this.serviceName,required this.price,required this.start,required this.date,required this.salonName,required this.salonId}) : super(key: key);
  @override
  _RezervacijaState createState() => _RezervacijaState();
}

TextEditingController controller = new TextEditingController();

Future<MdlSalon> fetchSalon(salonId) async {
  var salon  = await APIService.GetById('Salon', salonId);
  return MdlSalon.fromJson(salon);
}


class _RezervacijaState extends State<Rezervacija> {
  void payWithCard({required int amount}) async{
    var response =
    await StripeService.payWithNewCard(amount: amount.toString(), currency: 'BAM');
    final snackBar;
    print(response.message);
    if(response.message == 'Transaction cancelled'){
      snackBar = SnackBar(
        duration: Duration(
            milliseconds: response.success == false ? 1200 : 3000
        ),
        content: Text(response.success == true ? response.message : 'Transakcija otkazana'),
      );
    }
    else{
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Row(children: [
          CircularProgressIndicator(),
          Container(margin: EdgeInsets.only(left: 15),child:Text("Molimo pričekajte...")),
        ],),duration: Duration(seconds: 5),),
      );
      snackBar = SnackBar(
        duration: Duration(
            milliseconds: response.success == false ? 1200 : 3000
        ),
        content: Text(response.success == true ? response.message : 'Transakcija uspješna'),
      );
      // Map<String, dynamic> body = {
      //   'datum': DateTime.parse(DateTime.now().toString()).toIso8601String(),
      //   'korisnikId': logovaniKorisnik,
      //   "iznos" : double.parse(_controller.text),
      //   "akcijaId" : widget.akcija.id,
      // };
      // await APIService.Post('Donacija', body);
    }
    ScaffoldMessenger.of(context).showSnackBar(snackBar);
  }

  showConfirmAlertDialog(BuildContext context) {
    Widget cancelButton = TextButton(
      child: Text("No"),
      onPressed:  () {
        Navigator.of(context).pop();
      },
    );
    Widget continueButton = TextButton(
      child: Text("Yes"),
      onPressed:  () async {
        double controllerInt = double.parse(controller.text);
        double amountInCents = controllerInt * 1000;
        int integerAmount = (amountInCents/10).ceil();
        Navigator.of(context).pop();
        payWithCard(amount: integerAmount);
        controller.clear();
      },
    );

    AlertDialog alert = AlertDialog(
      title: Text("Unesite iznos"),
      content: TextField(
        keyboardType: TextInputType.number,
        controller: controller,
      ),
      actions: [
        cancelButton,
        continueButton,
      ],
    );

    // show the dialog
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return alert;
      },
    );
  }

  @override
  void initState(){
    super.initState();
    StripeService.init();
  }
  Widget build(BuildContext context) {
    var date = Jiffy(widget.date).yMMMMd;
    return Scaffold(
      resizeToAvoidBottomInset: false,
      appBar: AppBar(
        title: Text('Rezervacija'),
        backgroundColor: Colors.pink[200],
      ),
      body: Column(children: [
        Container(
          child: Row(
            children: [
              Padding(
                padding: EdgeInsets.only(left: 10),
                child: Icon(
                  Icons.date_range,
                  size: 120,
                  color: Colors.grey,
                ),
              ),
              Expanded(child: Text('Potvrđeno zakazivanje termina',style: TextStyle(fontSize: 25,color: Colors.grey),)),
            ],
          ),
          height: 200,
          width: MediaQuery.of(context).size.width,
          decoration: BoxDecoration(
            border: Border.all(color: Colors.grey, width: 3),
          ),
        ),
        SizedBox(height: 20),
        Padding(
          padding: EdgeInsets.only(left: 20),
          child: Align(
            alignment: Alignment.centerLeft,
            child: Text(
              widget.salonName,
              style: TextStyle(fontSize: 24, color: Colors.grey),
            ),
          ),
        ),
        SizedBox(height: 20),
        Row(children: [
          Padding(
              padding: EdgeInsets.only(left: 20),
              child: Text(
                widget.start,
                style: TextStyle(
                    fontSize: 30,
                    color: Colors.black,
                    fontWeight: FontWeight.bold),
              )),
          Padding(
            padding: EdgeInsets.only(left: 40),
            child: Container(
              height: 50,
              width: 1,
              color: Colors.grey,
            ),
          ),
          Padding(
              padding: EdgeInsets.only(left: 40),
              child: Text(
                date,
                style: TextStyle(
                  fontSize: 15,
                  color: Colors.grey,),
              )),
        ]),
        Padding(
          padding: EdgeInsets.only(top: 15),
          child: Container(
            height: 1,
            width: MediaQuery.of(context).size.width * 0.9,
            color: Colors.grey,
          ),
        ),
        SizedBox(height: 40,),
        Padding(
          padding: EdgeInsets.only(left: 20),
          child: Align(
            alignment: Alignment.centerLeft,
            child: Text(
              widget.serviceName + ' - ' + widget.price.toString() + 'KM',
              style: TextStyle(
                fontSize: 20,
                color: Colors.grey,),
            ),
          ),
        ),
        SizedBox(height: 20,),
        Container(
          height: 55,
          width: MediaQuery.of(context).size.width * 0.95,
          // ignore: deprecated_member_use
          child: RaisedButton(
            onPressed: (){
              showConfirmAlertDialog(context);
            },
            child: Center(
              child: Text(
                'Uplatite termin',
                style: TextStyle(fontSize: 20, color: Colors.grey),
              ),
            ),
          ),
        ),
        SizedBox(
          height: 10,
        ),
        InkWell(
          onTap: () async{
            MdlSalon salon = await fetchSalon(widget.salonId);
            Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (context) =>
                      Mape(longitude: salon.lat, latitude: salon.lng)
              ),
            );
          },
          child: Container(
              height: 100,
              decoration: BoxDecoration(
                  image: DecorationImage(
                    fit: BoxFit.fitWidth,
                    image: AssetImage('assets/gm.png'),
                  ))),
        ),
      ]),
    );
  }
}


