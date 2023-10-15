using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : HittableObject
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private Animator anim;

	[SerializeField] private float moveSpeed;
	[SerializeField] private float moveDurationMin;
	[SerializeField] private float moveDurationMax;
	[SerializeField] private float idleDurationMin;
	[SerializeField] private float idleDurationMax;

	[SerializeField][ReadOnly] private float stateTimer;
	[SerializeField][ReadOnly] private float stateTimerMax;
	private Vector2 direction;
	[SerializeField][ReadOnly] private string currentState;
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
	protected override void Start()
	{
		base.Start();
		currentState = "Idle";
		transform.Find("Renderer").TryGetComponent(out sr);
		TryGetComponent(out rb);
		TryGetComponent(out anim);
		StartCoroutine(currentState);
	}
	private void Update()
	{
		
	}
	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	private IEnumerator Idle()
	{
		//ENTER
		stateTimerMax = Random.Range(idleDurationMin, idleDurationMax);
		stateTimer = stateTimerMax;
		yield return null;
		//ACTION
		while(stateTimer > 0)
		{
			stateTimer -= Time.deltaTime;
			yield return null;
		}
		//EXIT
		currentState = "Move";
		yield return null;
		StartCoroutine(currentState);
	}
	private IEnumerator Move()
	{
		//ENTER
		stateTimerMax = Random.Range(moveDurationMin, moveDurationMax);
		stateTimer = stateTimerMax;
		direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
		if(direction.x > 0)
		{
			sr.flipX = true;
		}
		else
		{
			sr.flipX = false;
		}
		anim.SetBool("move", true);
		yield return null;
		//ACTION
		while (stateTimer > 0)
		{
			stateTimer -= Time.deltaTime;
			rb.velocity = direction * moveSpeed;
			yield return null;
		}
		//EXIT
		rb.velocity = Vector2.zero;
		anim.SetBool("move", false);
		currentState = "Idle";
		yield return null;
		StartCoroutine(currentState);
	}
	#endregion
}
