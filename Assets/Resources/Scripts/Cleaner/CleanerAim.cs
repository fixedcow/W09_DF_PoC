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
		tool = tools[toolIndex];
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
	public void ChangeTool()
	{
		StopAction();
		if(toolIndex == tools.Count - 1)
		{
			toolIndex = 0;
		}
		else
		{
			++toolIndex;
		}
		tool.gameObject.SetActive(false);
		tool = tools[toolIndex];
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
