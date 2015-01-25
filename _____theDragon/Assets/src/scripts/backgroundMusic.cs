using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {

	private GameObject obj;
	public AudioSource bckgrnd;

	public AudioClip s;



	// Use this for initialization
	void Start () {
	
		bckgrnd.clip = s;
		bckgrnd.Play();

		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
