using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ShieldBump : MonoBehaviour {

    public float _bumpForce = 10f;
    public float _bumpHeight;
    public float _bumpTime;
    public float _timeStun = 2.0f;
    public GameObject shieldFx;

    void Start()
    {
        shieldFx = Resources.Load("Prefabs/P_ImpactBouclier") as GameObject;
    }
    public void Bump(GameObject parEnemy)
    {
        GameObject temp = Instantiate(shieldFx, transform.position, Quaternion.identity) as GameObject;
        Destroy(temp, 1f);
        Vector3 m_tempEnemyPosition = parEnemy.transform.position;
        Vector3 m_tempPlayerPosition = transform.position;
        Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;

        /*parEnemy.GetComponent<Monster>()._currentBumpDirection = -m_bumpDirection;
        parEnemy.GetComponent<Monster>()._isBumped = true;*/
        parEnemy.transform.DOJump(parEnemy.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));
        StartCoroutine(parEnemy.GetComponent<Monster>().Stun(_timeStun));
        parEnemy.GetComponent<MonsterAnimationManager>().LaunchBump();
    }

    void LaunchStun(GameObject parEnemy)
    {
        
    }

    public void BumpCageOrPlayer(GameObject parPlayer)
    {
        GameObject temp = Instantiate(shieldFx, transform.position, Quaternion.identity) as GameObject;
        Destroy(temp, 1f);
        Vector3 m_tempEnemyPosition = parPlayer.transform.position;
        Vector3 m_tempPlayerPosition = transform.position;
        Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;

        if(parPlayer.tag == "Player")
        {
            Vector3 _tempPosition = parPlayer.transform.position;
            parPlayer.transform.DOKill(true);
            parPlayer.transform.DOMove(_tempPosition, 0.0f);

            parPlayer.GetComponent<Player>()._currentBumpDirection = m_bumpDirection;
            parPlayer.GetComponent<Player>()._isBumped = true;
            parPlayer.transform.DOJump(parPlayer.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad)).OnComplete(() => parPlayer.GetComponent<Player>()._isBumped = false);
        }
        else
        {
            Vector3 _tempPosition = parPlayer.transform.position;
            parPlayer.transform.DOKill(true);
            parPlayer.transform.DOMove(_tempPosition, 0.0f);
            
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
