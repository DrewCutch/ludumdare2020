using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ForceMotor))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Actor))]
[RequireComponent(typeof(Weapon))]
public class Fighter : MonoBehaviour
{
    public int AttackCost;

    public Transform Goal;

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
        {
            if (Goal != null && _motor.Target != Goal)
                _motor.SetTarget(Goal, 1, 2);

            return;
        }

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
        
        _target = enemy;
        _target.Health.OnDestroyed.AddListener(GetNewTarget);

        _motor.SetTarget(enemy.transform, _weapon.WeaponType.MinRange, _weapon.WeaponType.MaxRange);
    }

    private void GetNewTarget()
    {
        if(_motor.Target != Goal)
            _motor.Stop();

        _target = Physics.OverlapSphere(transform.position, 10)
            .Select(collider1 => collider1.gameObject.GetComponent<Actor>()).First(act => act != null && act != _target);

        if(_target != null)
            SetTarget(_target.transform);
    }

    private void SetTarget(Transform target)
    {
        _motor.SetTarget(target, _weapon.WeaponType.MinRange, _weapon.WeaponType.MaxRange);
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