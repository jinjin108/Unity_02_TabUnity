using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2: MonsterBase
{
    public Monster2(string monsterName, int atk, int hp, float delay, int gold, int level)
    {
        this.monsterName = monsterName;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
        this.level = level;
    }

    public override void Attack()
    {
        float criticaRate = Random.Range(0,100.0f);

        int damge = atk;
        if (criticaRate < 10)
            damge *= 2;
        
        GameManager.GetInstance().SetCurrentHP(-atk);
    }
}
