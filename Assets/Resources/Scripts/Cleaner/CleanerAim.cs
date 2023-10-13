using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerAim : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private Tool tool;
	private Body body;

	private bool isCalled;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		tool.Initialize();
		transform.Find("Renderer").TryGetComponent(out body);
		body.Initialize();
	}
	public void TryAction()
	{
		isCalled = true;
	}
	public void StopAction()
	{
		isCalled = false;
		ForceQuit();
	}
	public void HandleInput()
	{
		tool.Look(Utils.MousePosition);
		body.SetSpriteDirection(Utils.MousePosition);
		if (isCalled)
		{
			Act();
		}
	}
	public void ForceQuit()
	{
		tool.ForceQuit();
	}
	#endregion

	#region PrivateMethod
	private void Act()
	{
		tool.Act();
	}
	#endregion
}
