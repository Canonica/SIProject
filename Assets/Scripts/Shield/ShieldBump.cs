using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ShieldBump : MonoBehaviour {

    public float _bumpForce = 10f;
    public float _bumpHeight;
    public float _bumpTime;

    public void Bump(GameObject parEnemy)
    {
        Vector3 m_tempEnemyPosition = parEnemy.transform.position;
        Vector3 m_tempPlayerPosition = transform.position;
        Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;

        parEnemy.transform.DOJump(parEnemy.transform.position + (transform.forward* _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad)).OnComplete(() => StartCoroutine(parEnemy.GetComponent<Monster>().Stun(_bumpTime)));

    }

    void OnTriggerEnter(Collider parCollider)
    {
        if(parCollider.gameObject.tag == "Enemy")
        {
            Bump(parCollider.gameObject);
        }
    }
}
