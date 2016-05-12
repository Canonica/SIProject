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

        /*parEnemy.GetComponent<Monster>()._currentBumpDirection = -m_bumpDirection;
        parEnemy.GetComponent<Monster>()._isBumped = true;*/
        parEnemy.transform.DOJump(parEnemy.transform.position + (transform.forward* _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad)).OnComplete(() => StartCoroutine(parEnemy.GetComponent<Monster>().Stun(_bumpTime)));

    }

    public void BumpCageOrPlayer(GameObject parPlayer)
    {
        Vector3 m_tempEnemyPosition = parPlayer.transform.position;
        Vector3 m_tempPlayerPosition = transform.position;
        Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;

        if(parPlayer.tag == "Player")
        {
            parPlayer.GetComponent<Player>()._currentBumpDirection = -m_bumpDirection;
            parPlayer.GetComponent<Player>()._isBumped = true;
            parPlayer.transform.DOJump(parPlayer.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad)).OnComplete(() => parPlayer.GetComponent<Player>()._isBumped = false);
        }
        else
        {
            parPlayer.GetComponent<Cage>().currentBumpDirection = -m_bumpDirection;
            parPlayer.GetComponent<Cage>()._isBumped = true;
            parPlayer.transform.DOJump(parPlayer.transform.position + (transform.forward * (_bumpForce/2)), 0.0f, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad)).OnComplete(() => parPlayer.GetComponent<Cage>()._isBumped = false);
        }
        
    }

    void OnTriggerEnter(Collider parCollider)
    {
        if(parCollider.gameObject.tag == "Enemy")
        {
            Bump(parCollider.gameObject);
        }else if(parCollider.gameObject.tag == "Player" && parCollider.gameObject != this.gameObject.transform.parent.parent.gameObject)
        {
            Debug.Log(parCollider.gameObject);
            BumpCageOrPlayer(parCollider.gameObject);
        }else if(parCollider.gameObject.tag == "Cage")
        {
            BumpCageOrPlayer(parCollider.gameObject);
        }

    }
}
