using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {

	private GameObject obj;
	public AudioSource bckgrnd;

	public AudioClip s;

	bool loaded = false;

	// Use this for initialization
	void Start () {
		Debug.Log(GameObject.FindGameObjectsWithTag("sound").Length);
		if(GameObject.FindGameObjectsWithTag("sound").Length <= 1 )
		{	
		bckgrnd.clip = s;
		bckgrnd.Play();

		DontDestroyOnLoad(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
