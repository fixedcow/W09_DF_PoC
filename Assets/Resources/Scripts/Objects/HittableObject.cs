using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HittableObject : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	protected int hp;
	[SerializeField] protected int hpMax;
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
	public virtual void Hit()
	{
		hp--;
		if(hp <= 0)
		{
			Die();
		}
	}
	public virtual void Die()
	{
		Destroy(gameObject);
	}
	#endregion

	#region PrivateMethod
	protected virtual void Start()
	{
		Initialize();
	}
	#endregion
}
