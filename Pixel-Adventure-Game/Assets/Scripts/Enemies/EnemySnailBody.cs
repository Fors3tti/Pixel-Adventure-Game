using UnityEngine;

public class EnemySnailBody : MonoBehaviour
{
    private Rigidbody2D rb;
    private float zRotation;

    public void SetupBody(float yVelocity, float zRotation)
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, yVelocity);

        this.zRotation = zRotation;
    }

    private void Update()
    {
        transform.Rotate(0, 0, zRotation *  Time.deltaTime);
    }
}
