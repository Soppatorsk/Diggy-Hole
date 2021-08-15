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

    bool stackedBuff;

    void Update()
    {
       if (type == "clicking")
        {
            if (Main.activeBonusC == 2 && !stackedBuff) { Main.activeBonusC -= 1; Destroy(gameObject);  } //TODO buff reset check work a third time, currently only able to "reset" a buff once, get three in a row and you get an abundant duplicate. might not be a problem if spawns are are enough
            if (time > 0) { Main.bonusClickInc = bonusClickInc; time -= Time.deltaTime; }
            else { Main.bonusClickInc = 1; Main.activeBonusC -= 1; Destroy(gameObject); }
        } else if (type == "auto")
        {
            if (Main.activeBonusA == 2 && !stackedBuff) { Main.activeBonusA -= 1; Destroy(gameObject); }
            if (time > 0) { Main.bonusAutoInc = bonusAutoInc; time -= Time.deltaTime; }
            else { Main.bonusAutoInc = 1; Main.activeBonusC -= 1; Destroy(gameObject); }
        } else if (type == "goldReward")
        {
            if (!goldRewarded) { Main.addGold(goldReward); goldRewarded = true; time -= Time.deltaTime; }
            else { Destroy(gameObject); }
            
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (type == "auto")
        {
            if (Main.activeBonusA >= 1)
            {
                stackedBuff = true;
            }
            Main.activeBonusA += 1;
        }

        if (type == "clicking")
        {
            if (Main.activeBonusC >= 1)
            {
                stackedBuff = true;
            }
            Main.activeBonusC += 1;
        }
      
    }
}
