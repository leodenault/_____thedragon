using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Epilogue : MonoBehaviour {

	public Canvas canvas;
	public Text text;

	// Use this for initialization
	void Start () {
		//canvas.renderer.material.color = new Color(0.0F, 0.0F, 0.0F, 1.0F);
		text.text = DecisionTree.GetEpilogue();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
