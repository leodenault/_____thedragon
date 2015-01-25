using UnityEngine;
using System.Collections;

public class ElderTalkPrompt : MonoBehaviour {

	public DialogueDisplay disp;
	bool once = true;
	bool first = true;
	bool start = false;
	bool trigger = false;
	public GameObject character;
	DecisionTree.Listener listener;

	// Use this for initialization
	void Start () {
		DecisionTree.registerListener (listener);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (character.transform.position [0] >= 0 && !trigger) {
			start = true;
			trigger = true;
		}
			//if (col.transform.tag == "Player" && !col.isTrigger && (first||!once) && Input.GetKey(KeyCode.Space)) {
			if (DecisionTree.IsCurrentState ("start") && once && first && start) {
				disp.displaytext (2);
				once = false;
				first = true;
			} else if (DecisionTree.IsCurrentState ("start") && !once && first && Input.GetKeyDown(KeyCode.Space)) {
				disp.displaytext (3);
				first = false;
				start = false;
			} else if (DecisionTree.IsCurrentState("start") && !first && !once && Input.GetKeyDown(KeyCode.Return)) {
				disp.displaytext (4);
				once = true;
			}
		//}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.transform.tag == "Player" && !col.isTrigger) {
			start = true;
		}
	}
}
