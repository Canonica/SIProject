using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Enemy")
        {
            MonsterManager.GetInstance().RemoveMonster(other.gameObject);
        }
        Destroy(other.gameObject);
    }
}
