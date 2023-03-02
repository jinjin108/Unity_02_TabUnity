using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlScenes : MonoBehaviour
{
    void Start()
    {
        var monster = BattleManager.Instance.GetRandomMonster();

        string monsterName = "";
        if(monster is Monster1)
        {
            var monsterData = monster as Monster1;
            monsterName = monsterData.GetMonsterName();
        }
        if (monster is Monster2)
        {
            var monsterData = monster as Monster2;
            monsterName = monsterData.GetMonsterName();
        }
        if (monster is Monster3)
        {
            var monsterData = monster as Monster3;
            monsterName = monsterData.GetMonsterName();
        }

        GameObject go = ObjectManager.GetInstance().CreateMonster(monsterName);
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        go.transform.localPosition = new Vector3(0, 0.6f, 0);

        BattleManager.Instance.monsterObj = go;

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");

        BattleManager.Instance.BattleStart(monster);
    }

}
