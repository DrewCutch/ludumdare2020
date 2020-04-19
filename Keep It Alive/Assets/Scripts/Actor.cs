using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Damagable))]
public class Actor : MonoBehaviour
{
    public Alignment Alignment;

    public int MaxEnergy;

    public int Energy;

    public int EnergyRecovery;

    public Damagable Health { get; private set; }

    private float _recovering;

    // Start is called before the first frame update
    void Start()
    {
        Energy = 0;
        Health = gameObject.GetComponent<Damagable>();
        Health.OnDestroyed.AddListener(OnDie);
    }

    private void OnDie()
    {
        print("I'm dead!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Energy < MaxEnergy)
            _recovering += Time.deltaTime * EnergyRecovery;

        if (_recovering > 1)
        {
            Energy += (int) _recovering;
            _recovering -= (int)_recovering;
        }
    }

    public bool HasEnergy(int amount) => amount <= Energy;

    public bool UseEnergy(int amount)
    {
        if (amount > Energy)
            return false;

        Energy -= amount;
        return true;
    }
}
