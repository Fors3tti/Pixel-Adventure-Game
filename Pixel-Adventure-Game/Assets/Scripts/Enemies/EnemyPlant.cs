using UnityEngine;

public class EnemyPlant : Enemy
{
    [Header("Plant details")]
    [SerializeField] private float attackCooldown = 1.5f;
    public float lastTimeAttacked;

    protected override void Update()
    {
        base.Update();

        bool canAttack = Time.time > lastTimeAttacked + attackCooldown;

        if (isPlayerDetected && canAttack)
            Attack();
    }

    private void Attack()
    {
        lastTimeAttacked = Time.time;
        anim.SetTrigger("attack");
    }

    protected override void HandleAnimator()
    {
        //Keep empty
    }
}
