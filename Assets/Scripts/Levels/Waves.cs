using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Waves : MonoBehaviour {

    public bool _isSpawning;
    public int _nbOfMonsters;
    public int _currentMonster;
    public int _timeBeforeSpawning;
    public float _delayBetweenMonster;
    public List<GameObject> _spawnerList = new List<GameObject>();
    public GameObject _monsterCagePrefab;
    public GameObject _monsterPlayerPrefab;

    // Use this for initialization
    void Start () {
        _isSpawning = true;
        GameObject[] tempSpawn = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject parSpawner in tempSpawn)
        {
            _spawnerList.Add(parSpawner);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartSpawning()
    {
        StartCoroutine(SpawnMob(_nbOfMonsters, _delayBetweenMonster));
    }

    IEnumerator SpawnMob(int parMaxMonster, float parDelayBetweenMonster)
    {
        while (_isSpawning)
        {
            int randomSpawner = Random.Range(0, _spawnerList.Count);
            int randomMonster = Random.Range(0, 2);
            if (_currentMonster < parMaxMonster)
            {
                if(randomMonster == 0)
                {
                    GameObject tempMonster = Instantiate(_monsterCagePrefab, _spawnerList[randomSpawner].transform.position, Quaternion.identity) as GameObject;
                    MonsterManager.GetInstance().AddMonster(tempMonster);
                    _currentMonster++;
                }
                else
                {
                    GameObject tempMonster = Instantiate(_monsterPlayerPrefab, _spawnerList[randomSpawner].transform.position, Quaternion.identity) as GameObject;
                    MonsterManager.GetInstance().AddMonster(tempMonster);
                    _currentMonster++;
                }
            }
            else
            {
                _isSpawning = false;
            }
            yield return new WaitForSeconds(parDelayBetweenMonster);
        }
    }

}
