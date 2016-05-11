using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class ShieldBounce : MonoBehaviour {

    float m_bumpForce = 10f;
    public float m_bounceCount;
    float m_maxBounceCount = 3;
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

    public List<GameObject> m_tempListOfMonsters;

    void Start()
    {
        m_hit = false;
        m_back = false;
        m_targeting = false;
        m_tempListOfMonsters = new List<GameObject>(MonsterManager.GetInstance()._listOfMonster);
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
            m_hit = true;
            m_bounceCount++;
            Vector3 m_tempEnemyPosition = parCollider.transform.position;
            Vector3 m_tempPlayerPosition = transform.position;
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            m_bumpDirection.Normalize();

            parCollider.transform.DOMove(m_bumpDirection* m_bumpForce, 0.5f);

            m_tempListOfMonsters.Remove(parCollider.gameObject);

            if(!m_back && m_bounceCount < m_maxBounceCount)
            {

                m_targeting = true;
                FindOtherEnemy();
            }else
            {
                Debug.Log(m_bounceCount);
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
        if(MonsterManager.GetInstance()._listOfMonster.Count > 0)
        {
            foreach(GameObject parMonster in m_tempListOfMonsters)
            {
                float m_distance = Vector3.Distance(transform.position, parMonster.transform.position);
                if(m_distance < m_currentDistanceMin)
                {
                    m_target = parMonster;
                    m_currentDistanceMin = m_distance;
                }
            }
            m_currentDistanceMin = Mathf.Infinity;
        }
    }

    void Move()
    {
        
        if(m_targeting)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_speed * Time.deltaTime);
        }else if (m_back && !m_owner.transform.parent.GetComponent<Player>().m_hasShield)
        {
            Debug.Log("back");
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
