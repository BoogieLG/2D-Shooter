using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float 
        rotationSpeed, moveSpeed, bulletDamage, bulletSpeed, fireRate;
    public float MoveSpeed => moveSpeed;
    public float BulletDamage => bulletDamage;
    public float BulletSpeed => bulletSpeed;

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction mouseAction;
    private InputAction attackAction;

    private Vector2 lookDirection;
    public Vector2 LookDirection => lookDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        mouseAction = playerInput.actions["MousePosition"];
        attackAction = playerInput.actions["Attack"];
    }
    private void Update()
    {
        if (attackAction.WasPressedThisFrame())
        {
            ObjectPooler.instance.SpawnFromPool(BulletType.Simple, transform.position, this);
        }
    }
    private void FixedUpdate()
    {
        Movement();
        LookRotation();
    }

    private void Movement()
    {
        Vector2 moveInput = new Vector2(moveAction.ReadValue<Vector2>().x, moveAction.ReadValue<Vector2>().y);
        rb.velocity = moveInput * moveSpeed;
    }

    private void LookRotation()
    {
        Vector2 cam = Camera.main.WorldToScreenPoint(transform.position);
        lookDirection = mouseAction.ReadValue<Vector2>() - cam;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
