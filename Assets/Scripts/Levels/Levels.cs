using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class Levels : MonoBehaviour {
    public Waves[] _wavesArray;
    public int[] _timeWaves;
    public Text _waveText;
    public Waves _currentWave;
    Waves m_lastWave;
    public float currentTime;
    public int currentIndex;
    public bool _isFinished;
    // Use this for initialization
    void Start () {
        currentIndex = 0;
        
        _isFinished = false;
        m_lastWave = _wavesArray[_wavesArray.Length - 1];

    }
	
	// Update is called once per frame
	void Update () {
        currentTime = Time.timeSinceLevelLoad;
        if(!m_lastWave._isSpawning && MonsterManager.GetInstance()._listOfMonster.Count == 0 && !_isFinished)
        {
            _isFinished = true;
        }
	}

    public void StartLevel()
    {
        InvokeRepeating("Spawn", 0.5f, 0.5f);
    }

    public void StartWave(int indexWave)
    {
        if(GameManager.GetInstance().gamestate == GameManager.GameState.playing)
        {
            _wavesArray[indexWave].StartSpawning();
            _currentWave = _wavesArray[indexWave];
            currentIndex++;
        }
    }

    public void Spawn()
    {
        if (GameManager.GetInstance().gamestate == GameManager.GameState.playing)
        {
            for (int i =0; i < _timeWaves.Length; i++)
            {
                if (currentTime > _timeWaves[i] && !_wavesArray[i]._hasStarted)
                {
                    Debug.Log("Start wave " + i);
                    StartWave(currentIndex);
                }
            }
        }

    }
}
