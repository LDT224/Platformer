using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonController : MonoBehaviour
{
    private Animator melonAnim;
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        melonAnim = GetComponent<Animator>();
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            melonAnim.SetBool("Collected", true);
            AudioManager.instance.PlaySFX("Eat");
        }
    }

    public void OnDestroyAnimationEnd()
    {
        Destroy(this.gameObject);
        GameManager.Instance.score += 100;
        uiManager.UpdateScore();
        Debug.Log(GameManager.Instance.score);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
