using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	public string SceneName;
	public int nextDoorNum;
	public int thisDoorNum; 
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D  col)
	{
		if(col.transform.tag == "Player")
		{
			ApplicationModel.door = nextDoorNum;
			ApplicationModel.fromDoor = true;
			Application.LoadLevel(SceneName);
		}
	}
}


public class ApplicationModel  {
 
    static public int door = 0;    // this is reachable from everywhere
    static public bool fromDoor = false;
 
 }