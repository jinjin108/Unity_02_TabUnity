using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterPref : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("testkey", "2,3,1,qwert");
        string str = "2,3,1,qwert";
        string[] list = str.Split(',');

        Debug.Log(PlayerPrefs.HasKey("testkey"));
        Debug.Log(PlayerPrefs.GetInt("testkey"));

    }

    
}
