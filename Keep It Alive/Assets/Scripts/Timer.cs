using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float Duration;
    public bool Loop;
    public bool AutoStart;

    public UnityEvent OnFinish;

    private bool _running;
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        _running = AutoStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_running)
            return;

        _time += Time.deltaTime;

        if (_time >= Duration)
        {
            OnFinish?.Invoke();
            _time -= Duration;
            _running = Loop;
        }
    }

    public void StartTimer()
    {
        _running = true;
    }
}
