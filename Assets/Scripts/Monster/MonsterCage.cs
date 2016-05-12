using UnityEngine;
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
        if(!this._isStuned)
        {
            _agent.ResetPath();
            _agent.SetDestination(_target.transform.position);
        }
       
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
        this._isStuned = true;
        if (_agent.enabled)
        {
            _agent.Stop();
            Debug.Log("stop");
        }
        Invoke("Reset", parTime);
        
        Debug.Log("time" +parTime);
        yield return null;

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
                this._currentBumpDirection = -transform.forward;
                this._isBumped = true;
                transform.DOMove(transform.position - (transform.forward * _counterBumpForce), 0.3f).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad)).OnComplete(() => this._isBumped = false);
            }
            else if(!parCollision.gameObject.transform.parent.gameObject.GetComponent<Player>()._isBumped)
            {
                Attack(parCollision.gameObject.transform.parent.gameObject);
            }
        }
    }

    void Reset()
    {
        Debug.Log("avant");
        if (_agent.enabled)
        {
            Debug.Log("time");
            this._isStuned = false;
            //this._isBumped = false;
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

        if (_isBumped)
        {
            CheckCollision(this._currentBumpDirection);
        }
    }

    void CheckCollision(Vector3 parDirection)
    {
        RaycastHit m_hit;
        if (Physics.SphereCast(transform.position, gameObject.GetComponent<CapsuleCollider>().radius, parDirection, out m_hit, Mathf.Infinity))
        {
            if ((m_hit.collider.tag == "Obstacle" || m_hit.collider.name == "Cage") && m_hit.distance <= gameObject.GetComponent<CapsuleCollider>().radius + 0.1f)
            {
                Debug.Log("test");
                Vector3 _tempPosition = transform.position;
                transform.DOKill(true);
                transform.DOMove(_tempPosition, 0.0f).OnComplete(() => this._isBumped = false);

            }
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
