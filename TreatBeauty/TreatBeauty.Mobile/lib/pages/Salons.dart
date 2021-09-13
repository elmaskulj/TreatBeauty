import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:treatbeauty/models/MdlNews.dart';
import 'package:treatbeauty/models/MdlSalon.dart';
import 'package:treatbeauty/services/APIService.dart';
import 'package:jiffy/jiffy.dart';

class Salon extends StatefulWidget {
  final MdlSalon salon;

  const Salon({Key? key, required this.salon}) : super(key: key);

  @override
  _SalonState createState() => _SalonState();
}

Future<List<MdlNews>> fetchSalons(salonId) async {
  Map<String,String> queryParams = {'SalonId': salonId.toString()};
  var salons  = await APIService.Get('News',queryParams);
  return salons!.map((e) => MdlNews.fromJson(e)).toList();
}

class _SalonState extends State<Salon> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
          title: Text('Salon'),
          backgroundColor: Colors.pink[200],
          leading: IconButton(
            icon: Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.of(context).pop();
            },
          )),
      body: Column(
        children: [
          Center(
            child: Image.memory(
              Uint8List.fromList(widget.salon.photo),
              height: 230,
            ),
          ),
          SizedBox(
            height: 20,
          ),
          Table(
            border: TableBorder(
                verticalInside: BorderSide(
                    width: 1.0, color: Colors.black, style: BorderStyle.solid)),
            children: [
              TableRow(children: [
                Icon(Icons.location_on),
                Icon(Icons.favorite),
                Icon(Icons.home),
              ]),
            ],
          ),
          Padding(
            padding: EdgeInsets.symmetric(vertical: 30),
            child: Text(
              'Posljednje novosti',
              style: TextStyle(
                  fontSize: 20,
                  decoration: TextDecoration.underline,
                  color: Colors.grey[700]),
            ),
          ),
          Expanded(
            child: FutureBuilder<List<MdlNews>>(
                future: fetchSalons(widget.salon.id),
                builder: (BuildContext context,AsyncSnapshot<List<MdlNews>> snapshot){
                  if(snapshot.connectionState == ConnectionState.waiting){
                    return Center(
                      child: CircularProgressIndicator(),
                    );
                  } else if (snapshot.hasError) {
                    print(snapshot.error);
                    return Center(
                      child: Text('Error...'),
                    );
                  } else {
                    return ListView(
                        children: snapshot.data!
                            .map((e) => novost(e,context)).toList()
                    );
                  }
                }),
          ),
        ],
      ),
    );
  }
}

Widget novost(MdlNews news, BuildContext context) {
  var date = Jiffy(news.createdAt).yMMMMd; // October 18, 2019
  return Column(children: [
    Container(
        height: 120,
        width: MediaQuery.of(context).size.width * 0.95,
        decoration:
            BoxDecoration(border: Border.all(color: Colors.black, width: 1.0)),
        child: Row(
          children:[ Align(
            alignment: Alignment.centerLeft,
            child: Image.memory(
              Uint8List.fromList(news.photo),
              width: 150,
              height: 100,
            ),
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.end,
            children: [
              SizedBox(
                height: 30,
              ),
              Text(
                news.title,
                style: TextStyle(fontSize: 24, color: Colors.black38),
              ),
              Text(
                date,
                style: TextStyle(fontSize: 13,),
              )
            ],
          ),
        ]
        )),
    SizedBox(height: 20,)
  ]);
}
