using UnityEngine;
using System.Collections;
using System;

public class MonsterCage : Monster {

	void Start () {
        _agent = this.GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Cage");
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
	}

    void FindTarget()
    {
        _agent.SetDestination(_target.transform.position);
    }

    public override void Attack()
    {

    }

    void OntTriggerEnter(Collider other)
    {
        if(other.tag == "DeathZone")
        {
            Death();
        }
    }

    public override void Death()
    {
        Destroy(this.gameObject);
    }
}
