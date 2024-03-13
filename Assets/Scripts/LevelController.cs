using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.hearts = 3;
        GameManager.Instance.isGameOver = false;
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
