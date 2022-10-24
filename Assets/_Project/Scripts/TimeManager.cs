using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TimeManager : MonoBehaviour
{
    [SerializeField] float _time;
    [SerializeField] float _startedTime;
    [SerializeField] float _elapsedTime;
    [SerializeField] float _remainingTime;
    [SerializeField] bool _isValidTimer;

    public float TimerValue {get {return _time;} set { _time = value;}}

    public float StartedTime {get {return _startedTime;}}

    public float ElapsedTime {get {return _elapsedTime;}}

    public float RemainingTime {get {return _remainingTime;}}

    public bool IsValidTimer {get {return _isValidTimer;}}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isValidTimer)
        {
            if(_remainingTime < 0)
            {
                _remainingTime -= Time.deltaTime;
                _elapsedTime += Time.deltaTime;
            }
            else
            {
                
            }
        }   
    }

    public TimeManager(float timerValue)
    {
        _time = timerValue;
    }
    public void StartTimer(float timerValue)
    {
        _isValidTimer = true;
        _remainingTime = timerValue;
        _elapsedTime = 0;
        _startedTime = Time.time;
    }
    
    public void StopTimer()
    {
        _isValidTimer = false;
    }


}
