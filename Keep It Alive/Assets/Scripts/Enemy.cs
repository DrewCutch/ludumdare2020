using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ForceMotor))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Actor))]
[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour
{
    public int AttackCost;

    private Actor _self;
    private ForceMotor _motor;
    private Weapon _weapon;


    private Actor _target;
    // Start is called before the first frame update
    void Start()
    {
        _self = gameObject.GetComponent<Actor>();
        _motor = gameObject.GetComponent<ForceMotor>();
        _weapon = gameObject.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
            return;

        // If in range and has energy to attack
        if (Vector3.Distance(transform.position, _target.transform.position) < _weapon.WeaponType.MaxRange &&
            Vector3.Distance(transform.position, _target.transform.position) > _weapon.WeaponType.MinRange && 
            _self.HasEnergy(AttackCost))
        {
            _weapon.Attack(_target.transform);
            _self.UseEnergy(AttackCost);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Actor enemy = other.gameObject.GetComponent<Actor>();

        if (enemy == null)
            return;

        if (_self.Alignment.HasFlag(enemy.Alignment))
            return;

        //Ignore if further than current target
        if (_target != null &&
            Vector3.Distance(transform.position, enemy.transform.position) >
            Vector3.Distance(transform.position, _target.transform.position))
            return;

        print("setting target");
        _target = enemy;
        _motor.SetTarget(enemy.transform, _weapon.WeaponType.MinRange, _weapon.WeaponType.MaxRange);
    }

    private void OnTriggerExit(Collider other)
    {
        Actor enemy = other.gameObject.GetComponent<Actor>();

        if (enemy == null)
            return;

        if (_target == enemy)
        {
            _target = null;
            _motor.Stop();
        }
    }
}