using UnityEngine;
using System.Collections;

public class ElderTalkPrompt : MonoBehaviour {

	public DialogueDisplay disp;
	bool once = true;
	bool first = true;
	bool start = false;
	CircleCollider2D col;

	// Use this for initialization
	void Start () {
		DecisionTree.Init ();
		//move the sprite to the old man
		start = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		//if (col.transform.tag == "Player" && !col.isTrigger && (first||!once) && Input.GetKey(KeyCode.Space)) {
			if (DecisionTree.IsCurrentState ("start") && once && first && start) {
				disp.displaytext (2);
				once = false;
			first = true;
			} else if (DecisionTree.IsCurrentState ("start") && !once && first && Input.GetKeyDown(KeyCode.Space)) {
				disp.displaytext (3);
				first = false;
			} else if (DecisionTree.IsCurrentState("start") && !first && !once && Input.GetKeyDown(KeyCode.Return)) {
				disp.displaytext (4);
				once = true;
			}
		//}
	}
}
