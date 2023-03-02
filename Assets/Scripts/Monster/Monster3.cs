using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonsterBase
{
    public Monster3(string monsterName, int atk, int hp, float delay, int gold, int level)
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
        GameManager.GetInstance().SetCurrentHP(-atk);
        GameManager.GetInstance().SetCurrentHP(-atk);
    }
}