using UnityEngine;
using System.Collections;

public class GetTalking : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public struct Index {
	int startIndex;
	int numStrings;
}	

public struct Speech {
	Index indeces;
	string speechPart;
}

public class SpeechDatabase {

	public Speech[] database;

	SpeechDatabase::SpeechDatabase() {
		database = new Speech[10];
		for (int i = 0; i < 10; i++) {
			database[i].indeces.startIndex = -1;
			database[i].indeces.numStrings = -1;
			database[i].speechPart = "";
		}
	}

	public void readText(string text) {
		database.push(text);
	}

	public string getFull(int startIndex) {
		string fullString = "";
		for (int i = 0; i < database.Length;) {
			if (database[i].indeces.startIndex == startIndex) {
				for (int j = 1; j < database[i].indeces.numStrings; j++) {
					fullString = fullString + database[i+j];
				}
				return fullString;
			} else {
				i = i + database[i].indeces.numStrings;
			}
		}
		return fullString;
	}

}