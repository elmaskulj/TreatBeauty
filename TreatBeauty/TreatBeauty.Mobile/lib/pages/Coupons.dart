import 'package:flutter/material.dart';
import 'package:treatbeauty/models/MdlBaseUser.dart';
import 'package:treatbeauty/models/MdlCoupon.dart';
import 'package:treatbeauty/services/APIService.dart';

class Coupons extends StatefulWidget {
  const Coupons({Key? key}) : super(key: key);

  @override
  _CouponsState createState() => _CouponsState();
}

class _CouponsState extends State<Coupons> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
          title: Text('Aktivni kuponi'), backgroundColor: Colors.pink[200]),
      body: LoadData(),
    );
  }
}

Future<int?> fetchCustomer() async {
  Map<String, String> queryParams = {'Email': APIService.username};
  var user = await APIService.Get('Customer', queryParams);
  return user!.map((e) => MdlBaseUser.fromJson(e)).first.id;
}

Future<List<MdlCoupon>> fetchCoupons() async {
  var customer = await fetchCustomer();
  Map<String, String> queryParams = {'CustomerId': customer.toString()};
  var coupons = await APIService.Get('Coupon', queryParams);
  return coupons!.map((e) => MdlCoupon.fromJson(e)).toList();
}

Widget LoadData() {
  return FutureBuilder<List<MdlCoupon>>(
    future: fetchCoupons(),
    builder: (BuildContext context, AsyncSnapshot<List<MdlCoupon>> snapshot) {
      if (snapshot.connectionState == ConnectionState.waiting) {
        return Center(child: CircularProgressIndicator());
      } else if (snapshot.data!.length == 0) {
        return Text("Nema aktivnih kupona");
      } else if (snapshot.hasError) {
        return Center(
          child: Text('Error...'),
        );
      } else {
        return ListView(
            children: snapshot.data!.map((e) => Kartica(e)).toList());
      }
    },
  );
}

Widget Kartica(MdlCoupon coupon) {
  return Card(
    child: ListTile(
      leading: Icon(Icons.check),
      tileColor: Colors.grey[200],
      title: Text(
        coupon.title.toString()+ "                                        "+coupon.value.toString().substring(0,2)+"%",
        style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
      ),
      subtitle: Text(
        "kod: "+coupon.id.toString(),
        style: TextStyle(
          fontWeight: FontWeight.bold,
        ),
      ),
    ),
  );
}
