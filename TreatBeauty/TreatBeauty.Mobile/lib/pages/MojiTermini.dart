import 'package:flutter/material.dart';
import 'package:treatbeauty/models/MdlBaseUser.dart';
import 'package:treatbeauty/models/MdlTerm.dart';
import 'package:treatbeauty/services/APIService.dart';

class MojiTermini extends StatefulWidget {
  @override
  _MojiTerminiState createState() => _MojiTerminiState();
}

class _MojiTerminiState extends State<MojiTermini> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Moji termini"),
        backgroundColor: Colors.pink[200],
      ),
      body: loadData(),
    );
  }
}
Future<int?> fetchCustomer() async {
  Map<String, String> queryParams = {'Email': APIService.username};
  var user = await APIService.Get('Customer', queryParams);
  return user!.map((e) => MdlBaseUser.fromJson(e)).first.id;
}

Future<List<MdlTerm>> fetchTerms() async {
  var customer = await fetchCustomer();
  Map<String, String> queryParams = {'CustomerId': customer.toString()};
  var coupons = await APIService.Get('Term', queryParams);
  return coupons!.map((e) => MdlTerm.fromJson(e)).toList();
}

Widget loadData() {
  return FutureBuilder<List<MdlTerm>>(
    future: fetchTerms(),
    builder: (BuildContext context, AsyncSnapshot<List<MdlTerm>> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(child: CircularProgressIndicator());
      } else if (snapshot.data!.length == 0) {
        return Center(child: Text("Trenutno nema rezervacija"));
      } else if (snapshot.hasError) {
        return Center(
          child: Text('Error...'),
        );
      } else {
        return ListView(
            children: snapshot.data!.map((e) => kartica(e)).toList());
      }
    },
  );
}

Widget kartica(MdlTerm term) {
  return Card(
    child: ListTile(
      leading: Icon(Icons.check),
      tileColor: Colors.pinkAccent[100],
      title: Text(
        term.start + " - " + term.end,
        style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
      ),
      subtitle: Text(
        term.date.toString().substring(0,10),
        style: TextStyle(
          fontWeight: FontWeight.bold,
        ),
      ),
    ),
  );
}
