using System.Collections.Generic;
using UnityEngine;

public class EpilogData
{
	private IDecisionTreeState [] s1;
	public EpilogData (ChoiceTracker s)
	{
		s1 = s.GetStates ();
	}
	public string print_epilog()
	{
		int i = 0;
		string s = "Wowww. You have been through the following worlds in your journey..!!!\n\n";
		int n = s1.Length;
		while(i < n)
		{ 
			s = s + s1[i].GetStateInfo();
			s = "\n\n";
			i++;
		}
		Debug.Log (s);
		return s;
	}
}


