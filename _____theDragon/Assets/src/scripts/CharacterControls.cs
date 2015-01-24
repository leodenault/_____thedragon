using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

	// Use this for initialization
	Vector2 offset;
	Vector2 max, min;
	public Transform tile;
	public bool transistioning;
	public float speed;
	bool grabCamX,grabCamY;
	Vector3 pos;
	float buffer = 0.175f;
	void Start () 
	{
		//Debug.Log(ApplicationModel.fromDoor);
		if(ApplicationModel.fromDoor)
		goToDoor();
		grabCamX = true;
		grabCamY = true;
		pos = new Vector3(transform.position.x,transform.position.y,-10);
		getEdges();
	}

	// Update is called once per frame
	void Update () 
	{
		if(!transistioning)
		{
		if(grabCamX)
		pos.x = transform.position.x;
		if(grabCamY)
		pos.y = transform.position.y;


		Camera.main.transform.position = pos; 
		}
	}
	void goToDoor() // teleports playre to door when they enter the scene from a door
	{
		GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

		foreach(GameObject d in doors)
		{
		
			Door dor = d.GetComponent<Door>();
			if(dor != null)
			{
				if(dor.thisDoorNum == ApplicationModel.door)
				{				
					transform.position = new Vector3(d.transform.GetChild(0).position.x, d.transform.GetChild(0).position.y, transform.position.z);
					break;
				}
			}
		
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 moveDir = new Vector3(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical" ), 0); 
		if(!transistioning)
		{
			if((moveDir.x > 0 && transform.position.x >= max.x - buffer) || (moveDir.x < 0 && transform.position.x <= min.x + buffer) ) 
			{
				grabCamX = false;//moveDir.x = 0;
			}
			else 
			{
				if((moveDir.x < 0 && transform.position.x <= max.x - buffer) || (moveDir.x > 0 && transform.position.x >= min.x + buffer))
				grabCamX = true;	
			}
			
			if((moveDir.y > 0 && transform.position.y >= max.y - buffer) || (moveDir.y < 0 && transform.position.y <= min.y + buffer))
			{
				grabCamY = false;
			} 
			else 
			{
				if((moveDir.y < 0 && transform.position.y <= max.y - buffer) || (moveDir.y > 0 && transform.position.y >= min.y + buffer))
				grabCamY = true;
			}
				transform.position+= moveDir;
		}
	 
	}

	public void getEdges() // finds the world position of the walls around the  tile for collision
	{
		offset = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize); 
		max = new Vector2((tile.position.x + (tile.localScale.x / 2f)) - offset.x, (tile.position.y + (tile.localScale.y / 2f)) - offset.y);
		min = new Vector2((tile.position.x - (tile.localScale.x / 2f)) + offset.x, (tile.position.y - (tile.localScale.y / 2f)) + offset.y);
		Debug.Log(min);
	}

	void OnTriggerStay2D(Collider2D  col)
	{

		
		if(col.tag == "Interactable")
		{
			
			if(Input.GetAxis("Interact") != 0)
			{
				
				col.transform.SendMessage("Interaction");
			}
		}
	}
}
