using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform Target;

    public float Lead;

    private Vector3 _offset;

    public float MaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Target.position;
        print("offset: " + _offset);
    }

    // Update is called once per frame
    void Update()
    {
        float forwardX = Target.position.x + Lead;

        float targetX = Mathf.Max((forwardX * 2 + IsoUtils.ScreenToIso(Input.mousePosition).x) / 3, forwardX);

        transform.position = Vector3.Lerp(transform.position,
            new Vector3(targetX, transform.position.y, transform.position.z), Time.deltaTime * MaxSpeed);
    }
}
