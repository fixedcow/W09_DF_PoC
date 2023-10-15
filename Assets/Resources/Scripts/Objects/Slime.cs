using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : HittableObject
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private Animator anim;

	[SerializeField] private float moveDistance;
	[SerializeField] private float idleDurationMin;
	[SerializeField] private float idleDurationMax;

	[SerializeField][ReadOnly] private float stateTimer;
	[SerializeField][ReadOnly] private float stateTimerMax;
	private Vector2 direction;
	[SerializeField][ReadOnly] private string currentState;

	private bool jumpEnd;
	#endregion

	#region PublicMethod
	public override void Hit()
	{
		base.Hit();
		BloodManager.instance.SpawnSlimeParticle(transform.position);
		BloodManager.instance.SpawnSlimeTrail(transform.position);
	}
	public override void Die()
	{
		base.Die();
		BodyManager.instance.SpawnSlimeBody(transform.position);
	}
	public void JumpToward()
	{
		Vector2 destination = (Vector2)transform.position + (direction * moveDistance);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, moveDistance, 1 << LayerMask.NameToLayer("Wall"));
		if(hit.collider != null)
		{
			destination = hit.point - (direction * 0.4f);
		}
		transform.DOMove(destination, 0.4f);
	}
	public void SpawnTrail()
	{
		Collider2D[] cols = Physics2D.OverlapCircleAll(rb.position, 0.6f);
		foreach(Collider2D col in cols)
		{
			Pot p;
			col.TryGetComponent(out p);
			if(p != null)
			{
				p.Hit();
			}
		}
		BloodManager.instance.SpawnSlimeTrail(transform.position);
		jumpEnd = true;
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
		Debug.DrawRay(transform.position, direction * moveDistance, Color.red);
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
		while (stateTimer > 0)
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
		direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
		if (direction.x > 0)
		{
			sr.flipX = true;
		}
		else
		{
			sr.flipX = false;
		}
		anim.SetTrigger("jump");
		yield return null;
		//ACTION
		while (jumpEnd == false)
		{
			yield return null;
		}
		//EXIT
		jumpEnd = false;
		currentState = "Idle";
		yield return null;
		StartCoroutine(currentState);
	}
	#endregion
}
