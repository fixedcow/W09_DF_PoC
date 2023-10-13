using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	protected SpriteRenderer sr;
	protected Animator anim;

	[SerializeField] private float angularSpeed = 12f;
	#endregion

	#region PublicMethod
	public virtual void Initialize()
	{
		transform.Find("Renderer").TryGetComponent(out sr);
		transform.Find("Renderer").TryGetComponent(out anim);
	}
	public virtual void Look(Vector2 mousePosition)
	{
		Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
		Quaternion targetRot = Quaternion.FromToRotation(Vector3.up, direction);
		transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetRot.eulerAngles.z, angularSpeed * Time.unscaledDeltaTime));
		sr.sortingOrder = GetSortingOrderByAngle();
		sr.flipX = GetFlipXByAngle();
	}
	public void StartFlickering(float _time)
	{
		sr.material.EnableKeyword("FLICKER_ON");
		Invoke(nameof(EndFlickering), _time);
	}
	public abstract void Act();
	public abstract void ForceQuit();
	#endregion

	#region PrivateMethod
	private int GetSortingOrderByAngle()
	{
		return transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270 ? 1 : -1;
	}
	private bool GetFlipXByAngle()
	{
		return transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 360 ? true : false;
	}
	private void EndFlickering()
	{
		sr.material.DisableKeyword("FLICKER_ON");
	}
	#endregion
}
