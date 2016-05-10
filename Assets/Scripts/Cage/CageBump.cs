using UnityEngine;
using System.Collections;
using DG.Tweening;
public class CageBump : MonoBehaviour {
    float m_bumpForce = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider parCollider)
    {
        if (parCollider.gameObject.tag == "Enemy")
        {
            Vector3 m_tempEnemyPosition = parCollider.transform.position;
            Vector3 m_tempPlayerPosition = transform.position;
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            m_bumpDirection.Normalize();

            parCollider.transform.DOMove(m_bumpDirection * m_bumpForce, 0.5f).SetEase(Ease.OutQuint);
        }
    }
}
