using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class 참조
//struct 값타입
public struct Monster1
{
    public string monsterName;

    public int atk;
    public int hp;

    public float delay;

    public int gold;

    public int level;
    public Monster1(string monsterName, int atk, int hp, float delay, int gold,int level)
    {
        this.monsterName = monsterName;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
        this.level = level;
    }


}
