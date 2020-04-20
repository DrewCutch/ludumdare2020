using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroTrigger : MonoBehaviour
{
    public GameObject Hero;

    public UnityEvent OnHeroEnter;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == Hero)
            OnHeroEnter?.Invoke();
    }
}
