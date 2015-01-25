using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour {

	int timer = 100;
	public Text flash;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		timer--;
		if (timer <= 0) {
			timer = 100;
			if (!flash.IsActive()) {
				flash.transform.active = true;
			} else {
				flash.transform.active = false;
			}
			//timer = 100;
		}
	}
}
