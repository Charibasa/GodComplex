using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JY_LevelSelect : MonoBehaviour
{
    int position = 0;
    bool stickIsNeutral;

    public GameObject highlight;

    // Start is called before the first frame update
    void Start()
    {
        position = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");

        if (v == 0)
        {
            stickIsNeutral = true;
        }

        if (Input.GetAxis("Vertical") > 0 && stickIsNeutral)
        {
            stickIsNeutral = false;

            if (position == 0)
            {
                position = 7;
            }
            else
            {
                position--;
            }
        }

        if (Input.GetAxis("Vertical") < 0 && stickIsNeutral)
        {
            stickIsNeutral = false;

            if (position == 7)
            {
                position = 0;
            }
            else
            {
                position++;
            }
        }
        
        highlight.transform.position = new Vector3(0, 6.7f - (0.3f * position), 4.45f);

        if (Input.GetButtonDown("Jump") || OVRInput.GetDown(OVRInput.Button.One))
        {
            loadLevel();
        }
    }

    public void loadLevel()
    {
        SceneManager.LoadScene(position+1);
    }
}
