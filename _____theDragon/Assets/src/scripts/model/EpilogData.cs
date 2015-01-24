using System.Collections.Generic;

public class EpilogData: ChoiceTracker {
	private IDecisionTreeState [] s1;
	public EpilogData ()
	{
	}
	public void print_epilog()
	{
		s1 = GetStates ();
	}
}


