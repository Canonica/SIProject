using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ShieldBump : MonoBehaviour {

    public float _bumpForce = 10f;
    public float _bumpHeight;
    public float _bumpTime;
    public float _timeStun = 2.0f;

    public GameObject _playerParent;

    public void Bump(GameObject parEnemy)
    {
        Vector3 m_tempEnemyPosition = parEnemy.transform.position;
        Vector3 m_tempPlayerPosition = transform.position;
        Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;

        /*parEnemy.GetComponent<Monster>()._currentBumpDirection = -m_bumpDirection;
        parEnemy.GetComponent<Monster>()._isBumped = true;*/
        parEnemy.transform.DOJump(parEnemy.transform.position + (transform.forward * _bumpForce), _bumpHeight, 1, _bumpTime).SetEase(EaseFactory.StopMotion(60, Ease.InOutQuad));
        StartCoroutine(parEnemy.GetComponent<Monster>().Stun());
        parEnemy.GetComponent<MonsterAnimationManager>().LaunchBump();
    }
   

    public void BumpCageOrPlayer(GameObject parPlayer)
    {
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
            GameManager.GetInstance()._camera.transform.DOShakePosition(0.2f);
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
        
       
        if (parCollider.gameObject.tag == "Enemy")
        {
            Debug.Log("test");
            XInput.instance.useVibe(_playerParent.GetComponent<Player>()._playerId, 0.1f, 0.15f, 0.15f);
            Bump(parCollider.gameObject);
        }else if(parCollider.gameObject.tag == "Player" && parCollider.gameObject != this.gameObject.transform.parent.parent.gameObject)
        {
            Debug.Log("test");
            XInput.instance.useVibe(_playerParent.GetComponent<Player>()._playerId, 0.1f, 0.15f, 0.15f);
            Debug.Log(parCollider.gameObject);
            BumpCageOrPlayer(parCollider.gameObject);
        }else if(parCollider.gameObject.tag == "Cage")
        {
            Debug.Log("test");
            XInput.instance.useVibe(_playerParent.GetComponent<Player>()._playerId, 0.1f, 0.15f, 0.15f);
            BumpCageOrPlayer(parCollider.gameObject);
        }

    }
}
