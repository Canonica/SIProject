﻿using UnityEngine;
using System.Collections;
using DG.Tweening;


public class MonsterPlayer : Monster {
    public float _bumpMultiplier;

    void Start()
    {

        _agent = this.GetComponent<NavMeshAgent>();
        int randPlayer = Random.Range(1, PlayerManager.GetInstance()._playerList.Count);
        _target = GameObject.Find("Player" + randPlayer);
        InvokeRepeating("FindTarget", 0.5f, 0.5f);


    }

    public override void FindTarget()
    {
        if(_target != null)
        {
            _agent.SetDestination(_target.transform.position);
        }else
        {
            if(PlayerManager.GetInstance()._playerList.Count > 0)
            {
                int randPlayer = Random.Range(1, PlayerManager.GetInstance()._playerList.Count);
                _target = GameObject.Find("Player" + randPlayer);
            }else
            {
                _target = GameObject.Find("Cage");
            }
            
        }
        
    }

    public override void Attack(GameObject parPlayer)
    {
        parPlayer.GetComponent<Player>()._currentBumpDirection = transform.position - parPlayer.transform.position;
        parPlayer.GetComponent<Player>()._isBumped = true;
        parPlayer.transform.DOJump(parPlayer.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad))
            .OnComplete(()=> parPlayer.GetComponent<Player>()._isBumped = false);
        
    }

    void OntTriggerEnter(Collider other)
    {
        if (other.tag == "DeathZone")
        {
            Death();
        }
    }

    public override void Death()
    {

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
}