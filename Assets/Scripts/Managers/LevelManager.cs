using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Levels[] _allLevels;
    public float _delayBetweenLevels;

    public bool isfinished;
	// Use this for initialization
	void Start () {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Level");
        _allLevels = new Levels[temp.Length];
        for(int i = 0; i < temp.Length; i++)
        {
            _allLevels[i] = temp[i].GetComponent<Levels>();
        }
        System.Array.Reverse(_allLevels);
        
        _allLevels[0].StartLevel();
        InvokeRepeating("StartLevel", 0.5f, 0.5f);
        isfinished = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(_allLevels[_allLevels.Length-1]._isFinished && !isfinished)
        {
            isfinished = true;
            GameManager.GetInstance().EndGame(true);
            GameObject.Find("P_Coeurs").GetComponent<ParticleSystem>().Play();
        }
	}

    void StartLevel()
    {
        for(int i =0; i < _allLevels.Length; i++)
        {
            if (_allLevels[i]._isFinished)
            {
                if(i != _allLevels.Length-1)
                {
                    _allLevels[i + 1].StartLevel();
                }
                else
                {
                    _allLevels[i].StartLevel();
                }
            }
        }
    }
}
