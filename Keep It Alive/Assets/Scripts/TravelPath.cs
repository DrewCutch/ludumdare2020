using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TravelPath : MonoBehaviour
{
    public Transform[] Points;

    void OnDrawGizmosSelected()
    {
        Transform last = Points[0];
        foreach (Transform point in Points)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(last.position, point.position);
            Gizmos.DrawCube(point.position, Vector3.one);
            last = point;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
