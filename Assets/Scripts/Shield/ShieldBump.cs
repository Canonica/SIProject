using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ShieldBump : MonoBehaviour {

    float m_bumpForce = 10f;

    public void Bump(GameObject parEnemy)
    {
        Vector3 m_tempEnemyPosition = parEnemy.transform.position;
        Vector3 m_tempPlayerPosition = transform.position;
        Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
        //m_bumpDirection.Normalize();
        Debug.Log(transform.forward);
        Debug.DrawRay(transform.position, m_bumpDirection*10f, Color.red, 0.5f);

        parEnemy.transform.DOJump(parEnemy.transform.position + (transform.forward* m_bumpForce), 3.0f, 1,0.4f).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));

    }

    void OnTriggerEnter(Collider parCollider)
    {
        if(parCollider.gameObject.tag == "Enemy")
        {
            Bump(parCollider.gameObject);
        }
    }
}
