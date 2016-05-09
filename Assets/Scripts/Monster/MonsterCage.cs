using UnityEngine;
using System.Collections;

public class MonsterCage : MonoBehaviour {
    public float _speed;
    NavMeshAgent _agent;
    public GameObject _target;
	// Use this for initialization
	void Start () {
        _agent = this.GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Cage");
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FindTarget()
    {
        _agent.SetDestination(_target.transform.position);
    }
}
