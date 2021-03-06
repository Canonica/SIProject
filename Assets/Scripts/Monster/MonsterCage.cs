﻿using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

public class MonsterCage : Monster {

    void Start () {
        _agent = this.GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Cage");
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
        InvokeRepeating("CheckUnder", 0.5f, 0.5f);

    }

    public override void FindTarget()
    {
        _agent.ResetPath();
        _agent.SetDestination(_target.transform.position);
    }

    public override void Attack(GameObject parCage)
    {
        parCage.GetComponent<Player>()._currentBumpDirection = transform.position - parCage.transform.position;
        parCage.GetComponent<Player>()._isBumped = true;
        parCage.transform.DOJump(parCage.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad))
            .OnComplete(() => parCage.GetComponent<Player>()._isBumped = false);
    }

    public override IEnumerator Stun(float parTime)
    {
        if (_agent.enabled)
        {
            _agent.Stop();
            Invoke("Reset", parTime);
        }
        
        Debug.Log("before");
        yield return new WaitForSeconds(parTime);
        
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
            if (Vector3.Dot(transform.forward, parCollision.transform.forward) <= -0.75f && parCollision.gameObject.transform.parent.GetComponent<Player>().m_isShielding)
            {
                transform.DOMove(transform.position - (transform.forward * _counterBumpForce), 0.3f).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));
            }
            else if(!parCollision.gameObject.transform.parent.gameObject.GetComponent<Player>()._isBumped)
            {
                Attack(parCollision.gameObject.transform.parent.gameObject);
            }
        }
    }

    void Reset()
    {
        if (_agent.enabled)
        {
            _agent.ResetPath();
            FindTarget();
        }
        
    }
    void Update()
    {
        if (this.m_isFlying)
        {
            this.transform.position = transform.position + -transform.up * _speed * Time.deltaTime;
        }
    }

    void CheckUnder()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, this.gameObject.GetComponent<BoxCollider>().extents.x, -transform.up, out hit, 3f))
        {

            if (hit.transform.tag == "Ground")
            {

                this.m_isFlying = false;
            }
        }
        else
        {
            if (_agent.enabled)
            {
                this._agent.Stop();
            }
            
            CancelInvoke("FindTarget");
            _agent.enabled = false;
            this.m_isFlying = true;
        }
    }
}
