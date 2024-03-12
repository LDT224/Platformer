using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreTxt;
    [SerializeField] private GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "0";
    }

    public void UpdateScore()
    {
        scoreTxt.text = GameManager.Instance.score.ToString();
    }

    public void HitEnemy(int heart)
    {
        hearts[heart].gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
