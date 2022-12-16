using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill;

    public TMP_Text txtHp;

    public TMP_Text txtName;
    public TMP_Text txtGold;
    public TMP_Text txtLevel;


    void Start()
    {
        RefreshState();
    }

    public void RefreshState()
    {
        var aa = GameManager.GetInstance().playersDatas[GameManager.GetInstance().characterIdx];
        GameManager.GetInstance().SaveData();
        txtLevel.text = $"Lv.{aa.level}";
        txtName.text = $"{aa.playerName}";
        txtGold.text = $"{aa.gold}gold";

        hpBar.maxValue = aa.totalHp;
        hpBar.value = aa.curHp;

        txtHp.text = $" {aa.curHp} / {aa.totalHp} ";

    }
}
