using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlScenes : MonoBehaviour
{
    void Start()
    {

        GameObject go = ObjectManager.GetInstance().CreateMonster();
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        go.transform.localPosition = new Vector3(0, 0.6f, 0);


        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");

        BattleManager.GetInstance().BattleStart(new Monster1());
    }

    void Update()
    {
        
    }
}
