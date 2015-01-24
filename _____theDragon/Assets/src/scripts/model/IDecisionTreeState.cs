using System.Collections.Generic;

public interface IDecisionTreeState{
	string GetStateInfo();
	void AddChoice(string choice);
	string GetId();
	List<string> GetChoices();
}
