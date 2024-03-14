using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search.Providers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text winScoreTxt;
    [SerializeField] private Text totalScoreTxt;

    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject losePnl;
    [SerializeField] private GameObject winPnl;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "0";
    }

    public void UpdateScore()
    {
        if(GameManager.Instance.score > 0)
        {
            scoreTxt.text = GameManager.Instance.score.ToString();
        }
        else
        {
            scoreTxt.text = "0";
        }
        
    }

    public void HitEnemy(int heart)
    {
        hearts[heart].gameObject.SetActive(false);
    }
    public void HitTrap()
    {
        foreach (var heart in hearts)
        {
            heart.gameObject.SetActive(false);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("lv1");
    }

    public void LosePanel()
    {
        AudioManager.instance.PlaySFX("Lose");
        losePnl.SetActive(true);
        GameManager.Instance.GameOver();
        GameManager.Instance.totalScore = 0;
    }

    public void NextLevel(string lv) 
    {
        SceneManager.LoadScene(lv);
    }
    public void WinPanel()
    {
        winScoreTxt.text = "Score: " + GameManager.Instance.score.ToString();
        totalScoreTxt.text = "Total Score: " + GameManager.Instance.totalScore.ToString();
        winPnl.SetActive(true);
        GameManager.Instance.GameOver();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
