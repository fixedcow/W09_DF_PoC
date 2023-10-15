using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : HittableObject
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	public override void Hit()
	{
		base.Hit();
	}
	public override void Die()
	{
		base.Die();
		BodyManager.instance.SpawnPotMess(transform.position);
	}
	#endregion

	#region PrivateMethod
	#endregion
}
