using UnityEngine;
using System.Collections;

public class ElderTalkPrompt : MonoBehaviour {

	public DialogueDisplay disp;
	bool once = true;
	bool first = true;
	CircleCollider2D col;

	// Use this for initialization
	void Start () {
		DecisionTree.Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (col.transform.tag == "Player" && !col.isTrigger && (first||!once) && Input.GetKey(KeyCode.Space)) {
			if (DecisionTree.IsCurrentState ("start") && once && first) {
				disp.displaytext (2);
				once = false;
			} else if (DecisionTree.IsCurrentState ("start") && !once && first) {
				disp.displaytext (3);
				first = false;
			} else if (!first && !once) {
				disp.displaytext (4);
				once = true;
			}

			//}
		}
		once = false;
	}
}
