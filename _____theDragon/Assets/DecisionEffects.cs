using UnityEngine;
using System.Collections;

public class DecisionEffects : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		if(DecisionTree.IsCurrentState("dragon"))
		transform.renderer.material.color = Color.red;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
