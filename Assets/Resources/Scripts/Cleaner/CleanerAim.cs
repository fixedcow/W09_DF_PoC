using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerAim : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private List<Tool> tools = new List<Tool>();
	private Tool tool;
	private int toolIndex = 0;
	private Body body;

	private bool isCalled;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		foreach(Tool t in tools)
		{
			t.Initialize();
		}
		tool = tools[toolIndex];
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
	public void ChangeTool(int _index)
	{
		if (toolIndex == _index)
			return;
		toolIndex = _index;
		StopAction();
		tool.gameObject.SetActive(false);
		tool = tools[_index];
		tool.gameObject.SetActive(true);
	}
	#endregion

	#region PrivateMethod
	private void Act()
	{
		tool.Act();
	}
	#endregion
}
