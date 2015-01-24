using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	public string SceneName;
	public int nextDoorNum;
	public int thisDoorNum; 
	public float tSize = 0.2f,rate = 0.04f;
	public bool transistioning;
	Transform player;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate()
	{
		if(transistioning)
		{
			
			if(player.transform.localScale.x <= tSize)
			{
				player.transform.localScale = new Vector3(1,1,1);
				Application.LoadLevel(SceneName);
				transistioning = false;
				player.GetComponent<CharacterControls>().transistioning = false;
			}
			else
			player.transform.localScale-=new Vector3(rate,rate,0);
		}

	}
	
	void OnTriggerEnter2D(Collider2D  col)
	{
		if(col.transform.tag == "Player" && !col.isTrigger)
		{
			ApplicationModel.door = nextDoorNum;
			ApplicationModel.fromDoor = true;
			player = col.transform;
			transistioning = true;
			player.GetComponent<CharacterControls>().transistioning = true;
		}
	}

	
}


public class ApplicationModel  {
 
    static public int door = 0;    // this is reachable from everywhere
    static public bool fromDoor = false;
 
 }