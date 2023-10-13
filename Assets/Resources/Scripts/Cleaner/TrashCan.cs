using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Tool
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private float interactDistance;
	#endregion

	#region PublicMethod
	public override void Look(Vector2 mousePosition)
	{
		sr.sortingOrder = GetSortingOrderByMousePosition();
		transform.localPosition = GetLocalPositionByMousePosition();
	}
	public override void Act()
	{
		
	}
	public override void ForceQuit()
	{
		
	}
	#endregion

	#region PrivateMethod
	protected int GetSortingOrderByMousePosition()
	{
		return Utils.MousePosition.y > transform.position.y ? -1 : 1;
	}
	private Vector2 GetLocalPositionByMousePosition()
	{
		float x = Utils.MousePosition.x > transform.position.x ? -0.6f : 0;
		float y = Utils.MousePosition.y > transform.position.y ? 0.2f : 0;

		return new Vector2(x, y);
	}
	#endregion
}
