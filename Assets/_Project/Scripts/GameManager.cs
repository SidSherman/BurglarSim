using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Pin[] _pins;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private UIHandler _uiHandler;
    [SerializeField] private InstrumentsValue _hammer;
    [SerializeField] private InstrumentsValue _screw;
    [SerializeField] private InstrumentsValue _picklock;
    [SerializeField] private LevelValue[] levels;
   
    [SerializeField] private int _currentLevel;
    [SerializeField] private float _gameTime;

    private int _properPinsValue;

    public InstrumentsValue Hammer { get => _hammer; set => _hammer = value; }
    public InstrumentsValue Screw { get => _screw; set => _screw = value; }
    public InstrumentsValue Picklock { get => _picklock; set => _picklock = value; }

 
    void Update()
    {
      
        _uiHandler.UpdateUI(
            _pins[0].PinValue.ToString(),
            _pins[1].PinValue.ToString(),
            _pins[2].PinValue.ToString(),
            _timeManager.RemainingTime / _timeManager.TimerValue);

        if(_timeManager.IsFinishedTimer)
        {

            FailGame();
        }
    }
    
    public void CheckPins(){

        foreach(Pin pin in _pins)
        {
            if(pin.PinValue != _properPinsValue)
            {
                return;
            }
        }

        FinishGame();
    }

    public void FinishGame()
    {
     
        _uiHandler.ShowFinishPanel(true);
        _currentLevel++;
        _timeManager.StopTimer();
    }

    public void FailGame()
    {    
        _uiHandler.ShowFinishPanel(false);
    }

    public void PauseGame()
    {
        _timeManager.PauseTimer();
      
    }

    public void ResumeGame()
    {
        _timeManager.ResumeTimer();
    }

    public void StartGame()
    {
        if (_currentLevel >= levels.Length)
        {
            Debug.Log("Последний уровень пройден");
            _uiHandler.SetBlockPanel(true);
            return;
        }

        ChangePinsValues(levels[_currentLevel].Pins.Pin1, levels[_currentLevel].Pins.Pin2, levels[_currentLevel].Pins.Pin3);
        _properPinsValue = levels[_currentLevel].TargetValue;
        _timeManager.StartTimer(_gameTime);
        _uiHandler.SetUIOnTheStart(Hammer, Screw, Picklock, _properPinsValue.ToString());
        _timeManager.StartTimer(_gameTime);
    }

    public void ChangePinsValues(int firstValue, int secondValue, int thirdValue)
    {
        _pins[0].SetValue(firstValue);
        _pins[1].SetValue(secondValue);
        _pins[2].SetValue(thirdValue);
        
    }
    public void ChangePinsValues(InstrumentsValue instrument)
    {
        _pins[0].SetValue(_pins[0].PinValue + instrument.Pin1);
        _pins[1].SetValue(_pins[1].PinValue + instrument.Pin2);
        _pins[2].SetValue(_pins[2].PinValue + instrument.Pin3);
    }

    public void RestartGame()
    {
        ChangePinsValues(levels[_currentLevel].Pins.Pin1, levels[_currentLevel].Pins.Pin2, levels[_currentLevel].Pins.Pin3);
        _uiHandler.SetBlockPanel(false);
    }

    // does not work correctly
    private void GameValuesGenerator()
    {
        _properPinsValue =  Random.Range(1,10);

        int[] hammerValues = new int[3] { Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6) };
        int[] screwValues = new int[3] { Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6) };
        int[] picklockValues = new int[3] { Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6) };

        int hammerMult = Random.Range(1,15);
        int screwMult = Random.Range(1, 15);
        int picklockMult = Random.Range(1, 15);

        int i = 0;
        while ((hammerValues[0] * hammerMult + screwValues[0] * screwMult + picklockValues[0]* picklockMult) != _properPinsValue
            && (hammerValues[1] * hammerMult + screwValues[1] * screwMult + picklockValues[1] * picklockMult) != _properPinsValue
            && (hammerValues[2] * hammerMult + screwValues[2] * screwMult + picklockValues[2] * picklockMult) != _properPinsValue 
            )
        {
            hammerValues = new int[3] { Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6) };
            screwValues = new int[3] { Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6) };
            picklockValues = new int[3] { Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6) };

            hammerMult = Random.Range(1, 15);
            screwMult = Random.Range(1, 15);
            picklockMult = Random.Range(1, 15);
            i++;
            if(i > 1000)
            {
                break;
            }
        }

        Debug.Log("hammerMult" + hammerMult);
        Debug.Log("screwMult" + screwMult);
        Debug.Log("picklockMult" + picklockMult);

        Hammer = new InstrumentsValue(hammerValues[0], hammerValues[1], hammerValues[2]);
        Screw = new InstrumentsValue(screwValues[0], screwValues[1], screwValues[2]);
        Picklock = new InstrumentsValue(picklockValues[0], picklockValues[1], picklockValues[2]);


    }

}

