using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class ShieldBounce : MonoBehaviour {

    float m_bumpForce = 10f;
    public int m_bounceCount = 0;
    int m_maxBounceCount = 3;
    float m_range = 10.0f;
    public bool m_hit;
    public bool m_back;
    public bool m_targeting;
    public float m_speed = 20f;
    Rigidbody m_rigidBody;
    public GameObject m_owner;

    float m_currentDistanceMin = Mathf.Infinity;
    Vector3 m_targetPos;
    GameObject m_target;
    public List<GameObject> m_listOfMonstersHit;

    public List<GameObject> m_tempListOfMonsters;

    void Start()
    {
        m_hit = false;
        m_back = false;
        m_targeting = false;
        m_tempListOfMonsters = new List<GameObject>(MonsterManager.GetInstance()._listOfMonster);
        m_listOfMonstersHit = new List<GameObject>();
        m_rigidBody = GetComponent<Rigidbody>();
        transform.DOMove(transform.position + m_owner.transform.forward * m_range, 0.5f).OnComplete(() => CheckHit());
    }

    void Update()
    {
        Move();
       
    }

    void OnTriggerEnter(Collider parCollider)
    {
        if(parCollider.gameObject.tag =="Enemy")
        {
            Vector3 _tempPosition = transform.position;
            transform.DOKill(true);
            
            transform.DOMove(_tempPosition, 0.0f);

            m_hit = true;
            m_bounceCount++;

            Vector3 m_tempEnemyPosition = new Vector3(parCollider.transform.position.x, 0, parCollider.transform.position.z) ;
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x,0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            m_bumpDirection.Normalize();

            StartCoroutine(parCollider.GetComponent<Monster>().Stun(0.6f));

            parCollider.GetComponent<Monster>()._currentBumpDirection = -m_bumpDirection;
            parCollider.GetComponent<Monster>()._isBumped = true;
            parCollider.transform.DOMove(parCollider.transform.position- m_bumpDirection * m_bumpForce, 0.5f).OnComplete(() => parCollider.GetComponent<Monster>()._isBumped = false);

            m_listOfMonstersHit.Add(parCollider.gameObject);
            m_tempListOfMonsters.Remove(parCollider.gameObject);

            if(!m_back && m_bounceCount < m_maxBounceCount && MonsterManager.GetInstance()._listOfMonster.Count >0)
            {

                m_targeting = true;
                FindOtherEnemy();
            }else
            {
                m_targeting = false;
                m_back = true;
            }
        }

    }

    void CheckHit()
    {
        if(m_hit)
        {
            m_back = false;
        }else
        {
            m_back = true;
        }
    }

    void FindOtherEnemy()
    {
        m_tempListOfMonsters = new List<GameObject>(MonsterManager.GetInstance()._listOfMonster);
        if (m_tempListOfMonsters.Count > 0)
        {
            foreach(GameObject parMonster in m_tempListOfMonsters)
            {
                for(int i=0; i < m_listOfMonstersHit.Count; i++)
                {
                    if(!m_listOfMonstersHit.Contains(parMonster))
                    {
                        float m_distance = Vector3.Distance(transform.position, parMonster.transform.position);
                        if (m_distance < m_currentDistanceMin)
                        {
                    
                            m_target = parMonster;
                            m_currentDistanceMin = m_distance;
                        }
                    }
                }
                
            }
           
            m_currentDistanceMin = Mathf.Infinity;
        }
    }

    void Move()
    {
        
        if(m_targeting)
        {
            if(m_target != null && !m_target.GetComponent<Monster>().m_isFlying)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_speed * Time.deltaTime);
            }else
            {
                m_back = true;
                m_targeting = false;
            }
            
        }else if (m_back && !m_owner.transform.parent.GetComponent<Player>().m_hasShield)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_owner.transform.position, m_speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, m_owner.transform.position) <= 0.2f)
            {
                Reset();
            }
        }
    }

    void Reset()
    {
        m_owner.transform.parent.GetComponent<Player>().m_hasShield = true;
        Destroy(this.gameObject);
        
    }
}
