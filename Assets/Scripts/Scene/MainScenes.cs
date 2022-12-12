using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenes : MonoBehaviour
{
    private void Start()
    {
        GameObject go = ObjectManager.GetInstance().CreateCharacter();
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 0.5f , 0);

        
        UIManager.GetInstance().SetEventSystem();

        UIManager.GetInstance().OpenUI("UIProfile");

        UIManager.GetInstance().OpenUI("UIActionMenu");



    }
}
