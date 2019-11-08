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
    public int ascendedAllies;
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
        if(allyCount > 0)
        {
            allyText.text = "Allies: " + allyCount;
        }
        else if(ascendedAllies == initAlly)
        {
            allyText.text = "They've ascended!";
        }
        else
        {
            allyText.text = "Not good!";
        }

        if(enemyCount > 0)
        {
            enemyText.text = "Enemies: " + enemyCount;
        }
        else
        {
            enemyText.text = "They're dead!";
        }
    }

    public void Reset()
    {
        allyCount = initAlly;
        enemyCount = initEnemy;
    }
}
