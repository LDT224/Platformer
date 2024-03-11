using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPosition;
    private Rigidbody2D playerRb;
    private bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        targetPosition = transform.position + Vector3.left;
    }

    public void MoveRight()
    {
        targetPosition = transform.position + Vector3.right;
    }

    public void Jump()
    {
        if(isOnGround == true && !GameManager.Instance.isGameOver) { 
            playerRb.AddForce(Vector3.up * GameManager.Instance.playerJumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isOnGround = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) 
        {
            MoveLeft();
            transform.position = Vector3.Lerp(transform.position, targetPosition, GameManager.Instance.playerMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
            transform.position = Vector3.Lerp(transform.position, targetPosition, GameManager.Instance.playerMoveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(transform.position.y < -2.1f) 
        {
            GameManager.Instance.GameOver();
        }
    }
}
