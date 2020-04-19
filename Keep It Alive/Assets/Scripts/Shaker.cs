using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float Intensity;
    public float Duration;

    public float AutoRepeat;

    private float _time;


    public static Shaker MainCameraShaker;

    void Awake()
    {
        MainCameraShaker = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //_time += Time.deltaTime;

        if (_time >= AutoRepeat)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-Intensity, Intensity), Random.Range(-Intensity, Intensity), Random.Range(-Intensity, Intensity), ForceMode.VelocityChange);
            _time -= AutoRepeat;
        }
    }

    public void ShakeFrom(Vector3 pos)
    {
        gameObject.GetComponent<Rigidbody>().AddForce((pos - transform.position).normalized * Intensity, ForceMode.VelocityChange);
        _time -= AutoRepeat;
    }
}