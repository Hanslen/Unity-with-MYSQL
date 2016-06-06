using UnityEngine;
using System;
using System.Data;
using System.Text;

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

using MySql.Data;
using MySql.Data.MySqlClient;

public class DatabaseHandler : MonoBehaviour {
	public string host, database, user, password;
	public bool pooling = true;

	private string connectionString;
	private MySqlConnection con = null;
	private MySqlCommand cmd = null;
	private MySqlDataReader rdr = null;

	private MD5 _md5Hash;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Pooling=";
		if (pooling) {
			connectionString += "true";
		} else {
			connectionString += "false";
		}
		try{
			con = new MySqlConnection(connectionString);
			con.Open();
			Debug.Log("Mysql state: "+con.State);
		}catch(Exception e){
			Debug.Log (e);
		}
	}
	void onApplicationQuit(){
		if (con != null) {
			if (con.State.ToString () != "Closed") {
				con.Close ();
				Debug.Log ("Mysql connection closed");
			}
			con.Dispose ();
		}
	}

	public string GetConnectionState(){
		return con.State.ToString ();
	}
}
