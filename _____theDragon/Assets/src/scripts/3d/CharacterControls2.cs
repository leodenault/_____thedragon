using UnityEngine;
using System.Collections;

public class CharacterControls2 : MonoBehaviour {

	// Use this for initialization
	Vector2 offset;
	Vector2 max, min;
	public Transform tile;
	public bool transistioning;
	public float speed;
	public DialogueDisplay disp;
	public ChoicePanel choicePanel;
	public Sprite up,down,left,right;
	Vector2 pMoveDir;
	bool grabCamX,grabCamY;
	Vector3 pos;
	float buffer = 0.5f;
	void Start () 
	{
		//transform.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteRenderer>().sprite[1] ;
		//Debug.Log(ApplicationModel.fromDoor);
		grabCamY = false;
		if(ApplicationModel.fromDoor)
		goToDoor();
		grabCamX = true;
		//grabCamY = true;
		pos = new Vector3(transform.position.x,transform.position.y,-10);
		//getEdges();
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


		//Camera.main.transform.position = pos; 
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
					transform.position = d.transform.GetChild(0).position;
										break;
				}
			}
		
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 moveDir = new Vector3(speed * 2f * Input.GetAxis("Horizontal") ,0, speed * Input.GetAxis("Vertical")); 
		if(!transistioning  && !disp.displaying && (choicePanel == null || !choicePanel.Displaying))
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
			
		/*	if((moveDir.y > 0 && transform.position.y >= max.y - buffer) || (moveDir.y < 0 && transform.position.y <= min.y + buffer))
			{
				grabCamY = false;
			} 
			else 
			{
				if((moveDir.y < 0 && transform.position.y <= max.y - buffer) || (moveDir.y > 0 && transform.position.y >= min.y + buffer))
				grabCamY = true;
			} */
			if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.DownArrow) 
				|| Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp("a") ||
				Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp("d"))
			{
				if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))	
				{		
					transform.GetComponent<SpriteRenderer>().sprite = up;
				}

				if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))	
				{		
						transform.GetComponent<SpriteRenderer>().sprite = down;
				}

				if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp("a"))	
				{		
					transform.GetComponent<SpriteRenderer>().sprite = left;
				}

				if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))	
				{		
					transform.GetComponent<SpriteRenderer>().sprite = right;
				}
			}

			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))	
			{		
					transform.GetComponent<SpriteRenderer>().sprite = up;
			}
			else
			{
				if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))	
				{		
						transform.GetComponent<SpriteRenderer>().sprite = down;
				}
				else
				{
					if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))	
					{		
						transform.GetComponent<SpriteRenderer>().sprite = left;
					}
					else
					{
						if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))	
						{		
							transform.GetComponent<SpriteRenderer>().sprite = right;
						}
						
					}
				}
			}

	//			Debug.Log(moveDir);
				transform.position+= moveDir;
				//transform.localScale-= new Vector3(moveDir.z,moveDir.z,moveDir.z) / 5f;
		}
	 
	pMoveDir = (Vector2) moveDir;
	}

	public void getEdges() // finds the world position of the walls around the  tile for collision
	{
		offset = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize); 
		max = new Vector2((tile.position.x + (tile.localScale.x / 2f)) - offset.x, (tile.position.y + (tile.localScale.y / 2f)) - offset.y);
		min = new Vector2((tile.position.x - (tile.localScale.x / 2f)) + offset.x, (tile.position.y - (tile.localScale.y / 2f)) + offset.y);
		//Debug.Log(min);
	}

	void OnTriggerStay(Collider  col)
	{

		
		if(col.tag == "Interactable" && !disp.displaying && (choicePanel == null || !choicePanel.Displaying))
		{
			
			if(Input.GetKeyDown("e") || Input.GetKeyDown(KeyCode.Space))
			{
				
				col.transform.SendMessage("Interaction");
			}
		}
	}
}
