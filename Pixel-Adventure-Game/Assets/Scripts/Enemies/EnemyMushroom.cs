using UnityEngine;

public class EnemyMushroom : Enemy
{
    protected override void Awake()
    {
        base.Awake();


    }

    private void Update()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);

        HandleMovement();
        HandleCollision();

        if (!isGroundDetected || isWallDetected)
            Flip();
    }

    private void HandleMovement()
    {
        rb.linearVelocity = new Vector2(moveSpeed * facingDir, rb.linearVelocity.y);
    }
}
