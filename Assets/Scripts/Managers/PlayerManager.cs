using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerManager : MonoBehaviour {
    private static PlayerManager _instance = null;

    public List<Player> _playerList = new List<Player>();
    // Use this for initialization
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            GameObject[] tempPlayers = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject parPlayers in tempPlayers)
            {
                _playerList.Add(parPlayers.GetComponent<Player>());
            }
            _playerList.Reverse();
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
