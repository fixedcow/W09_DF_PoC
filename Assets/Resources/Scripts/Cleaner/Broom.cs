using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Broom : CleanerTool
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private float radius = 0.5f;

	[SerializeField] private List<Mess> targets = new List<Mess>();
	private List<Mess> next = new List<Mess>();
	#endregion

	#region PublicMethod
	public override void Act()
	{
		anim.SetBool("swap", true);
		if (targets.Count != 0)
		{
			foreach(var target in targets)
			{
				target.Cleaning();
			}
		}
	}
	public override void ForceQuit()
	{
		anim.SetBool("swap", false);
		if (targets.Count != 0)
		{
			foreach (var target in targets)
			{
				target.ForceQuit();
			}
		}
	}
	#endregion

	#region PrivateMethod
	protected override void SetTarget()
	{
		next.Clear();
		Collider2D[] cols = Physics2D.OverlapCircleAll(Utils.MousePosition, radius, 1 << LayerMask.NameToLayer(targetLayer));
		foreach(Collider2D col in cols)
		{
			Mess m;
			if(col.TryGetComponent(out m) == true
				&& Vector2.Distance(main.transform.position, m.transform.position) <= interactDistance)
			{
				next.Add(m);
			}
		}

		List<Mess> excepts = targets.Except(next).ToList();
		foreach(Mess m in excepts)
		{
			if(m != null)
				m.ForceQuit();
		}
		targets = next.ToList();
		foreach(Mess m in targets)
		{
			m.HighlightOn();
		}
	}
	#endregion
}
