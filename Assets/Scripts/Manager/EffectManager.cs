using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    #region Singletone

    private static EffectManager instance = null;

    public static EffectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@EffectManager");
            instance = go.AddComponent<EffectManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion


   
    Stack<ParticleSystem> effcetPool = new Stack<ParticleSystem>();
    public void InitEffectPool(int size)
    {
        for(int i = 0; i < size; i++)
        {
           var effect = ObjectManager.GetInstance().CreateHitEffect();
            effect.gameObject.SetActive(false);
            effcetPool.Push(effect);

        }
    }

    public void ReleasePool()
    {
        effcetPool.Clear();
    }

    public void UseEffect()
    {

        if (effcetPool.Count > 0)
        {
            var effect = effcetPool.Pop();
            effect.gameObject.SetActive(true);
            effect.Play();

            float randX = Random.Range(-1, 2);
            float randy = Random.Range(0, 1.5f);

            effect.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            effect.transform.localPosition = new Vector3(randX, randy, -0.5f);
        }
    }

    public void ReturnEffect(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
        effcetPool.Push(particle);
    }

}
