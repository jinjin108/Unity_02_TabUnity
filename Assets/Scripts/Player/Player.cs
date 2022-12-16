using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public string Characterimg;
    public string playerName;

    public int level;
    public int gold;

    public int totalHp;
    public int curHp;

    public int atk;
   // public int characterIdx;
    public Player(string Characterimg,string playerName, int level, int gold, int totalHp, int curHp, int atk)
    {
        this.Characterimg = Characterimg;
        this.playerName = playerName;
        this.level = level;
        this.gold = gold;
        this.totalHp = totalHp;
        this.curHp = curHp;
        this.atk = atk;
    }
}
