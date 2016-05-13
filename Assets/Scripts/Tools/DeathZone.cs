using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {
    public GameObject fallLava;
	// Use this for initialization
	void Start () {
        fallLava = Resources.Load("Prefabs/P_FallLava") as GameObject;
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
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        else
        {
            if(other.gameObject.name == "Cage")
            {

                GameManager.GetInstance().EndGame(false);
            }
            Destroy(other.gameObject);
        }
        GameObject temp = Instantiate(fallLava, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.Euler(270, 0, 0)) as GameObject;
        Destroy(temp, 2f);

    }
}
