using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase
{
    // ����1

    //public string GetMonsterName()
    //{
    //    return monsterName;
    //}
    //public void SetMonsterName(string name)
    //{
    //    monsterName = name;
    //}
    //--------------------------------------------
    //����2 Propty
    //protected string monsterName;
    //public string Monstername
    //{
    //    get { return monsterName; }
    //    set { monsterName = value; }
    //}
    //--------------------------------------------
    //����3 Propty
    //public string MonsterName2 { get; set; }
    //--------------------------------------------
    public string GetMonsterName()
    {
        return monsterName;
    }

    public void SetMonsterName(string name)
    {
        monsterName = name;
    }
    public string monsterName;
    public int atk;
    public int hp;

    public float delay;

    public int gold;

    public int level;

    public int y;

    public virtual void Attack()
    {
    }

}
