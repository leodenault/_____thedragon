using System.Collections.Generic;
using UnityEngine;

public class EpilogData: ChoiceTracker {
	private IDecisionTreeState [] s1;
	public EpilogData ()
	{
	}
	public void print_epilog()
	{
		int i = 0;
		string s = "Wowww. You have been through the following worlds in your journey..!!!\n\n";
		s1 = GetStates ();
		int n = s1.Length;
		while(i < n)
		{ 
			s = s + s1[i].GetStateInfo();
			s = "\n\n";
			i++;
		}
		Debug.Log (s);
	}
}


