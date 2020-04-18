using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ForceMotor))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Actor))]
public class MeleeEnemy : MonoBehaviour
{
    public float Range;
    public int AttackCost;
    public int AttackDamage;

    private Actor _self;
    private ForceMotor _motor;

    private Actor _target;
    // Start is called before the first frame update
    void Start()
    {
        _self = gameObject.GetComponent<Actor>();
        _motor = gameObject.GetComponent<ForceMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
            return;

        // If in range and has energy to attack
        if (Vector3.Distance(transform.position, _target.transform.position) < Range && _self.HasEnergy(AttackCost))
        {
            _target.Health.Damage(AttackDamage);
            _self.UseEnergy(AttackCost);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
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
        _motor.SetTarget(enemy.transform, Range);
    }

    private void OnTriggerExit2D(Collider2D other)
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