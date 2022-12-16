using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone

    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public Player playerData;

    public Player[] playersDatas = new Player[]
    {
        new Player("Character","goldSkull",1,0,100,100,1),
        new Player("Character2","silverSkull",1,500,120,120,1)
    };
    



    public int characterIdx = 0;  // 0 = gold 1 = silver

    //캐릭터 1
   // public int goldSkullhp = 100;
    public string goldSkullimg = "Character";

    //public int silverSkullhp = 100;
    public string silverSkullimg = "Character2";

    public void LoadData()
    {
        playerData.playerName = PlayerPrefs.GetString("playerName" , playersDatas[characterIdx].playerName);

        playerData.level = PlayerPrefs.GetInt("level", playersDatas[characterIdx].level);
        playerData.gold = PlayerPrefs.GetInt("gold", playersDatas[characterIdx].gold);
        playerData.totalHp = PlayerPrefs.GetInt("totalHp", playersDatas[characterIdx].totalHp);
        playerData.curHp = PlayerPrefs.GetInt("curHp", playersDatas[characterIdx].curHp);
    }
    public void SaveData()
    {
        PlayerPrefs.SetString("playerName", playersDatas[characterIdx].playerName);
        PlayerPrefs.SetInt("level", playersDatas[characterIdx].level);
        PlayerPrefs.SetInt("gold", playersDatas[characterIdx].gold);
        PlayerPrefs.SetInt("totalHp", playersDatas[characterIdx].totalHp);
        PlayerPrefs.SetInt("curHp", playersDatas[characterIdx].curHp);
    }


    public void AddGold(int gold)
    {
        playersDatas[characterIdx].gold += gold;
        SaveData();
    }

    public bool SpenGold(int gold)
    {
        if (playersDatas[characterIdx].gold >= gold)
        {
            playersDatas[characterIdx].gold -= gold;
            SaveData();
            return true;
        }

        return false;
    }

    public void AddLevel(int level)
    {
        playersDatas[characterIdx].level += level;
        SaveData();
    }

    public void IncreaseTotalHP(int addHp)
    {
        playersDatas[characterIdx].totalHp += addHp;
        SaveData();
    }

    public void SetCurrentHP(int hp)
    {
        playersDatas[characterIdx].curHp += hp;
        SaveData();
        if (playersDatas[characterIdx].curHp > playersDatas[characterIdx].totalHp)
            playersDatas[characterIdx].curHp = playersDatas[characterIdx].totalHp;


        if (playersDatas[characterIdx].curHp < 0)
            playersDatas[characterIdx].curHp = 0;

        // 위 함수는 curHp = Mathf.Clamp(curHp,0,100) 와 같다
    }

    public void Heal()
    {
        if (playersDatas[characterIdx].gold >= 100)
        {
            if (playersDatas[characterIdx].curHp < playersDatas[characterIdx].totalHp)
            {
                playersDatas[characterIdx].gold -= 100;
                playersDatas[characterIdx].curHp += 10;
                ObjectManager.GetInstance().HealEffect();
                Debug.Log("회복하였습니다.");

            }
        }
        else
            Debug.Log("돈이 부족합니다.");
        GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
        if (ui != null)
            ui.GetComponent<UIProfile>().RefreshState();
    }
}
