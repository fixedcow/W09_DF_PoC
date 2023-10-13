using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : PlayerStat
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	public override void Initialize()
	{
		currentValue = maxValue;
    }
	#endregion

	#region PrivateMethod
	#endregion
}
