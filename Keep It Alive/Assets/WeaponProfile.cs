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

    public bool IsRanged;

    public float ProjectileForce;

    public GameObject Projectile;

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

        Vector3 offset = target.position - origin.position;
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
    }
}
