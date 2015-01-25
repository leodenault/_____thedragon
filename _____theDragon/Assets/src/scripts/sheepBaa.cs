using UnityEngine;
using System.Collections;

public class sheepBaa : MonoBehaviour {

	// Use this for initialization
	public AudioSource baa;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Interaction()
	{
		//Debug.Log("went");
		baa.Play();
	}
}
