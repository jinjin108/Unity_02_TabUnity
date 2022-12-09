using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone

    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public string playerName = "hise";

    public int level = 1;

    public int gold = 500;

    public int totalHp = 100;
    public int curHp = 100;

    public void AddGold(int gold)
    {
        this.gold += gold;
    }

    public bool SpenGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalHp += addHp;
    }

    public void SetCurrentHP(int hp)
    {
        curHp += hp;

        if (curHp > totalHp)
            curHp = totalHp;

        if (curHp < 0)
            curHp = 0;

        // 위 함수는 curHp = Mathf.Clamp(curHp,0,100) 와 같다
    }
}
