using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenes : MonoBehaviour
{
    private void Start()
    {
        ObjectManager.GetInstance().CreateCharacter();

        UIManager.GetInstance().SetEventSystem();

        UIManager.GetInstance().OpenUI("Background");

        UIManager.GetInstance().OpenUI("UIProfile");

        UIManager.GetInstance().OpenUI("UIActionMenu");



    }
}
