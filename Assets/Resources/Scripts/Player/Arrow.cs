using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem.Processors;
using UnityEngine.Rendering.Universal;

public class Arrow : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private SpriteRenderer sr;
	private Collider2D col;

	[SerializeField] private float speed;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		TryGetComponent(out sr);
		TryGetComponent(out col);
	}
	public void SetSpeed(float _speed)
	{
		speed = _speed;
	}
	public void SetDirection(Vector3 _rotation)
	{
		transform.eulerAngles = _rotation;
	}
	public void Shot()
	{
		Invoke(nameof(DestroySelf), 3f);
	}
	public void DestroySelf()
	{
		Destroy(gameObject);
	}
	#endregion

	#region PrivateMethod
	private void Update()
	{
		transform.position += transform.up * speed * Time.deltaTime;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision != null)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer("Hittable"))
			{
				HittableObject monster = collision.gameObject.GetComponent<HittableObject>();
				monster.Hit();
				monster.ForcePush(transform.up);
				DestroySelf();
			}
		}
	}
	#endregion
}
