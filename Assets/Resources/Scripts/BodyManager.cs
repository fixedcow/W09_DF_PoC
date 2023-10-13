using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
	#region PublicVariables
	public static BodyManager instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject orcBody;
	#endregion

	#region PublicMethod
	public void SpawnOrcBody(Vector2 _position)
	{
		Instantiate(orcBody, _position, Quaternion.identity, transform);
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
