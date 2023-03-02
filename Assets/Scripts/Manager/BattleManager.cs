using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone

    private static BattleManager instance = null;

    public static BattleManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("@BattleManager");
                instance = go.AddComponent<BattleManager>();

                DontDestroyOnLoad(go);
            }
            return instance;
        }
        
    }
    #endregion
    public MonsterBase monsterData;


    public MonsterBase[] monsterDatas = new MonsterBase[]
    {
        new Monster1("Monster1",10,20,2.5f,300,1),
        new Monster2("Monster2",15,40,2f,1000,2),
        new Monster3("Monster3",20,25,3f,1000,3),
    };

    public MonsterBase GetRandomMonster()
    {
        int rand = Random.Range(0, monsterDatas.Length);

        return monsterDatas[rand];
    }

    public GameObject monsterObj;
    public void BattleStart(MonsterBase monster)
    {
        monsterData = monster;

        EffectManager.GetInstance().InitEffectPool(10);

        

        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }
    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().playersDatas[GameManager.GetInstance().characterIdx].curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            monsterData.Attack();

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
                ui.GetComponent<UIProfile>().RefreshState();


            Debug.Log($"용사에게 공격 당하였습니다. - 데미지 : {monsterData.atk}   남은체력 : {GameManager.GetInstance().playersDatas[GameManager.GetInstance().characterIdx].curHp}");
        }

        Lose();

    }

    void Victory()
    {
        Debug.Log("축하해~ 용사를 동료로 만들었어!");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");
        monsterObj.gameObject.SetActive(false);
        DieMonster();

        GameManager.GetInstance().AddGold(monsterData.gold);
        GameManager.GetInstance().AddLevel(monsterData.level);

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

        EffectManager.GetInstance().UseEffect();

        monsterData.hp --;

        Debug.Log($"MonsterName : {monsterData.GetMonsterName()} Hp : {monsterData.hp}");

        if (monsterData.hp <= 0)
            Victory();
    }

    public void DieMonster()
    {
        ParticleSystem particle = ObjectManager.GetInstance().dieEffect();
        particle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        particle.transform.localPosition = new Vector3(-0.5f, 0.5f, 0);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
