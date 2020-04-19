using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCast : MonoBehaviour
{
    public GameObject Shadow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hit, 20))
        {
            Shadow.transform.position = hit.point + new Vector3(0, .1f, 0);
        }
    }
}
