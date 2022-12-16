using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenes : MonoBehaviour
{
    private void Start()
    {
        //GameManager.GetInstance().LoadData();

        string characterName = "";
        if (GameManager.GetInstance().characterIdx == 0)
        {
            characterName = GameManager.GetInstance().playersDatas[GameManager.GetInstance().characterIdx].Characterimg;
        }
        else
        {
            characterName = GameManager.GetInstance().playersDatas[GameManager.GetInstance().characterIdx].Characterimg;
        }

        GameObject go = ObjectManager.GetInstance().CreateCharacter(characterName);
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 0.5f, 0);


        UIManager.GetInstance().SetEventSystem();

        UIManager.GetInstance().OpenUI("UIProfile");

        UIManager.GetInstance().OpenUI("UIActionMenu");
        if (GameManager.GetInstance().playersDatas[GameManager.GetInstance().characterIdx].level >= 50)
        {
            GameManager.GetInstance().playersDatas[GameManager.GetInstance().characterIdx].atk += 1;
        }


    }
    
}
