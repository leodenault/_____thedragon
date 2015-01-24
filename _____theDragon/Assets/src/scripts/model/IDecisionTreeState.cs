using System.Collections.Generic;

public interface IDecisionTreeState{
	string GetStateInfo();
	string GetId();
	void AddChoice(string choice);
	List<string> GetChoices();
}
