using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public string type = "";
    public float time;
    float bonusClickInc = 100;
    float bonusAutoInc = 100;
    float goldReward = 10000;

    bool goldRewarded = false;

    void Update()
    {
       if (type == "clicking")
        {
            if (time > 0) { Main.bonusClickInc = bonusClickInc; time -= Time.deltaTime; }
            else { Main.bonusClickInc = 1; Destroy(gameObject); }
        } else if (type == "auto")
        {
            if (time > 0) { Main.bonusAutoInc = bonusAutoInc; time -= Time.deltaTime; }
            else { Main.bonusAutoInc = 1; Destroy(gameObject); }
        } else if (type == "goldReward")
        {
            if (!goldRewarded) { Main.addGold(goldReward); goldRewarded = true; time -= Time.deltaTime; }
            else { Destroy(gameObject); }
            
        } else
        {
            Destroy(gameObject);
        }
    }

}
