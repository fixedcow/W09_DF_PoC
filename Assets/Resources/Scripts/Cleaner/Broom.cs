using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : CleanerTool
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	public override void Act()
	{
		anim.SetBool("swap", true);
		if (target != null)
		{
			target.Cleaning();
		}
	}
	public override void ForceQuit()
	{
		anim.SetBool("swap", false);
		if (target != null)
		{
			target.ForceQuit();
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
