using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChoicePanel : MonoBehaviour {

	private const int NONE = -1;
	
	private int index = NONE;
	
	public VerticalLayoutGroup choicePanel;
	public Text optionText;
	public List<Text> options;
	
	private bool displaying;
	public bool Displaying {
		get {
			return displaying;
		}
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.UpArrow) ||
			Input.GetKeyDown(KeyCode.W)) {
			int nextIndex;
			if (index == 0) {
				nextIndex = options.Count - 1;
			} else {
				nextIndex = index - 1;
			}
			setIndex(nextIndex, index);
		} else if (Input.GetKeyDown(KeyCode.DownArrow) ||
			Input.GetKeyDown(KeyCode.S)) {
			setIndex((index + 1) % options.Count, index);
		} else if (Input.GetKeyDown(KeyCode.E) ||
			Input.GetKeyDown(KeyCode.Space)) {
			DecisionTree.SelectChoice(options[index].text);
		}
	}
	
	private void setIndex(int index, int previous) {
		options[previous].color= new Color(0.0F, 0.0F, 0.0F, 1.0F);
		this.index = index;
		options[index].color= new Color(0.0F, 1.0F, 0.0F, 1.0F);
	}
	
	private void clearChildren() {
	    List<GameObject> children = new List<GameObject>();
		foreach (Transform child in choicePanel.transform) {
			children.Add(child.gameObject);
		}
		children.ForEach(child => Destroy(child));
	}
	
	public void GenerateOptions(string[] textOptions) {
		clearChildren();
		
		if (index == NONE) {
			options = new List<Text>();
			foreach (string textOption in textOptions) {
				Text option = Text.Instantiate(optionText) as Text;
				option.text = textOption;
				option.transform.SetParent(choicePanel.transform, false);
				options.Add(option);
			}
			
			setIndex(0, 0);
		}
	}
	
	public string GetSelectedOption() {
		return options[index].text;
	}
	
	public void Display(bool display) {
		transform.active = display;
		displaying = display;
	}
}
