using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

	// Use this for initialization
	Vector2 offset;
	Vector2 max, min;
	public Transform tile;
	public float speed;
	float buffer = 0.2f;
	void Start () 
	{
		
		getEdges();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Camera.main.transform.position = new Vector3(transform.position.x,transform.position.y,-10);
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 moveDir = new Vector3(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical" ), 0); 
		if((moveDir.x > 0 && transform.position.x >= max.x - buffer) || (moveDir.x < 0 && transform.position.x <= min.x + buffer)) 
		{
			moveDir.x = 0;
		}

		if((moveDir.y > 0 && transform.position.y >= max.y - buffer) || (moveDir.y < 0 && transform.position.y <= min.y + buffer)) 
		{
			moveDir.y = 0;
		}

		transform.position+= moveDir; 
	}

	public void getEdges() // finds the world position of the walls around the  tile for collision
	{
		offset = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize); 
		max = new Vector2((tile.position.x + (tile.localScale.x / 2f)) - offset.x, (tile.position.y + (tile.localScale.y / 2f)) - offset.y);
		min = new Vector2((tile.position.x - (tile.localScale.x / 2f)) + offset.x, (tile.position.y - (tile.localScale.y / 2f)) + offset.y);
	}
}
