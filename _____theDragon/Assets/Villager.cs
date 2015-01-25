using UnityEngine;
using System.Collections;

public class Villager : MonoBehaviour {

	// Use this for initialization
	public DialogueDisplay disp;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Interaction()
	{
		disp.displaytext(1);
	}
}
