import 'dart:typed_data';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter/widgets.dart';
import 'package:treatbeauty/models/MdlBaseUser.dart';
import 'package:treatbeauty/models/MdlCustom.dart';
import 'package:treatbeauty/models/MdlSalonServices.dart';
import 'package:treatbeauty/models/MdlServiceInSalon.dart';
import 'package:treatbeauty/pages/Recommend.dart';
import 'package:treatbeauty/services/APIService.dart';
import 'package:treatbeauty/pages/Salons.dart';

import 'Terms.dart';


class Search extends StatefulWidget {
  @override
  _SearchState createState() => _SearchState();
}

Future<List<MdlSalonServices>> fetchServices(salonId) async {
  Map<String,String> queryParams = {'SalonId': salonId.toString()};
  var salonservices = await APIService.Get('SalonServices',queryParams);
  return salonservices!.map((e) => MdlSalonServices.fromJson(e)).toList();
}

Future<List<MdlServiceInSalon>> fetchSalone(MdlCustom custom) async {
  List<MdlServiceInSalon> data  = custom.services.toList();
  return data;
}

Future<int?> fetchCustomer() async {
  Map<String, String> queryParams = {'Email': APIService.username};
  var user = await APIService.Get('Customer', queryParams);
  return user!.map((e) => MdlBaseUser.fromJson(e)).first.id;
}

bool isFilter = false;

class _SearchState extends State<Search> {
  TextEditingController controllerLocation = new TextEditingController();
  TextEditingController controllerService = new TextEditingController();

  Future<List<MdlCustom>> fetchCustom() async {
    var custom = await APIService.Get('TermCustom', null);
    return custom!.map((e) => MdlCustom.fromJson(e)).toList();
  }

  bool clicked = false;
  Future<List<MdlCustom>> fetch() async {
    print('fetch');
    if (controllerService.text != "") {
      var customer = await fetchCustomer();
      Map<String, dynamic> queryParams = {
        'Location': controllerLocation.text,
        'ServiceName': controllerService.text,
        'CustomerId': customer.toString(),
      };
      var custom = await APIService.Get('TermCustom', queryParams);
      return custom!.map((e) => MdlCustom.fromJson(e)).toList();
    }
    else{
      Map<String, dynamic> queryParams = {
        'Location': controllerLocation.text,
        'ServiceName': controllerService.text,
      };
      var custom = await APIService.Get('TermCustom', queryParams);
      return custom!.map((e) => MdlCustom.fromJson(e)).toList();
    }
  }

  @override
  void initState(){
    setState(() {
      isFilter = false;

    });
  }


  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
          title: Text('Search'),
          elevation: 0.0,
          backgroundColor: Colors.pink[200],
          leading: IconButton(
            icon: Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.of(context).pop();
              setState(() {
                isFilter = false;
              });
            },
          )),
      body: Column(
        children: [
          search(context, controllerLocation, 'Lokacija', Icons.location_on_rounded),
          search(context, controllerService, 'Usluga', Icons.favorite_border),
          SizedBox(
            height: 15,),
          GestureDetector(
            onTap:()async{
              setState(() {
                FocusScope.of(context).requestFocus(new FocusNode());
                isFilter = true;
              });
            },
            child: Container(
              width: MediaQuery.of(context).size.width * 0.85,
              height: 50,
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(20),
                  color: Colors.grey
              ),
              child: Center(
                child: Text(
                  "Pretrazi",
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 17,
                      fontWeight: FontWeight.bold
                  ),
                ),
              ),
            ),
          ),
          SizedBox(
            height: 15,),
          GestureDetector(
            onTap: (){
              FocusScope.of(context).requestFocus(new FocusNode());
              Navigator.push(
                context,
                MaterialPageRoute(
                    builder: (context) => Recommend()
                ),
              );
            },
            child: Container(
              width: MediaQuery.of(context).size.width * 0.85,
              height: 50,
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(20),
                  color: Colors.pink[200]
              ),
              child: Center(
                child: Text(
                  "Preporučeni proizvodi",
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 17,
                      fontWeight: FontWeight.bold
                  ),
                ),
              ),
            ),
          ),
          SizedBox(
            height: 15,),
          isFilter == false ? Expanded(
            child: FutureBuilder<List<MdlCustom>>(
                future: fetchCustom(),
                builder: (BuildContext context,AsyncSnapshot<List<MdlCustom>> snapshot){
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
                            .map((e) => kartica(e,context)).toList()
                    );
                  }
                }),
          ) :Expanded(
            child: FutureBuilder<List<MdlCustom>>(
                future: fetch(),
                builder: (BuildContext context,AsyncSnapshot<List<MdlCustom>> snapshot){
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
                            .map((e) => kartica(e,context)).toList()
                    );
                  }
                }),
          ),
        ],
      ),
    );
  }
}

