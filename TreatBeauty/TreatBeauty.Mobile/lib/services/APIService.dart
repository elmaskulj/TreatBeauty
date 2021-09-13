import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;

class APIService {
  static String username = "";
  static String password = "";
  static String confirmPassword = "";
  static String email = "";

  String route = '';

  APIService(String route) {
    this.route = route;
  }

  // ignore: non_constant_identifier_names
  void SetParameter(String UserName, String Password) {
    username = UserName;
    password = Password;
  }

  // ignore: non_constant_identifier_names
  static Future<dynamic> ForgotPassword(String route, String email) async {
    String baseUrl = "http://10.0.2.2:5001/" + route + "/" + email;
    final response = await http.post(
      Uri.parse(baseUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
    );
    if(response.statusCode == 200) {
      return true;
    }
    else
      return null;
  }

  // ignore: non_constant_identifier_names
  static Future<dynamic> Post(String route, dynamic obj) async {
    String baseUrl = "http://10.0.2.2:5001/" + route;
    final response = await http.post(
      Uri.parse(baseUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(obj),
    );
  }

  // ignore: non_constant_identifier_names
  static Future<dynamic> Put(String route, int id, dynamic obj) async {
    String baseUrl = "http://10.0.2.2:5001/" + route + "?id=" + id.toString();
    final response = await http.put(
        Uri.parse(baseUrl),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(obj)
    );
  }

  // ignore: non_constant_identifier_names
  static Future<List<dynamic>?> Get(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;
    String baseUrl = "http://10.0.2.2:5001/" + route;
    if (object != null) {
      baseUrl = baseUrl + '?' + queryString;
    }
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    print(baseUrl);
    print(response.statusCode);
    if (response.statusCode == 200) {
      return json.decode(response.body) as List;
    }
    return null;
  }

  // ignore: non_constant_identifier_names
  static Future<List<dynamic>?> GetListById(String route, int id) async {
    String baseUrl = "http://10.0.2.2:5001/" + route + "/" + id.toString();
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) return json.decode(response.body);
    return null;
  }


  // ignore: non_constant_identifier_names
  static Future<dynamic> GetById(String route, int id) async {
    String baseUrl = "http://10.0.2.2:5001/" + route + "/" + id.toString();
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) return json.decode(response.body);
    return null;
  }
}

