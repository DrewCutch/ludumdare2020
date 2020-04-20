using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Damagable Damagable;

    public Image HealthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        Damagable.OnDamaged.AddListener(UpdateBar);
        Damagable.OnHealed.AddListener(UpdateBar);
    }

    void UpdateBar()
    {
        HealthBar.fillAmount = (float) Damagable.Health / Damagable.MaxHealth;
    }
}
