using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Draggable : MonoBehaviour
{

    public Camera MainCamera;
    public float DragStrength;
    public float Damping;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
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
        Vector2 dist = transform.position - MainCamera.ScreenToWorldPoint(Input.mousePosition);
        _rb.AddForce(-dist * DragStrength - _rb.velocity * Damping);
    }
}
