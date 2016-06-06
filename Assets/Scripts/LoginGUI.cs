using UnityEngine;
using System.Collections;

public class LoginGUI : MonoBehaviour {
	public DatabaseHandler _mysqlHolder;

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 300, 30), "MYSQL Connection state："+_mysqlHolder.GetConnectionState ());
		GUI.Label (new Rect (10, 50, 300, 30), "GetShops: "+_mysqlHolder.getFirstShops ());
	}
}
