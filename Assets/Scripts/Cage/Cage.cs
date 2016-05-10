using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Cage : MonoBehaviour {


    public bool _isBumped;
    public float _bumpMultiplier = 5f;
    Vector3 currentBumpDirection;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision  other)
    {
        if(other.transform.tag == "Enemy")
        {
            Bump(other.gameObject);
        }
    }

    public void Bump(GameObject parEnemy)
    {
        if (!_isBumped)
        {
            _isBumped = true;
            Vector3 m_tempEnemyPosition = new Vector3(parEnemy.transform.position.x, 0,parEnemy.transform.position.z);
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            currentBumpDirection = m_bumpDirection;
            this.transform.DOMove(transform.position - m_bumpDirection*2 , 1f).SetEase(Ease.OutQuint).OnComplete(() => NotBumped());
        }
        else 
        {
            parEnemy.GetComponent<NavMeshAgent>().Stop();
            Vector3 m_tempEnemyPosition = new Vector3(parEnemy.transform.position.x, 0, parEnemy.transform.position.z);
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            currentBumpDirection.Normalize();
            m_bumpDirection.Normalize();
            float behind = Vector3.Dot(currentBumpDirection, m_bumpDirection);
            if(behind < 0)
            {
                parEnemy.transform.DOMove(parEnemy.transform.position + m_bumpDirection * _bumpMultiplier * Mathf.Abs(behind)
                    , 1f).SetEase(Ease.OutQuint).OnComplete(() => parEnemy.GetComponent<NavMeshAgent>().Resume());
            }
        }
    }

    void NotBumped()
    {
        _isBumped = false;
    }
}
