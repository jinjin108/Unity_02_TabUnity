using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeunScenes : MonoBehaviour
{
    void Start()
    {

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIMainMEnu");
    }

}
