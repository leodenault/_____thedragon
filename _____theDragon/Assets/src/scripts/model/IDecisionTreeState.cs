using System.Collections.Generic;

public interface IDecisionTreeState{
	string GetStateEpilogue();
	string GetId();
	void AddChoice(string choice);
	List<string> GetChoices();
}
