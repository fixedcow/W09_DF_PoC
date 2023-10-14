using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialProgress : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private SpriteRenderer sr;
	private MaterialPropertyBlock mpb;
	#endregion

	#region PublicMethod
	public void ActivateProgress()
	{
		gameObject.SetActive(true);
	}
	public void DeactivateProgress()
	{
		gameObject.SetActive(false);
	}
	public void UpdateProgress(float _progress01)
	{
		_progress01 = Mathf.Clamp01(_progress01);

		mpb.SetFloat("_Angle", 90f);
		mpb.SetFloat("_Arc2", 360 - (360 * _progress01));
		sr.SetPropertyBlock(mpb);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Radial_Fill").TryGetComponent(out sr);
		mpb = new MaterialPropertyBlock();
		sr.GetPropertyBlock(mpb);
	}
	#endregion
}
