using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMonster : MonoBehaviour {

    public int maxMonster;
    public int currentMonster;
    public float delayBetweenMonster;
    public List<GameObject> _monsterList = new List<GameObject>();
    public List<GameObject> _spawnerList = new List<GameObject>();
    public GameObject _monsterCagePrefab;
    public GameObject _monsterPlayerPrefab;

    bool isSpawning;
	// Use this for initialization
	void Start () {
        isSpawning = true;
        GameObject[] tempSpawn = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject parSpawner in tempSpawn)
        {
            _spawnerList.Add(parSpawner);
        }
        StartSpawning();
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartSpawning()
    {
        StartCoroutine(SpawnMob(maxMonster, delayBetweenMonster));
    }

    IEnumerator SpawnMob(int parMaxMonster, float parDelayBetweenMonster)
    {
        while (isSpawning)
        {
            int randomSpawner = Random.Range(0, _spawnerList.Count);
            if (currentMonster < parMaxMonster)
            {
                currentMonster++;
                GameObject tempMonster = Instantiate(_monsterCagePrefab, _spawnerList[randomSpawner].transform.position+new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
                if(MonsterManager.GetInstance()._listOfMonster.Count > 0 && MonsterManager.GetInstance()._listOfMonster[0] != tempMonster)
                {
                    MonsterManager.GetInstance().AddMonster(tempMonster);
                }
                
                
            }
            yield return new WaitForSeconds(parDelayBetweenMonster);
        }
    }
}
