using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMainMenu : MonoBehaviour
{
    Button[] btnStart; //버튼이 2개라면 배열로만들기
    void Start()
    {
        btnStart = GetComponentsInChildren<Button>();  //Getcomponent 뒤에 s 붙히면 배열로
        btnStart[0].onClick.AddListener(OnClickStart); //원래버튼
        btnStart[1].onClick.AddListener(OnClickStart_2); //신규버튼
    }

    void OnClickStart()
    {
        GameManager.GetInstance().characterIdx = 0;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
    void OnClickStart_2()
    {
        GameManager.GetInstance().characterIdx = 1;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
