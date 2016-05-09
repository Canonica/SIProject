using UnityEngine;
using System.Collections;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class ShieldBounce : MonoBehaviour {

    float m_bumpForce = 10f;
    float m_bounceCount;
    float m_maxBounceCount = 3;
    Rigidbody m_rigidBody;

    float m_currentDistanceMin = Mathf.Infinity;
    GameObject m_target;
    
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider parCollider)
    {
        if(parCollider.gameObject.tag =="Enemy")
        {
            m_bounceCount++;
            Vector3 m_tempEnemyPosition = parCollider.transform.position;
            Vector3 m_tempPlayerPosition = transform.position;
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            m_bumpDirection.Normalize();

            parCollider.transform.DOMove(m_bumpDirection* m_bumpForce, 0.5f);

            MonsterManager.GetInstance().RemoveMonster(parCollider.gameObject);

            if(m_bounceCount < m_maxBounceCount)
            {
                FindOtherEnemy();
            }
        }

    }

    void FindOtherEnemy()
    {
        if(MonsterManager.GetInstance()._listOfMonster.Count > 0)
        {
            foreach(GameObject parMonster in MonsterManager.GetInstance()._listOfMonster)
            {
                float m_distance = Vector3.Distance(transform.position, parMonster.transform.position);
                if(m_distance < m_currentDistanceMin)
                {
                    m_target = parMonster;
                    m_currentDistanceMin = m_distance;
                }
            }

            transform.DOMove(m_target.transform.position, 0.5f);
            m_currentDistanceMin = Mathf.Infinity;
        }
    }
}
