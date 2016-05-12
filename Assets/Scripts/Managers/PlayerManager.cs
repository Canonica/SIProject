using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerManager : MonoBehaviour {
    private static PlayerManager _instance = null;

    public List<Player> _playerList = new List<Player>();
    public int m_nbOfPlayerAlive;
    public int _nbOfPlayers;
    public GameObject[] _spawnerPlayers;
    public GameObject[] _playersPrefab;

    public static PlayerManager GetInstance()
    {
        return _instance;
    }

    // Use this for initialization
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        _playersPrefab = new GameObject[4];
        _spawnerPlayers = new GameObject[4];
        for (int i=1; i<5; i++)
        {
            _playersPrefab[i - 1] = Resources.Load("Prefabs/Player" + i) as GameObject;
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            GameObject[] tempSpawners = GameObject.FindGameObjectsWithTag("PlayerSpawner");
            for (int i = 0; i< tempSpawners.Length; i++)
            {
                _spawnerPlayers[i] = tempSpawners[i];
            }

            for(int i = 0; i < _nbOfPlayers; i++)
            {
                Instantiate(_playersPrefab[i], _spawnerPlayers[i].transform.position, Quaternion.identity);
            }
            GameObject[] tempPlayers = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject parPlayers in tempPlayers)
            {
                _playerList.Add(parPlayers.GetComponent<Player>());
            }
            _playerList.Reverse();
        }
    }

    public void NumberOfPlayerAlive()
    {
        m_nbOfPlayerAlive = 0;
        foreach (Player parPlayers in _playerList)
        {
            if (parPlayers.m_needHelp)
            {
                m_nbOfPlayerAlive++;
            }
        }
    }
}
