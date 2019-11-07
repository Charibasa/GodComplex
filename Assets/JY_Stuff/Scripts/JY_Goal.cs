using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Goal : MonoBehaviour
{
    public GameObject upper;
    public GameObject lower;
    int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 25;
    }

    // Update is called once per frame
    void Update()
    {
        upper.transform.Rotate(0, -speed * Time.deltaTime, 0);
        lower.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public void speedUp()
    {
        speed = 250;
        Invoke("slowDown", 4);
    }

    void slowDown()
    {
        speed = 25;
    }
}
