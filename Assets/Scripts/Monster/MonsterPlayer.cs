using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MonsterPlayer : Monster {
    public float _bumpMultiplier;

    void Start()
    {
        this._isStuned = false;
        _agent = this.GetComponent<NavMeshAgent>();
        int randPlayer = Random.Range(1, PlayerManager.GetInstance()._playerList.Count+1);
        _target = GameObject.Find("Player" + randPlayer);
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
        InvokeRepeating("CheckUnder", 0.5f, 0.1f);


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
                Vector3 _tempPosition = transform.position;
                transform.DOKill(true);
                transform.DOMove(_tempPosition, 0.0f).OnComplete(() => this._isBumped = false);

            }
        }
    }

    public override IEnumerator Stun()
    {
        this._isStuned = true;
        if (_agent.enabled)
        {
            this._agent.Stop();
        }
        GetComponent<MonsterAnimationManager>().StopBump();
        Invoke("Reset", _stunTimeMonster);
        yield return null;
        
    }

    void Reset()
    {

        if (_agent.enabled)
        {
            this._isStuned = false;
            //this._isBumped = false;
            this._agent.ResetPath();
            FindTarget();
        }

    }

    public override void FindTarget()
    {
        if(_target != null && !this._isStuned )
        {
            if(_target.GetComponent<Player>())
            {
                if(!_target.GetComponent<Player>().m_needHelp)
                {
                    _agent.ResetPath();
                    _agent.SetDestination(_target.transform.position);
                }else
                {
                    if (PlayerManager.GetInstance()._playerList.Count > 0)
                    {
                        int randPlayer = Random.Range(0, PlayerManager.GetInstance()._playerList.Count);
                        //_target = GameObject.Find("Player" + randPlayer);
                        _target = PlayerManager.GetInstance()._playerList[randPlayer].gameObject;
                    }
                    else
                    {
                        _target = GameObject.FindGameObjectWithTag("Cage");
                    }
                }
                
            }
            else if(!_target.GetComponent<Player>())
            {
                _agent.ResetPath();
                _agent.SetDestination(_target.transform.position);
            }
            
        }else
        {
            if(PlayerManager.GetInstance()._playerList.Count > 0)
            {
                int randPlayer = Random.Range(0, PlayerManager.GetInstance()._playerList.Count);
                //_target = GameObject.Find("Player" + randPlayer);
                _target = PlayerManager.GetInstance()._playerList[randPlayer].gameObject;
            }
            else
            {
                _target = GameObject.FindGameObjectWithTag("Cage");
            }
            
        }
        
    }

    public override void Attack(GameObject parPlayer)
    {
        parPlayer.GetComponent<PlayerAnimationManager>().CancelInvoke("EndStun");
        Vector3 m_bumpDirection = new Vector3(parPlayer.transform.position.x, 0f, parPlayer.transform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z);
        parPlayer.GetComponent<Player>()._currentBumpDirection = m_bumpDirection;
        parPlayer.GetComponent<Player>()._isBumped = true;
        parPlayer.GetComponent<PlayerAnimationManager>().StartBump() ;
        parPlayer.transform.DOJump(parPlayer.transform.position + (m_bumpDirection * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad))
            .OnComplete(()=> parPlayer.GetComponent<Player>()._isBumped = false);
        StartCoroutine(parPlayer.GetComponent<Player>().Stun());

        
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

        if (parCollision.transform.parent != null && parCollision.gameObject.transform.parent.gameObject.tag == "Player" && !_isStuned)
        {
            if (Vector3.Dot(transform.forward, parCollision.transform.forward) <= -0.75f && parCollision.gameObject.transform.parent.GetComponent<Player>().m_isShielding && parCollision.gameObject.transform.parent.GetComponent<Player>().m_hasShield)
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
