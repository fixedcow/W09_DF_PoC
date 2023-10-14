using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : CleanerTool
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	public override void Look(Vector2 mousePosition)
	{
		sr.sortingOrder = GetSortingOrderByMousePosition();
		transform.localPosition = GetLocalPositionByMousePosition();
	}
	public override void Act()
	{
		if (target != null)
		{
			target.Cleaning();
		}
	}
	public override void ForceQuit()
	{
		if(target != null)
		{
			target.ForceQuit();
		}
	}
	#endregion

	#region PrivateMethod
	protected int GetSortingOrderByMousePosition()
	{
		return Utils.MousePosition.y > transform.position.y ? -1 : 1;
	}
	private Vector2 GetLocalPositionByMousePosition()
	{
		float x = Utils.MousePosition.x > main.transform.position.x ? -0.6f : 0;
		float y = Utils.MousePosition.y > main.transform.position.y ? 0.2f : 0;

		return new Vector2(x, y);
	}

	#endregion
}
