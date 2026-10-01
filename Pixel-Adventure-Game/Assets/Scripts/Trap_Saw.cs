using System.Collections;
using UnityEngine;

public class Trap_Saw : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private Transform[] wayPoint;

    public int wayPointIndex = 1;
    private bool canMove = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.position = wayPoint[0].position;
    }

    private void Update()
    {
        anim.SetBool("active", canMove);

        if (canMove == false)
            return;

        transform.position = Vector2.MoveTowards(
            transform.position, wayPoint[wayPointIndex].position, moveSpeed *  Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint[wayPointIndex].position) < .1f)
        {
            wayPointIndex++;

            if (wayPointIndex >= wayPoint.Length)
            {
                wayPointIndex = 0;
                StartCoroutine(StopMovement(cooldown));
            }
        }
    }

    private IEnumerator StopMovement(float delay)
    {
        canMove = false;

        yield return new WaitForSeconds(delay);

        canMove = true;
    }
}
