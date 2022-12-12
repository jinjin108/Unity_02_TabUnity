using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScene : MonoBehaviour
{
    void Start()
    {
        Pt();
        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");
        Invoke("PtEnd", 3.0f);

    }

    public void Pt()
    {
        GameObject go = ObjectManager.GetInstance().CreateCharacterPractice();
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0.5f, 0.5f, 0);
        UIManager.GetInstance().SetEventSystem();

        GameObject goo = ObjectManager.GetInstance().Scarecrow();
        goo.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        goo.transform.localPosition = new Vector3(-0.5f, 0.3f, 0);

    }
    public void PtEnd()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
