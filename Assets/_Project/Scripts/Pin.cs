using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private int _pinValue;
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public int PinValue {get {return _pinValue;} set {_pinValue = value;}}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void SetValue(int newValue)
    {
        _pinValue = newValue;
    }
}
