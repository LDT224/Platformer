using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPosition;
    private Rigidbody2D playerRb;
    private bool isOnGround = true;
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void MoveLeft()
    {
        targetPosition = transform.position + Vector3.left;
        playerAnim.SetBool("Running", true);
        playerSprite.flipX = true;
        //set running = faile while exit button
    }

    public void MoveRight()
    {
        targetPosition = transform.position + Vector3.right;
        playerAnim.SetBool("Running", true);
        playerSprite.flipX = false;
    }

    public void Jump()
    {
        if(isOnGround == true && !GameManager.Instance.isGameOver) { 
            playerRb.AddForce(Vector3.up * GameManager.Instance.playerJumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
            transform.position = Vector3.Lerp(transform.position, targetPosition, GameManager.Instance.playerMoveSpeed * Time.deltaTime);
        }
        else
        {
            playerAnim.SetBool("Running", false);
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(transform.position.y < -2.5f) 
        {
            GameManager.Instance.GameOver();
        }
    }
}
