using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float timeRemaining;
    public float bonusClickInc = 1;
    public float bonusAutoInc = 1;
    public float goldReward = 0;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Main.bonusClickInc = bonusClickInc;
            Main.bonusAutoInc = bonusAutoInc;
            Main.addGold(goldReward);
            //Debug.Log(timeRemaining);
        }
        else
        {
            Main.bonusClickInc = 1;
            Main.bonusAutoInc = 1;
            //Debug.Log("Time Out");
            Destroy(gameObject);

        }
    }

}
