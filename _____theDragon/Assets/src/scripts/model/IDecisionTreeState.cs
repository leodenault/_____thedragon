using System.Collections.Generic;

public interface IDecisionTreeState{
	string GetStateInfo();
	void AddChoice(string choice);
	List<string> GetChoices();
}
