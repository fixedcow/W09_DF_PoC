using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : HittableObject
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private float moveSpeed;
	[SerializeField] private float moveDurationMin;
	[SerializeField] private float moveDurationMax;
	[SerializeField] private float waitDurationMin;
	[SerializeField] private float waitDurationMax;

	private float stateTimer;
	#endregion 

	#region PublicMethod
	public override void Hit()
	{
		base.Hit();
		BloodManager.instance.SpawnParticle(transform.position);
		if (hp <= 0)
		{
			BloodManager.instance.SpawnSprite(transform.position);
		}
		else
		{
			BloodManager.instance.SpawnTrail(transform.position);
		}
	}
	public override void Die()
	{
		base.Die();
		BodyManager.instance.SpawnOrcBody(transform.position);
	}
	#endregion

	#region PrivateMethod
	private void Update()
	{
		
	}
	#endregion
}
