using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Pin[] _pins;
    [SerializeField] private int _properPinsValue;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private float _gameTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _timeManager = new TimeManager(_gameTime);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CheckPins(){

        foreach(Pin pin in _pins)
        {
            if(pin.PinValue == _properPinsValue)
            {
                
            }
            else return;
        }
        FinishGame();
    }

    public void FinishGame()
    {
        _timeManager.StopTimer();
        Debug.Log("Вы взломали замок");
    }

    public void ChangePinsValues(int firstValue, int secondValue, int thirdValue)
    {
        _pins[0].SetValue(firstValue);
        _pins[1].SetValue(secondValue);
        _pins[3].SetValue(thirdValue);
        CheckPins();
    }
}
