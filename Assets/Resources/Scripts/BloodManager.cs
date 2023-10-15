using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour
{
	#region PublicVariables
	public static BloodManager instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject bloodSprite;
	[SerializeField] private GameObject bloodTrail;
	[SerializeField] private GameObject bloodParticle;
	[SerializeField] private GameObject slimeTrail;
	[SerializeField] private GameObject slimeParticle;
	#endregion

	#region PublicMethod
	public void SpawnSprite(Vector2 _position)
	{
		Vector2 randPos = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.1f, 0.1f));
		Instantiate(bloodSprite, _position + randPos, Quaternion.identity, transform);
	}
	public void SpawnTrail(Vector2 _position)
	{
		Vector2 randPos = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.1f, 0.1f));
		Instantiate(bloodTrail, _position, Quaternion.identity, transform);
	}
	public void SpawnParticle(Vector2 _position)
	{
		Instantiate(bloodParticle, _position, Quaternion.identity, transform);
	}
	public void SpawnSlimeParticle(Vector2 _position)
	{
		Instantiate(slimeParticle, _position, Quaternion.identity, transform);
	}
	public void SpawnSlimeTrail(Vector2 _position)
	{
		Vector2 randPos = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.1f, 0.1f));
		Instantiate(slimeTrail, _position, Quaternion.identity, transform);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
			instance = this;
	}
	#endregion
}
