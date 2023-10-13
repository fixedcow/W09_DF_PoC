using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : Tool
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	public override void Act()
	{
		anim.SetBool("swap", true);
	}
	public override void ForceQuit()
	{
		anim.SetBool("swap", false);
	}
	#endregion

	#region PrivateMethod
	#endregion
}
