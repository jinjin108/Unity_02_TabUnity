using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIActionMenu : MonoBehaviour
{
    public Button btnPractice;
    public Button btnHealing;
    public Button btnBattle;
    void Start()
    {
        btnBattle.onClick.AddListener(OnClickBattle);
        btnHealing.onClick.AddListener(OnClickHealing);
        btnPractice.onClick.AddListener(OnClickPractice);
    }

    void OnClickBattle()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);

    }

    void OnClickHealing()
    {
        GameManager.GetInstance().Heal();

    }
    void OnClickPractice()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Practice);

    }


}
