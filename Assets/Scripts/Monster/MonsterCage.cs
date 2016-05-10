using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

public class MonsterCage : Monster {

	void Start () {
        _agent = this.GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Cage");
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
        
        
	}

    public override void FindTarget()
    {
        _agent.SetDestination(_target.transform.position);
    }

    public override void Attack(GameObject parCage)
    {
        parCage.transform.DOJump(parCage.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));
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

    void OnCollisionEnter(Collision parCollision)
    {
        

        if (parCollision.transform.parent != null && parCollision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            Debug.Log(parCollision.gameObject.tag);
            if (Vector3.Dot(transform.forward, parCollision.transform.forward) <= -0.75f && parCollision.gameObject.transform.parent.GetComponent<Player>().m_isShielding)
            {
                transform.DOMove(transform.position - (transform.forward * _counterBumpForce), 0.3f).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));
            }
            else
            {
                Debug.Log(parCollision.gameObject.tag);
                Attack(parCollision.gameObject.transform.parent.gameObject);
            }
        }
    }
}
