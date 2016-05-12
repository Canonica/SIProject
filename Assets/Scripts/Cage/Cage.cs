using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Cage : MonoBehaviour {


    public bool _isBumped;
    public float _bumpMultiplier = 5f;
    public Vector3 currentBumpDirection;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_isBumped)
        {
            CheckCollision(currentBumpDirection);
        }

    }

    void OnCollisionEnter(Collision  other)
    {
        if(other.transform.tag == "Enemy")
        {
            Bump(other.gameObject);
        }else if(other.gameObject.transform.parent != null && other.gameObject.transform.parent.tag == "Player")
        {

            BumpPlayer(other.gameObject.transform.parent.gameObject, other.gameObject.transform.parent.transform.position);
        }

    }

    public void BumpPlayer(GameObject parPlayer, Vector3 parPlayerPos)
    {
        if(_isBumped && (!parPlayer.GetComponent<Player>().m_isShielding || !parPlayer.GetComponent<Player>().m_hasShield))
        {
            
            Vector3 m_tempEnemyPosition = new Vector3(parPlayer.transform.position.x, 0, parPlayer.transform.position.z);
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            currentBumpDirection.Normalize();
            m_bumpDirection.Normalize();
            float behind = Vector3.Dot(currentBumpDirection, m_bumpDirection);
            if (behind < 0)
            {
                parPlayer.GetComponent<Player>()._isBumped = true;
                parPlayer.transform.DOMove(parPlayer.transform.position + m_bumpDirection * _bumpMultiplier * Mathf.Abs(behind)
                    , 1f).SetEase(Ease.OutQuint).OnComplete(() => StartCoroutine(parPlayer.GetComponent<Monster>().Stun(1.0f))).OnComplete(() => parPlayer.GetComponent<Player>()._isBumped = false);
            }
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
            Vector3 m_tempEnemyPosition = new Vector3(parEnemy.transform.position.x, 0, parEnemy.transform.position.z);
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            currentBumpDirection.Normalize();
            m_bumpDirection.Normalize();
            parEnemy.GetComponent<Monster>()._currentBumpDirection = m_bumpDirection;
            parEnemy.GetComponent<Monster>()._isBumped = true;
            float behind = Vector3.Dot(currentBumpDirection, m_bumpDirection);
            if(behind < 0)
            {
                parEnemy.transform.DOMove(parEnemy.transform.position + m_bumpDirection * _bumpMultiplier * Mathf.Abs(behind)
                    , 1f).SetEase(Ease.OutQuint).OnComplete(() => StartCoroutine(parEnemy.GetComponent<Monster>().Stun(1.0f)));
            }
        }
    }

    void CheckCollision(Vector3 parDirection)
    {
        RaycastHit m_hit;
        if (Physics.SphereCast(transform.position, gameObject.GetComponent<CapsuleCollider>().radius, -parDirection, out m_hit, Mathf.Infinity))
        {
            if (m_hit.collider.tag == "Obstacle" && m_hit.distance <= gameObject.GetComponent<CapsuleCollider>().radius+0.1f)
            {
                Vector3 _tempPosition = transform.position;
                transform.DOKill(true);
                transform.DOMove(_tempPosition, 0.0f).OnComplete(() => _isBumped = false);
               
            }
        }
    }

    void NotBumped()
    {
        _isBumped = false;
    }
}
