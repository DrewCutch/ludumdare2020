using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable3D : MonoBehaviour
{

    public Camera MainCamera;
    public float DragStrength;
    public float Damping;

    public float GroundOffset;

    private Rigidbody _rb;
    private Plane _worldPlane;


    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _worldPlane = new Plane(Vector3.up, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        Vector3 target = Vector3.zero;
        if (_worldPlane.Raycast(ray, out distance))
        {
            target = ray.GetPoint(distance) + new Vector3(0, GroundOffset, 0);
        }

        Vector3 dist = transform.position - target;
        _rb.AddForce(-dist * DragStrength - _rb.velocity * Damping);
    }
}
