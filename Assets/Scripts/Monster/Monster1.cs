using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class 참조
//struct 값타입
public class Monster1 : MonsterBase
{
    public Monster1(string monsterName, int atk, int hp, float delay, int gold,int level)
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
        base.Attack();
        GameManager.GetInstance().SetCurrentHP(-atk);
    }
}
