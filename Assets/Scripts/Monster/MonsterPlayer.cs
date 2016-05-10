using UnityEngine;
using System.Collections;
using DG.Tweening;


public class MonsterPlayer : Monster {

    void Start()
    {

        _agent = this.GetComponent<NavMeshAgent>();
        int randPlayer = Random.Range(1, PlayerManager.GetInstance()._playerList.Count);
        Debug.Log(randPlayer);
        _target = GameObject.Find("Player" + randPlayer);
        InvokeRepeating("FindTarget", 0.5f, 0.5f);


    }

    public override void FindTarget()
    {
        
        _agent.SetDestination(_target.transform.position);
    }

    public override void Attack(GameObject parPlayer)
    {
        parPlayer.transform.DOJump(parPlayer.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));
        
    }

    public override void Death()
    {

    }

    void OnCollisionEnter(Collision parCollision)
    {
        //Debug.Log(parCollision.gameObject.tag);

        if (parCollision.transform.parent != null && parCollision.gameObject.transform.parent.gameObject.tag == "Player")
        {
            if (Vector3.Dot(transform.forward, parCollision.transform.forward) <= -0.75f && parCollision.gameObject.transform.parent.GetComponent<Player>().m_isShielding)
            {
                transform.DOMove(transform.position - (transform.forward * _counterBumpForce), 0.3f).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));
            }
            else
            {
                Attack(parCollision.gameObject.transform.parent.gameObject);
            }
        }
    }
}
