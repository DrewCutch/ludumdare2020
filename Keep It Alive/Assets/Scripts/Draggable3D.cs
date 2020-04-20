using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable3D : MonoBehaviour
{
    public GrabProfile GrabProfile;

    private Rigidbody _rb;
    private Plane _worldPlane;

    private float _startHeight;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _worldPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void OnMouseDown()
    {
        _startHeight = transform.position.y;
    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        Vector3 target = Vector3.zero;
        if (_worldPlane.Raycast(ray, out distance))
        {
            target = ray.GetPoint(distance) + new Vector3(0, _startHeight + GrabProfile.Lift, 0);
        }

        Vector3 dist = transform.position - target;
        _rb.AddForce(-dist * GrabProfile.DragStrength - _rb.velocity * GrabProfile.Damping);

        Quaternion rotation = Quaternion.identity * Quaternion.Inverse(_rb.rotation);
        var torque = new Vector3(rotation.x, rotation.y, rotation.z) * rotation.w / Time.fixedDeltaTime;
        _rb.AddTorque(torque * GrabProfile.AlignStrength);
        _rb.angularVelocity = Vector3.zero;
    }
}
