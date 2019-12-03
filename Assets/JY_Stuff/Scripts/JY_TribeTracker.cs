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
    public GameObject endScreen;
    public Text endText;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        initAlly = GameObject.FindGameObjectsWithTag("TribeAlly").Length;
        initEnemy = GameObject.FindGameObjectsWithTag("TribeEnemy").Length;

        allyCount = initAlly;
        enemyCount = initEnemy;
        gameOver = false;
    }

    void Update()
    {
        if(allyCount > 0)
        {
            allyText.text = "Allies: " + allyCount;
        }
        else if(ascendedAllies == initAlly)
        {
            allyText.text = "ASCENDED!";
            win();
        }
        else
        {
            allyText.text = "Not good!";
            lose();
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

    void lose()
    {
        endScreen.SetActive(true);
        gameOver = true;
        endText.text = "You Lost!\n-------------------\nPress B to go\nback to the\nMain Menu";
    }

    void win()
    {
        endScreen.SetActive(true);
        gameOver = true;
        endText.text = "You Won!\n-------------------\nPress B to go\nback to the\nMain Menu";
    }
}
