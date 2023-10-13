using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBroom : MonoBehaviour
{
	#region PublicVariables
	public static PlayerBroom instance;
	#endregion

	#region PrivateVariables
	private PlayerInput input;
	private PlayerMove move;
	private PlayerAim aim;
	private PlayerHp hp;
	private Body body;
	private Tool tool;

	private ParticleSystem dustTrail;

	[SerializeField] private float invincibleTime = 1.6f;
	[SerializeField][ReadOnly] private bool canAct = true;
	[SerializeField][ReadOnly] private bool isInvincible = false;
	#endregion

	#region PublicMethod
	[Button]
	public void Initialize()
	{
		hp.Initialize();
		ForceQuit();
	}
	public void SetActive(bool b)
	{
		canAct = b;
	}
	public void ForceQuit()
	{
		aim.ForceQuit();
	}
	public void SetInvincibility(bool b)
	{
		isInvincible = b;
	}
	public void SetPosition(Vector2 _position)
	{
		dustTrail.Stop();
		transform.position = _position;
		dustTrail.Play();
	}
	[Button]
	public void Hit(float _amount)
	{
		if (isInvincible == true)
			return;
		hp.ChangeValue(_amount);
		body.StartFlickering(invincibleTime);
		tool.StartFlickering(invincibleTime);
		SetInvincibility(true);
		Invoke(nameof(RemoveInvincibility), invincibleTime);
	}
	public void Die()
	{

	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		input = new PlayerInput();
		TryGetComponent(out aim);
		aim.Initialize();
		TryGetComponent(out move);
		move.Initialize();
		TryGetComponent(out hp);
		Initialize();
		transform.Find("Renderer").TryGetComponent(out body);
		transform.Find("Broom").TryGetComponent(out tool);
		transform.Find("Dust Trail").TryGetComponent(out dustTrail);
	}
	private void OnEnable()
	{
		input.Enable();
		input.Player.Move.performed += OnMovePerformed;
		input.Player.Move.canceled += OnMoveCanceled;
		input.Player.Attack.performed += OnAttackPerformed;
		input.Player.Attack.canceled += OnAttackCanceled;
	}
	private void OnDisable()
	{
		input.Player.Move.performed -= OnMovePerformed;
		input.Player.Move.canceled -= OnMoveCanceled;
		input.Player.Attack.performed -= OnAttackPerformed;
		input.Player.Attack.canceled -= OnAttackCanceled;
		input.Disable();
	}
	private void Update()
	{
		if (canAct == true)
		{
			aim.HandleInput();
			move.HandleInput();
		}
	}
	private void OnMovePerformed(InputAction.CallbackContext _context)
	{
		if (canAct == false)
			return;
		move.Move(_context.ReadValue<Vector2>());
	}
	private void OnMoveCanceled(InputAction.CallbackContext _context)
	{
		move.Stop();
	}
	private void OnAttackPerformed(InputAction.CallbackContext _context)
	{
		if (canAct == false)
			return;
		aim.TryAction();
	}
	private void OnAttackCanceled(InputAction.CallbackContext _context)
	{
		aim.StopAction();
	}
	private void RemoveInvincibility()
	{
		SetInvincibility(false);
	}

	private void OnParticleCollision(GameObject other)
	{
		Hit(-1);
	}
	#endregion
}
