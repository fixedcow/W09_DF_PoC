using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public abstract class Mess : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	protected RadialProgress progress;
	protected SpriteRenderer sr;

	[SerializeField] private float duration;
	private float timer = 0;

	private bool cleaning;
	private bool destroyed;
	#endregion

	#region PublicMethod
	public void Initialzie()
	{
		timer = 0f;
	}
	public void HighlightOn()
	{
		if (destroyed == true)
			return;
		sr.material.EnableKeyword("OUTBASE_ON");
	}
	public void HighlightOff()
	{
		sr.material.DisableKeyword("OUTBASE_ON");
	}
	public void Cleaning()
	{
		if (cleaning == true || destroyed == true)
			return;
		progress.ActivateProgress();
		cleaning = true;
	}
	public void ForceQuit()
	{
		HighlightOff();
		cleaning = false;
	}
	public void DestroySelf()
	{
		destroyed = true;
		progress.DeactivateProgress();
		ForceQuit();
		transform.DOScale(0f, 0.4f).From(1.6f).OnComplete(() => Destroy(gameObject));
	}
	#endregion

	#region PrivateMethod
	protected virtual void Awake()
	{
		TryGetComponent(out sr);
		transform.Find("Progress").TryGetComponent(out progress);
	}
	private void Update()
	{
		if (destroyed == true)
			return;
		if(cleaning == true)
		{
			timer += Time.deltaTime;
			progress.UpdateProgress(timer / duration);
			if(timer > duration)
			{
				DestroySelf();
			}
		}
		else if(timer > 0)
		{
			timer -= Time.deltaTime * 0.5f;
			progress.UpdateProgress(timer / duration);
			if (timer <= 0)
			{
				timer = 0;
				progress.DeactivateProgress();
			}
		}
	}
	#endregion
}
