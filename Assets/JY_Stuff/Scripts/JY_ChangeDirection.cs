using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_ChangeDirection : MonoBehaviour
{
    public float newDirection;
    int rota;

    private void Update()
    {
        rota = (int)Mathf.Ceil((int)transform.eulerAngles.y);
        //print(rota);

        if (rota == 0 || rota == 360 || rota == 359) //North
            newDirection = 0;

        if (rota == 45 || rota == 44)
            newDirection = 4;

        if (rota == 90 || rota == 89) //East
            newDirection = 1;

        if (rota == 135 || rota == 134)
            newDirection = 5;

        if (rota == 180 || rota == 179) // South 
            newDirection = 2;

        if (rota == 225 || rota == 224)
            newDirection = 6;

        if (rota == 270 || rota == 269) //West
            newDirection = 3;

        if (rota == 315 || rota == 314)
            newDirection = 7;
    }
}
