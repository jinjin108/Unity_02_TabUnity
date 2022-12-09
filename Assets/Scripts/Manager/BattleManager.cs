using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone

    private static BattleManager instance = null;

    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager");
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion
    public Monster1 monsterData;

    GameObject uiTab;

    GameObject monsterObj;
    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        monsterObj = ObjectManager.GetInstance().CreateMonster();
        monsterObj.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        monsterObj.transform.localPosition = new Vector3(0, 0.6f, 0);

        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }
    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHP(-damage);

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
                ui.GetComponent<UIProfile>().RefreshState();


            Debug.Log($"용사에게 공격 당하였습니다. - 데미지 : {damage}   남은체력 : {GameManager.GetInstance().curHp}");
        }

        Lose();

    }

    void Victory()
    {
        Debug.Log("게임에서 승리하였습니다");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");
        monsterObj.gameObject.SetActive(false);
        DieMonster();

        GameManager.GetInstance().AddGold(monsterData.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("게임에서 패배하였습니다.");
        if (GameManager.GetInstance().SpenGold(500))
            GameManager.GetInstance().SetCurrentHP(80);
        else
            GameManager.GetInstance().SetCurrentHP(10);

        Invoke("MoveToMain", 2.5f);


    }

    public void AttackMonster()
    {
        float randX = Random.Range(-1, 2);
        float randy = Random.Range(0, 1.5f);

        var particle = ObjectManager.GetInstance().CreateHitEffect();
        particle.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        particle.transform.localPosition = new Vector3(randX, randy, -0.5f);



        monsterData.hp--;

        if (monsterData.hp <= 0)
            Victory();
    }

    public void DieMonster()
    {
        ParticleSystem particle = ObjectManager.GetInstance().dieEffect();
        particle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        particle.transform.localPosition = new Vector3(0, 0, -0.5f);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
