using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMonster : MonoBehaviour {

    public int maxMonster;
    public int currentMonster;
    public float delayBetweenMonster;
    public List<MonsterCage> _monsterList = new List<MonsterCage>();
    public GameObject _monsterPrefab;

    bool isSpawning;
	// Use this for initialization
	void Start () {
        isSpawning = true;
        StartCoroutine(SpawnMob(maxMonster, delayBetweenMonster));
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnMob(int parMaxMonster, float parDelayBetweenMonster)
    {
        Debug.Log("1");
        while (isSpawning)
        {
            Debug.Log("2");
            if (currentMonster < parMaxMonster)
            {
                GameObject tempMonster = Instantiate(_monsterPrefab, this.transform.position, Quaternion.identity) as GameObject;
                MonsterCage tempMonsterComponent = tempMonster.GetComponent<MonsterCage>();
                _monsterList.Add(tempMonsterComponent);
                currentMonster++;
            }
            yield return new WaitForSeconds(parDelayBetweenMonster);
        }
    }
}
