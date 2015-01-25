using System.Collections.Generic;
using UnityEngine;

public class EpilogData
{
	private IChoiceTracker tracker;
	public EpilogData (IChoiceTracker tracker)
	{
		this.tracker = tracker;
	}
	public string print_epilog()
	{
		string s = "Wowww. You have been through the following worlds in your journey..!!!";
		foreach (IDecisionTreeState state in tracker.GetStates())
		{ 
			s += "\n\n";
			s += state.GetStateEpilogue();
		}
		return s;
	}
}


