using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyController : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingUp = true; 

    private Animator spikeEnemyAnim; 

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveDistance; 
        spikeEnemyAnim = GetComponent<Animator>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spikeEnemyAnim.SetBool("Hit", true); 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spikeEnemyAnim.SetBool("Hit", false); 
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            if (movingUp)
            {
                targetPos = startPos + Vector3.up * moveDistance; 
                movingUp = false;
            }
            else
            {
                targetPos = startPos; 
                movingUp = true;
            }
        }
    }
}
