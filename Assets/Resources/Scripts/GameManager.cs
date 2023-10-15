using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] Player player;
	[SerializeField] Cleaner cleaner;
	#endregion

	#region PublicMethod
	public void MakeTransition()
	{
		if (player.gameObject.activeSelf == true)
		{
			player.gameObject.SetActive(false);
			cleaner.transform.position = player.transform.position;
			cleaner.gameObject.SetActive(true);
		}
		else
		{
			cleaner.gameObject.SetActive(false);
			player.transform.position = cleaner.transform.position;
			player.gameObject.SetActive(true);
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
