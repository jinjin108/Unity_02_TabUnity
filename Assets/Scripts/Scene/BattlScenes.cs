using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlScenes : MonoBehaviour
{
    void Start()
    {

       


        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");

        BattleManager.GetInstance().BattleStart(new Monster1());
    }

    void Update()
    {
        
    }
}
