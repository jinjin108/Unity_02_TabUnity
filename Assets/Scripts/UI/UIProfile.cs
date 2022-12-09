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
        txtLevel.text = $"Lv.{GameManager.GetInstance().level}";
        txtName.text = $"{GameManager.GetInstance().playerName}";
        txtGold.text = $"{GameManager.GetInstance().gold}gold";

        hpBar.maxValue = GameManager.GetInstance().totalHp;
        hpBar.value = GameManager.GetInstance().curHp;

        txtHp.text = $" {GameManager.GetInstance().curHp} / {GameManager.GetInstance().totalHp} ";

    }
}
