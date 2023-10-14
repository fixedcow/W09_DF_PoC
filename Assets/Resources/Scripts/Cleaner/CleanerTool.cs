using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CleanerTool : Tool
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	protected Cleaner main;

	[SerializeField] protected string targetTag;
	[SerializeField] protected float interactDistance;
	[SerializeField][ReadOnly] protected Mess target;
	#endregion

	#region PublicMethod
	public override void Initialize()
	{
		base.Initialize();
		transform.parent.TryGetComponent(out main);
	}
	#endregion

	#region PrivateMethod
	protected virtual void Update()
	{
		SetTarget();
	}
	protected void SetTarget()
	{
		RaycastHit2D hit = GetMousePositionMess();
		if(hit.collider != null
			&& hit.collider.CompareTag(targetTag) == true
			&& Vector2.Distance(main.transform.position, hit.collider.transform.position) <= interactDistance)
		{
			Mess m = hit.collider.GetComponent<Mess>();
			if (target != null)
			{
				target.ForceQuit(); //TODO 이상하게 한 번에 여러개 지우는 버그 고쳐야함
			}
			target = m;
			target.HighlightOn();
		}
		else
		{
			if (target != null)
			{
				target.HighlightOff();
			}
			target = null;
		}
	}
	protected RaycastHit2D GetMousePositionMess()
	{
		RaycastHit2D hit = Physics2D.Raycast(Utils.MousePosition, Vector2.zero
			, float.MaxValue, 1 << LayerMask.NameToLayer("Mess"));
		return hit;
	}
	#endregion
}