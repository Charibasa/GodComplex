using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_TribeTracker : MonoBehaviour
{
    int initAlly;
    int initEnemy;

    public int allyCount;
    public int enemyCount;
    public Text allyText;
    public Text enemyText;

    // Start is called before the first frame update
    void Start()
    {
        initAlly = GameObject.FindGameObjectsWithTag("TribeAlly").Length;
        initEnemy = GameObject.FindGameObjectsWithTag("TribeEnemy").Length;

        allyCount = initAlly;
        enemyCount = initEnemy;
    }

    void Update()
    {
        allyText.text = "Allies: " + allyCount;
        enemyText.text = "Enemies: " + enemyCount;
    }

    public void Reset()
    {
        allyCount = initAlly;
        enemyCount = initEnemy;
    }
}
