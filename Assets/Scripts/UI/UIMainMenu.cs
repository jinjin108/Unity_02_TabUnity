using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMainMenu : MonoBehaviour
{
    Button[] btnStart; //��ư�� 2����� �迭�θ����
    void Start()
    {
        btnStart = GetComponentsInChildren<Button>();  //Getcomponent �ڿ� s ������ �迭��
        btnStart[0].onClick.AddListener(OnClickStart); //������ư
        btnStart[1].onClick.AddListener(OnClickStart_2); //�űԹ�ư
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
