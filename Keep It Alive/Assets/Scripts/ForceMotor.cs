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

    public float DesiredDistance { get; private set; }

    public float Speed;
    public float MaxSpeed;
    
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!On)
            return;

        Vector3 dist = Mode == MotorMode.Direction
            ? _direction
            : (_target.position - transform.position);

        // If closer than desired distance, go in reverse
        int dir = dist.sqrMagnitude > DesiredDistance * DesiredDistance ? 1 : -1;

        if (_rb.velocity.sqrMagnitude < MaxSpeed * MaxSpeed)
            _rb.AddForce(dist.normalized * Speed * dir);
    }

    public void SetTarget(Transform transform, float desiredDistance=0)
    {
        _target = transform;
        DesiredDistance = desiredDistance;
        Mode = MotorMode.Target;
        On = true;
    }

    public void SetDirection(Vector3 direction, float desiredDistance = 0)
    {
        _direction = direction;
        DesiredDistance = desiredDistance;
        Mode = MotorMode.Direction;
        On = true;
    }

    public void Stop()
    {
        On = false;
    }
}