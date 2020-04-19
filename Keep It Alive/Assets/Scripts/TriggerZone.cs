using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerZone : MonoBehaviour
{
    public GameObject Target;

    public UnityEvent OnEnter;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject == Target)
            OnEnter?.Invoke();
    }
}
