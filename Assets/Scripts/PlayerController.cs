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
    private UIManager uiManager;
    private bool isCollidingWithEnemy = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        uiManager = FindAnyObjectByType<UIManager>();
    }

    public void MoveLeft()
    {
        targetPosition = transform.position + Vector3.left;
        playerAnim.SetInteger("State", 1);
        playerSprite.flipX = true;
        transform.position = Vector3.Lerp(transform.position, targetPosition, GameManager.Instance.playerMoveSpeed * Time.deltaTime);

        //set running = faile while exit button
    }

    public void MoveRight()
    {
        targetPosition = transform.position + Vector3.right;
        playerAnim.SetInteger("State", 1);
        playerSprite.flipX = false;
    }

    public void Jump()
    {
        if (isOnGround == true && !GameManager.Instance.isGameOver)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, GameManager.Instance.playerJumpForce, 0);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            GameManager.Instance.score += 500;
            GameManager.Instance.totalScore += GameManager.Instance.score;
            uiManager.UpdateScore();
            uiManager.WinPanel();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = true; 
            playerAnim.SetInteger("State", 4);
            GameManager.Instance.hearts -= 1;
            GameManager.Instance.score -= 100;
            if(GameManager.Instance.score < 0)
            {
                GameManager.Instance.score = 0;
            }
            uiManager.UpdateScore();
            uiManager.HitEnemy(GameManager.Instance.hearts);
            if(GameManager.Instance.hearts == 0)
            {
                uiManager.LosePanel();
            }
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            isCollidingWithEnemy = true;
            playerAnim.SetInteger("State", 4);
            GameManager.Instance.hearts = 0;
            uiManager.HitTrap();
            uiManager.LosePanel();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollidingWithEnemy) 
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
                playerAnim.SetInteger("State", 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (playerRb.velocity.y > 0.1f)
            {
                playerAnim.SetInteger("State", 2);
            }
            if (playerRb.velocity.y < -0.1f)
            {
                playerAnim.SetInteger("State", 3);
            }
            if (transform.position.y < -2.5f)
            {
                uiManager.LosePanel();
            }
        }
    }
}
