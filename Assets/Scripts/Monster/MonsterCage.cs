using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

public class MonsterCage : Monster {

    public GameObject _spawnFx;
    public GameObject _bloodFx;
    void Start () {
        _agent = this.GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Cage");
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
        InvokeRepeating("CheckUnder", 0.5f, 0.1f);
        _spawnFx = Resources.Load("Prefabs/P_Spawn") as GameObject;
        Instantiate(_spawnFx);
        _spawnFx.transform.position = this.transform.position;
        _spawnFx.GetComponent<ParticleSystem>().Play();
        _bloodFx = Resources.Load("Prefabs/P_Blood") as GameObject;

    }

    public override void FindTarget()
    {
        if(!this._isStuned)
        {
            if (_target != null)
            {
                _agent.ResetPath();
                _agent.SetDestination(_target.transform.position);
            }
        }
       
    }

    public override void Attack(GameObject parCage)
    {
        GetComponent<MonsterAnimationManager>().StartAttack();
        parCage.GetComponent<PlayerAnimationManager>().CancelInvoke("EndStun");
        Vector3 m_bumpDirection = new Vector3(parCage.transform.position.x, 0f, parCage.transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z);
        parCage.GetComponent<Player>()._currentBumpDirection = m_bumpDirection;

        parCage.GetComponent<Player>()._currentBumpDirection = m_bumpDirection;
        parCage.GetComponent<Player>()._isBumped = true;
        parCage.GetComponent<PlayerAnimationManager>().StartBump();
        parCage.transform.DOJump(parCage.transform.position + (m_bumpDirection * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad))
            .OnComplete(() => parCage.GetComponent<Player>()._isBumped = false);
        StartCoroutine(parCage.GetComponent<Player>().Stun());
    }

    public override IEnumerator Stun()
    {
        this.GetComponent<ClignotageMonster>().HitClignote();
        this._isStuned = true;
        if (_agent.enabled)
        {
            _agent.Stop();
        }
        GetComponent<MonsterAnimationManager>().StopBump();
        GameObject tempBlood = Instantiate(_bloodFx, transform.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(-90, 0, 0)) as GameObject;
        Destroy(tempBlood, 2f);
        Invoke("Reset", parTime);
        
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
        if (parCollision.transform.parent != null && parCollision.gameObject.transform.parent.gameObject.tag == "Player" && !_isStuned)
        {
            if (Vector3.Dot(transform.forward, parCollision.transform.forward) <= -0.75f && parCollision.gameObject.transform.parent.GetComponent<Player>().m_isShielding)
            {
                this._currentBumpDirection = -transform.forward;
                this._isBumped = true;
                transform.DOMove(transform.position - (transform.forward * _counterBumpForce), 0.3f).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad)).OnComplete(() => this._isBumped = false);
                GetComponent<MonsterAnimationManager>().LaunchBump();
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
            if ((m_hit.collider.tag == "Obstacle" || m_hit.collider.name == "Cage" || m_hit.collider.tag == "MoveObstacle") && m_hit.distance <= gameObject.GetComponent<CapsuleCollider>().radius + 0.1f)
            {
                if (m_hit.collider.tag == "MoveObstacle")
                {
                    m_hit.collider.gameObject.GetComponent<BumpObstacle>().Bump(parDirection);
                }
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
            GetComponent<MonsterAnimationManager>().StartFalling();
        }
    }
}
