using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MonsterPlayer : Monster {
    public float _bumpMultiplier;

    void Start()
    {

        _agent = this.GetComponent<NavMeshAgent>();
        int randPlayer = Random.Range(1, PlayerManager.GetInstance()._playerList.Count+1);
        _target = GameObject.Find("Player" + randPlayer);
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
        InvokeRepeating("CheckUnder", 0.5f, 0.5f);


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

    public override IEnumerator Stun(float parTime)
    {
        if(_agent.enabled)
        {
            _agent.Stop();
        }
        this._isBumped = false;
        yield return new WaitForSeconds(parTime);

        if (_agent.enabled)
        {
            _agent.ResetPath();
            FindTarget();
        }
        
    }

    public override void FindTarget()
    {
        if(_target != null)
        {
            _agent.ResetPath();
            _agent.SetDestination(_target.transform.position);
        }else
        {
            if(PlayerManager.GetInstance()._playerList.Count > 0)
            {
                int randPlayer = Random.Range(1, PlayerManager.GetInstance()._playerList.Count+1);
                _target = GameObject.Find("Player" + randPlayer);
            }else
            {
                _target = GameObject.Find("Cage");
            }
            
        }
        
    }

    public override void Attack(GameObject parPlayer)
    {
        parPlayer.GetComponent<Player>()._currentBumpDirection = parPlayer.transform.position - transform.position;
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
