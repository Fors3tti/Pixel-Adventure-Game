using UnityEngine;

public class EnemyPlant : Enemy
{
    [Header("Plant details")]
    [SerializeField] private EnemyBullet bulletPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private float bulletSpeed = 7f;
    [SerializeField] private float attackCooldown = 1.5f;
    private float lastTimeAttacked;

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

    private void CreateBullet()
    {
        EnemyBullet newBullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);

        Vector2 bulletVelocity = new Vector2(facingDir * bulletSpeed, 0);
        newBullet.SetVelocity(bulletVelocity);

        Destroy(newBullet.gameObject, 10);
    }

    protected override void HandleAnimator()
    {
        //Keep empty
    }
}
