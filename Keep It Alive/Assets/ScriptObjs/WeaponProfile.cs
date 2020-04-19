using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponProfile", menuName = "ScriptableObjects/WeaponProfile", order = 1)]
public class WeaponProfile : ScriptableObject
{
    public float MinRange;

    public float MaxRange;

    public int Damage;

    public float KnockBack;

    public bool IsRanged;

    public float ProjectileForce;

    public GameObject Projectile;


    public float Lead;

    public bool Attack(Transform from, Transform to)
    {
        float dist = Vector3.Distance(from.position, to.position);
        if (dist < MinRange || dist > MaxRange)
            return false;

        if(Projectile)
            FireProjectile(from, to);
        else
            Melee(from, to);

        return true;
    }

    private void FireProjectile(Transform origin, Transform target)
    {
        GameObject projectile = GameObject.Instantiate(Projectile, origin.position, Quaternion.identity);
        Rigidbody body = projectile.GetComponent<Rigidbody>();

        if (body == null)
            return;

        Vector3 targetPos = target.position + Vector3.right * Lead;

        Vector3 offset = targetPos - origin.position;
        Vector3 horizontalOffset = Vector3.ProjectOnPlane(offset, Vector3.up);
        Vector3 verticalOffset = offset - horizontalOffset;

        float g = Physics.gravity.y;
        float x = horizontalOffset.magnitude;
        float y = verticalOffset.y;
        float v = ProjectileForce;



        float theta = (
            Mathf.Acos(Mathf.Clamp(((g * x * x) / (v * v) + y) / (Mathf.Sqrt(y * y + x * x)), -1, 1)) + (Mathf.Abs(y) >= 0.1 ? Mathf.Atan(x / -y) : 0)) / 2;

        float xDir = y > 0 ? 1 : -1;

        Vector3 vel = horizontalOffset.normalized * Mathf.Cos(theta) * ProjectileForce * xDir +
                      Vector3.up * Mathf.Sin(theta) * ProjectileForce;

        body.AddForce(vel, ForceMode.VelocityChange);
    }


    private void Melee(Transform origin, Transform target)
    {
        RaycastHit[] hits = Physics.RaycastAll(origin.position, (target.position - origin.position).normalized * MaxRange);

        Damagable damagable = hits.Select(hit => hit.collider.gameObject.GetComponent<Damagable>())
            .First(component => component != null);

        damagable.Damage(Damage);

        Rigidbody body = hits.Select(hit => hit.rigidbody).First(rb => rb != null);

        if (body == null)
            return;

        body.AddForce((target.position - origin.position).normalized * KnockBack, ForceMode.Impulse);
    }
}
