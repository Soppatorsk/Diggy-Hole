using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float timeRemaining;
    public float bonusClickInc;
    //use the editor to make prefabs to spawn in

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Main.bonusClickInc = bonusClickInc;
            //Debug.Log(timeRemaining);
        }
        else
        {
            Main.bonusClickInc = 1;
            //Debug.Log("Time Out");
            Destroy(gameObject);

        }
    }

}
