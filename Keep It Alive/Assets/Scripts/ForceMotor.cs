using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


[RequireComponent(typeof(Rigidbody2D))]
public class ForceMotor : MonoBehaviour
{
    private Transform _target;
    private Vector3 _direction;
    
    public bool On { get; private set; }

    public MotorMode Mode { get; private set; }

    public float Speed;
    public float MaxSpeed;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!On)
            return;

        Vector3 direction = Mode == MotorMode.Direction
            ? _direction
            : (_target.position - transform.position).normalized;
        
        if (_rb.velocity.sqrMagnitude < MaxSpeed * MaxSpeed)
            _rb.AddForce(direction * Speed);
    }

    public void SetTarget(Transform transform)
    {
        _target = transform;
        Mode = MotorMode.Target;
        On = true;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        Mode = MotorMode.Direction;
        On = true;
    }

    public void Stop()
    {
        On = false;
    }
}