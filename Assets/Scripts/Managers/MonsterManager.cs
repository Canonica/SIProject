using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour {
    private static MonsterManager _instance = null;

    public static MonsterManager GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
    }

    public List<GameObject> _listOfMonster;


    void Start()
    {
        GameObject[] _tempMonsters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject parPlayers in _tempMonsters)
        {
            _listOfMonster.Add(parPlayers);
        }
    }

    public void AddMonster(GameObject parMonster)
    {
        _listOfMonster.Add(parMonster);
    }

    public void RemoveMonster(GameObject parMonster)
    {
        _listOfMonster.Remove(parMonster);
    }

}
