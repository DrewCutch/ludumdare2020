using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public Renderer[] Hide;

    public void Kill()
    {
        foreach (Renderer rend in Hide)
        {
            rend.enabled = false;
        }
        Destroy(gameObject, 1);
    }
}
