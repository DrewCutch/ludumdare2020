using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


[RequireComponent(typeof(Rigidbody))]
public class ForceMotor : MonoBehaviour
{
    public Transform Target { get; private set; }
    private Vector3 _direction;
    
    public bool On { get; private set; }

    public bool Hopper;
    public float HopInterval;

    public MotorMode Mode { get; private set; }

    public float MaxDistance { get; private set; }

    public float MinDistance { get; private set; }

    public float Speed;
    public float MaxSpeed;
    public float HopScale;
    
    private Rigidbody _rb;

    private float _hopWait;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _hopWait = 0;
    }

    void FixedUpdate()
    {
        if (!On)
            return;

        if (Mode == MotorMode.Target && Target == null)
            return;

        Vector3 dist = Mode == MotorMode.Direction
            ? _direction
            : (Target.position - transform.position);

        // If closer than desired distance, go in reverse
        int dir = dist.sqrMagnitude > MaxDistance * MaxDistance ? 1 : 
            dist.sqrMagnitude < MinDistance * MinDistance ? -1 :
            0;

        if (_rb.velocity.sqrMagnitude < MaxSpeed * MaxSpeed && !Hopper)
            _rb.AddForce(dist.normalized * Speed * dir);

        if (!Hopper)
            return;

        _hopWait += Time.deltaTime;

        if (_hopWait < HopInterval)
            return;

        _rb.AddForce((dist.normalized + Vector3.up * HopScale) * Speed * dir, ForceMode.Impulse);
        _hopWait -= HopInterval;
    }

    public void SetTarget(Transform transform, float minDistance, float maxDistance)
    {
        Target = transform;
        MinDistance = minDistance;
        MaxDistance = maxDistance;
        Mode = MotorMode.Target;
        On = true;
    }

    public void SetDirection(Vector3 direction, float minDistance, float maxDistance)
    {
        _direction = direction;
        MinDistance = minDistance;
        MaxDistance = maxDistance;
        Mode = MotorMode.Direction;
        On = true;
    }

    public void Stop()
    {
        On = false;
    }
}