Widget kartica(MdlCustom custom,BuildContext context){
  return Column(
    children: [
      Container(
        decoration: BoxDecoration(
            border: Border.all(
                color: Colors.grey
            )
        ),
        alignment: Alignment.topLeft,
        height: 400,
        width: MediaQuery.of(context).size.width * 0.95,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            InkWell(
              onTap: (){
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => Salon(
                      key: null,
                      salonId: custom.salonId,
                    ),
                  ),
                );
              },
              child: Center(
                  child: Image.memory(
                    Uint8List.fromList(custom.salonPhoto),
                    fit: BoxFit.fill,
                  )),
            ),
            Container(
              color: Colors.grey[200],
              child: Row(
                children: [
                  Padding(
                      padding: EdgeInsets.only(top: 10,left: 10),
                      child: Text(custom.salonName,style: TextStyle(fontSize: 18,fontWeight: FontWeight.bold),)),
                  Spacer(),
                  Padding(
                      padding: EdgeInsets.only(top: 10),
                      child: Text(custom.cityName+', '+custom.location,style: TextStyle(fontSize: 16),)),
                  Padding(
                    padding: EdgeInsets.only(top: 10),
                    child: Icon(
                        Icons.location_on
                    ),
                  )
                ],
              ),
            ),
            FutureBuilder<List<MdlServiceInSalon>>(
              future: fetchSalone(custom),
              builder: (BuildContext context, AsyncSnapshot<List<MdlServiceInSalon>> snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return Center(
                      child: CircularProgressIndicator()
                  );
                } else if (snapshot.hasError) {
                  return Center(
                      child: CircularProgressIndicator()
                  );
                } else {
                  return Container(
                    height: 100,
                    child: SingleChildScrollView(
                      physics: BouncingScrollPhysics(),
                      child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: snapshot.data!
                              .map((e) => Padding(
                              padding: EdgeInsets.only(top: 15,left: 30),
                              child: InkWell(
                                onTap: (){
                                  Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                        builder: (context) => Calendar(
                                            serviceId: e.serviceId,
                                            serviceName : e.serviceName,
                                            salonName : custom.salonName,
                                            salonId : custom.salonId,
                                            price : e.servicePrice
                                        )
                                    ),
                                  );
                                },
                                child: Text(
                                  e.serviceName.toString() + '           '  +  e.servicePrice.toString()+'KM',
                                  style:
                                  TextStyle(fontSize: 15,fontWeight: FontWeight.bold),
                                ),
                              )))
                              .toList()),
                    ),
                  );
                }
              },
            )
          ],
        ),
      ),
      SizedBox(height: 15,)
    ],
  );
}

Widget search(BuildContext context,TextEditingController controller,String hintText,icon){
  return Container(
    width: MediaQuery.of(context).size.width * 0.85,
    child: Padding(
      padding: const EdgeInsets.only(top : 3.0),
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(20),
        ),
        child: ListTile(
          leading: Icon(icon),
          title: TextField(
            textInputAction: TextInputAction.go,
            controller: controller,
            decoration: InputDecoration(
                hintText: hintText, border: InputBorder.none),
          ),
        ),
      ),
    ),
  );
}


