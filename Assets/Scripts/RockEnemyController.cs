using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemyController : MonoBehaviour
{
    public float moveDistance = 5f; 
    public float moveSpeed = 2f; 

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingRight = true;

    private Animator rockEnemyAnim;
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.right * moveDistance;
        rockEnemyAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rockEnemyAnim.SetBool("Hit", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rockEnemyAnim.SetBool("Hit", false);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            if (movingRight)
            {
                targetPos = startPos;
                movingRight = false;
            }
            else
            {
                targetPos = startPos + Vector3.right * moveDistance;
                movingRight = true;
            }
        }
    }
}
