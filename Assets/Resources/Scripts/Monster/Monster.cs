using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private int hp;
	[SerializeField] private int hpMax;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		hp = hpMax;
	}
	public void ForcePush(Vector2 _direction)
	{
		transform.position += (Vector3)_direction * 0.5f;
	}
	public void Hit()
	{
		BloodManager.instance.SpawnParticle(transform.position);
		hp--;
		if(hp <= 0)
		{
			BloodManager.instance.SpawnSprite(transform.position);
			Die();
		}
		else
		{
			BloodManager.instance.SpawnTrail(transform.position);
		}
	}
	public void Die()
	{
		BodyManager.instance.SpawnOrcBody(transform.position);
		Destroy(gameObject);
	}
	#endregion

	#region PrivateMethod
	private void Start()
	{
		Initialize();
	}
	#endregion
}
