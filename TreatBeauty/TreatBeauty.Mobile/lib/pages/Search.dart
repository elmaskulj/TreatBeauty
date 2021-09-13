import 'dart:ffi';
import 'dart:typed_data';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:treatbeauty/models/MdlCustom.dart';
import 'package:treatbeauty/models/MdlSalon.dart';
import 'package:treatbeauty/models/MdlSalonServices.dart';
import 'package:treatbeauty/pages/MapScreen.dart';
import 'package:treatbeauty/services/APIService.dart';
import 'package:treatbeauty/pages/Salons.dart';


class Search extends StatefulWidget {
  @override
  _SearchState createState() => _SearchState();
}

Future<List<MdlSalon>>fetchSalon()async{
  var salons = await APIService.Get('Salon',null);
  return salons!.map((e) => MdlSalon.fromJson(e)).toList();
}

Future<List<MdlCustom>>fetchCustom()async{
  // Map<dynamic,dynamic> queryParams = {'Date': null, 'Location': null, 'ServiceName': null};
  var custom = await APIService.Get('Test', null );
  return custom!.map((e) => MdlCustom.fromJson(e)).toList();
}

Future<List<MdlSalonServices>> fetchServices(salonId) async {
  Map<String,String> queryParams = {'SalonId': salonId.toString()};
  var salonservices = await APIService.Get('SalonServices',queryParams);
  return salonservices!.map((e) => MdlSalonServices.fromJson(e)).toList();
}

class _SearchState extends State<Search> {
  TextEditingController controllerLocation = new TextEditingController();
  TextEditingController controllerDate = new TextEditingController();
  TextEditingController controllerService = new TextEditingController();


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
          elevation: 0.0,
          backgroundColor: Colors.pink[200],
          leading: IconButton(
            icon: Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.of(context).pop();
            },
          )),
      body: Column(
        children: [
          search(context, controllerLocation, 'Lokacija', Icons.location_on_rounded),
          search(context, controllerDate, 'Datum/Vrijeme', Icons.date_range_sharp),
          search(context, controllerService, 'Usluga', Icons.favorite_border),
          SizedBox(height: 15,),
          Expanded(
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
                // Navigator.push(
                //   context,
                //   MaterialPageRoute(
                //     builder: (context) => Salon(
                //       key: null,
                //       salon: salon,
                //     ),
                //   ),
                // );
              },
              child: Center(
                  child: Image.memory(
                Uint8List.fromList(custom.salonPhoto),
                fit: BoxFit.fill,
              )),
            ),
            Row(
              children: [
                Padding(
                    padding: EdgeInsets.only(top: 10,left: 10),
                    child: Text("nesto",style: TextStyle(fontSize: 18,fontWeight: FontWeight.bold),)),
                Spacer(),
                InkWell(
                  onTap: (){
                    // Navigator.push(
                    //   context,
                    //   MaterialPageRoute(
                    //     builder: (context) =>
                    //         Mape(latitude: 18.432810884762322,longitude: 43.85970468964285)
                    //     // Mape()
                    //   ),
                    // );
                  },
                  child: Padding(
                      padding: EdgeInsets.only(top: 10),
                      child: Text(custom.salonName,style: TextStyle(fontSize: 16),)),
                ),
                Padding(
                  padding: EdgeInsets.only(top: 10),
                  child: Icon(
                    Icons.location_on
                  ),
                )
              ],
            ),

            // FutureBuilder<List<MdlSalonServices>>(
            //   future: fetchServices(custom.salonId),
            //   builder: (BuildContext context, AsyncSnapshot<List<MdlSalonServices>> snapshot) {
            //     if (snapshot.connectionState == ConnectionState.waiting) {
            //       return Center(
            //           child: CircularProgressIndicator()
            //       );
            //     } else if (snapshot.hasError) {
            //       return Center(
            //           child: CircularProgressIndicator()
            //       );
            //     } else {
            //        return Container(
            //         height: 100,
            //         child: SingleChildScrollView(
            //           physics: BouncingScrollPhysics(),
            //           child: Column(
            //               crossAxisAlignment: CrossAxisAlignment.start,
            //               children: snapshot.data!
            //                   .map((e) => Padding(
            //                   padding: EdgeInsets.only(top: 5,left: 30),
            //                   child: Text(
            //                     e.serviceId.toString(),
            //                     style:
            //                     TextStyle(decoration: TextDecoration.underline,fontSize: 15,fontWeight: FontWeight.bold),
            //                   )))
            //                   .toList()),
            //         ),
            //       );
            //     }
            //   },
            // )
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
            controller: controller,
            decoration: InputDecoration(
                hintText: hintText, border: InputBorder.none),
          ),
          trailing: IconButton(
            icon: Icon(Icons.cancel),
            onPressed: () {
              controller.clear();
              // onSearchTextChanged('');
            },
          ),
        ),
      ),
    ),
  );
}
