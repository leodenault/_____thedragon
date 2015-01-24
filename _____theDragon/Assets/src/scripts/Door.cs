using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	public string SceneName;
	public int nextDoorNum;
	public int thisDoorNum; 
	public float tSize = 0.2f,rate = 0.04f;
	public bool transistioning;
	public bool forwardT,downT;
	public int transTime;
	int tTime;
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
			
			if(tTime <= 0)
			{
				player.transform.localScale = new Vector3(1,1,1);
				Application.LoadLevel(SceneName);
				transistioning = false;
				player.GetComponent<CharacterControls>().transistioning = false;
			}
			else
			{
				if(forwardT)
				{
				player.transform.localScale-=new Vector3(rate,rate,0);
				player.transform.position+=new Vector3(0,0.02f,0);
				}
				else
				{
					if(downT)
					{
						player.transform.position+=new Vector3(0,0.05f,0);
					}
				}
			tTime--;
			}
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
			tTime = transTime;
			player.GetComponent<CharacterControls>().transistioning = true;
		}
	}

	
}


public class ApplicationModel  {
 
    static public int door = 0;    // this is reachable from everywhere
    static public bool fromDoor = false;
 
 }