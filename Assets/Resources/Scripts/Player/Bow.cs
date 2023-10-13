using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Tool
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject arrowPrefab;

	[SerializeField] private float shotCooldown = 0.5f;
	private float cooldownTimer = 0f;
	[SerializeField] private float speed = 30f;
	#endregion

	#region PublicMethod
	public override void Initialize()
	{
		base.Initialize();
		cooldownTimer = shotCooldown;
	}
	public override void Act()
	{
		if (cooldownTimer > shotCooldown)
		{
			cooldownTimer = 0f;
			Action();
		}
	}
	public void SetRendererVisibility(bool b)
	{
		sr.enabled = b;
	}

	public override void ForceQuit()
	{

	}
	#endregion

	#region PrivateMethod
	private void Update()
	{
		cooldownTimer += Time.deltaTime;
	}
	private void Action()
	{
		anim.SetTrigger("shot");
		Arrow current = Instantiate(arrowPrefab).GetComponent<Arrow>();
		current.Initialize();
		current.transform.position = transform.position;
		current.SetSpeed(speed);
		current.SetDirection(transform.eulerAngles);
		current.Shot();
	}
	#endregion
}
