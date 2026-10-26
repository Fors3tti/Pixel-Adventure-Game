using System;
using UnityEngine;

public class EnemyRino : Enemy
{
    [Header("Rino details")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedUpRate;
    private float defaultSpeed;
    [SerializeField] private Vector2 impactPower;
    [SerializeField] private float detectionRange;
    private bool playerDetected;

    protected override void Start()
    {
        base.Start();

        defaultSpeed = moveSpeed;
    }

    protected override void Update()
    {
        base.Update();

        anim.SetFloat("xVelocity", rb.linearVelocity.x);

        HandleCollision();
        HandleCharge();
    }

    private void HandleCharge()
    {
        if (canMove == false)
            return;

        moveSpeed = moveSpeed + (Time.deltaTime * speedUpRate);

        if (moveSpeed >= maxSpeed)
            maxSpeed = moveSpeed;

        rb.linearVelocity = new Vector2(moveSpeed * facingDir, rb.linearVelocity.y);

        if (isWallDetected)
            WallHit();

        if (!isGroundInFrontDetected)
            TurnAround();
    }

    private void TurnAround()
    {
        moveSpeed = defaultSpeed;
        canMove = false;
        rb.linearVelocity = Vector2.zero;
        Flip();
    }

    private void WallHit()
    {
        canMove = false;
        moveSpeed = defaultSpeed;
        anim.SetBool("hitWall", true);
        rb.linearVelocity = new Vector2(impactPower.x * -facingDir, impactPower.y);
    }

    private void ChargeIsOver()
    {
        anim.SetBool("hitWall", false);
        Invoke(nameof(Flip), 1);
    }

    protected override void HandleCollision()
    {
        base.HandleCollision();

        playerDetected = Physics2D.Raycast(
            transform.position, Vector2.right * facingDir, detectionRange, whatIsPlayer);

        if (playerDetected && isGrounded)
            canMove = true;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawLine(transform.position, new Vector2(
            transform.position.x + (detectionRange * facingDir), transform.position.y));
    }
}
