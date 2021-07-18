using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock
{
    int HP;
    int type;
    int goldReward;

    public Rock(int newHP, int newGoldReward)
    {
        HP = newHP;
        goldReward = newGoldReward;

    }

    public int hit(int i)
    {
        HP -= i;
        if (HP <= 0)
        {
            return goldReward;
        }
        else
        {
            return 0;
        }
    }

    public int getHP()
    {
        return HP;
    }

}
