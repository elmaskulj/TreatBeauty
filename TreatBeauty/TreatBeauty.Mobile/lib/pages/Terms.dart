import 'package:flutter/material.dart';
import 'package:treatbeauty/models/MdlTerm.dart';
import 'package:treatbeauty/services/APIService.dart';

class Calendar extends StatefulWidget {
  /*
  final int? serviceId;
  const Calendar({Key? key, required this.serviceId}) : super(key: key);
*/
  @override
  _CalendarState createState() => _CalendarState();
}

Future<List<MdlTerm>> fetchTerms(termDate) async {
  Map<String, dynamic> queryParams = {'Date': termDate};
  var terms = await APIService.Get('Term', queryParams);
  return terms!.map((e) => MdlTerm.fromJson(e)).toList();
}

class _CalendarState extends State<Calendar> {
  DateTime selectedDate = DateTime.now(); // TO tracking date
  Widget TermWidget(MdlTerm obj) {
    return Padding(
      padding: const EdgeInsets.only(top: 15),
      child: Card(
        child: ListTile(
            title: Row(
          children: [
            Text(obj.start + " - " + obj.end),
            Padding(
              padding: EdgeInsets.only(left: 130),
              child: RaisedButton(
                onPressed: () async {},
                color: Colors.pink[200],
                child: Center(
                  child: Text(
                    'Zakažite termin',
                    style: TextStyle(fontSize: 12, color: Colors.white),
                  ),
                ),
              ),
            ),
          ],
        )),
      ),
    );
  }

  int currentDateSelectedIndex = 0; //For Horizontal Date
  ScrollController scrollController =
      ScrollController(); //To Track Scroll of ListView

  List<String> listOfMonths = [
    "Jan",
    "Feb",
    "Mar",
    "Apr",
    "May",
    "Jun",
    "Jul",
    "Aug",
    "Sep",
    "Oct",
    "Nov",
    "Dec"
  ];

  List<String> listOfDays = ["Pon", "Uto", "Sri", "Čet", "Pet", "Sub", "Ned"];

  DateTime selectedDateForSend = DateTime.now();

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.pinkAccent,
        automaticallyImplyLeading: false,
        title: Text('Termini'),
      ),
      body: Column(
        children: [
          //To Show Current Date
          Container(
              height: 30,
              margin: EdgeInsets.only(left: 10),
              alignment: Alignment.centerLeft,
              child: Text(
                selectedDate.day.toString() +
                    '-' +
                    listOfMonths[selectedDate.month - 1] +
                    ', ' +
                    selectedDate.year.toString(),
                style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.w800,
                    color: Colors.indigo[700]),
              )),
          SizedBox(height: 10),
          //To show Calendar Widget
          Container(
              height: 80,
              child: Container(
                  child: ListView.separated(
                separatorBuilder: (BuildContext context, int index) {
                  return SizedBox(width: 10);
                },
                itemCount: 365,
                controller: scrollController,
                scrollDirection: Axis.horizontal,
                itemBuilder: (BuildContext context, int index) {
                  return InkWell(
                    onTap: () {
                      setState(() {
                        currentDateSelectedIndex = index;
                        selectedDate =
                            DateTime.now().add(Duration(days: index));
                        selectedDateForSend = selectedDate;
                      });
                    },
                    child: Container(
                      height: 80,
                      width: 60,
                      alignment: Alignment.center,
                      decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(8),
                          boxShadow: [
                            BoxShadow(offset: Offset(3, 3), blurRadius: 5)
                          ],
                          color: currentDateSelectedIndex == index
                              ? Colors.pink
                              : Colors.white),
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Text(
                            listOfMonths[DateTime.now()
                                        .add(Duration(days: index))
                                        .month -
                                    1]
                                .toString(),
                            style: TextStyle(
                                fontSize: 16,
                                color: currentDateSelectedIndex == index
                                    ? Colors.white
                                    : Colors.grey),
                          ),
                          SizedBox(
                            height: 5,
                          ),
                          Text(
                            DateTime.now()
                                .add(Duration(days: index))
                                .day
                                .toString(),
                            style: TextStyle(
                                fontSize: 22,
                                fontWeight: FontWeight.w700,
                                color: currentDateSelectedIndex == index
                                    ? Colors.white
                                    : Colors.grey),
                          ),
                          SizedBox(
                            height: 5,
                          ),
                          Text(
                            listOfDays[DateTime.now()
                                        .add(Duration(days: index))
                                        .weekday -
                                    1]
                                .toString(),
                            style: TextStyle(
                                fontSize: 16,
                                color: currentDateSelectedIndex == index
                                    ? Colors.white
                                    : Colors.grey),
                          ),
                        ],
                      ),
                    ),
                  );
                },
              ))),
          Expanded(
            child: FutureBuilder<List<MdlTerm>>(
              future:
                  fetchTerms(selectedDateForSend.toString().substring(0, 10)),
              builder: (BuildContext context,
                  AsyncSnapshot<List<MdlTerm>> snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return Center(child: CircularProgressIndicator());
                } else if (snapshot.data!.length == 0) {
                  return Center(
                    child: Text("Ne postoje termini na ovaj datum", style: TextStyle(fontSize: 20),),
                  );
                } else if (snapshot.hasError) {
                  print(snapshot.error);
                  return Center(
                    child: Text('Error...'),
                  );
                } else {
                  return ListView(
                      children:
                          snapshot.data!.map((e) => TermWidget(e)).toList());
                }
              },
            ),
          )
        ],
      ),
    ));
  }
}
