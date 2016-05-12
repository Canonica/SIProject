using UnityEngine;
using System.Collections;
using DG.Tweening;
using XInputDotNetPure;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public int _playerId;
    public GameObject _mesh;
    public GameObject _meshTriggerShield;
    public GameObject _meshShield;
    public GameObject _playerToHelp;
    public List<GameObject> m_playerHelping;

    public float _speed;
    public float _rotateSpeed;

    private float m_CurrentSpeed;

    public float m_hLeft;
    public float m_vLeft;
    public float m_hRight;
    public float m_vRight;

    public int _reviveCount;
    public int _maxReviveCount = 10;

    float m_fire;
    float m_bump;

    Rigidbody m_rigidbody;
    Vector3 _velocity;
    CharacterController characterController;

    public bool m_needHelp;
    public bool _canHelp;
    public bool m_hasShield;
    public bool m_isShielding;
    public bool m_isMoving;
    public bool _isBumped;
    public bool m_isFlying;
    bool buttonPressedA;
    public bool _isStuned;

    public Vector3 _currentBumpDirection;
    public float _bumpMultiplier;
    float m_startPositionY;
    public float _timeEndStunAnimation = 0.7f;

    float delayToLaunch;
    // Use this for initialization
    void Start () {
        m_playerHelping = new List<GameObject>();
        _reviveCount = 0;
        m_startPositionY = transform.position.y;
        m_rigidbody = this.GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        GetComponent<SphereCollider>().enabled = false;
        m_isMoving = false;
        m_isShielding = false;
        m_hasShield = true;
        _isBumped = false;
        _canHelp = false;
        _isStuned = false;
        _meshTriggerShield.SetActive(false);
        CheckUnder();
        InvokeRepeating("CheckUnder", 0.5f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_isFlying)
        {
            transform.position = new Vector3(transform.position.x, m_startPositionY, transform.position.z);
        }
        

        if (_isBumped)
        {
            m_isShielding = false;
            CheckCollision(_currentBumpDirection);
        }

        /*if (m_isFlying && !_isBumped)
        {
            //this.transform.position = transform.position + -transform.up * _speed * Time.deltaTime;
            
            
        }*/

        m_vLeft = XInput.instance.getYStickLeft(_playerId);
        m_hLeft = XInput.instance.getXStickLeft(_playerId);

        m_vRight = XInput.instance.getYStickRight(_playerId);
        m_hRight = XInput.instance.getXStickRight(_playerId);

        m_fire = XInput.instance.getTriggerRight(_playerId);
        m_bump = XInput.instance.getTriggerLeft(_playerId);

        Vector3 _movHorizontal = transform.right * m_hLeft;
        Vector3 _movVertical = transform.forward * m_vLeft;
        float angleTRight = Mathf.Atan2(m_hRight, m_vRight);
        float angleTLeft = Mathf.Atan2(m_hLeft, m_vLeft);

        _velocity = (_movHorizontal + _movVertical).normalized;
        if(!m_needHelp && !_isStuned)
        {
            characterController.Move(_velocity * _speed * Time.deltaTime);
        }
        
        //transform.position = transform.position + _velocity * _speed *  Time.deltaTime;
        _meshShield.SetActive(m_hasShield);
       
        

        if ((m_vLeft !=0 || m_hLeft != 0) && !m_needHelp)
        {
            m_isMoving = true;
        }
        else
        {
            m_isMoving = false;
        }

        if (m_isShielding && !_isStuned)
        {
            
            playerRotate(angleTRight);
        }
        else if (m_isMoving && !m_isShielding && !_isStuned)
        {
            playerRotate(angleTLeft);
        }

        if ((m_hRight != 0 || m_vRight != 0) && m_hasShield && !m_needHelp && !_isStuned)
        {
            if (!m_isShielding)
            {

            }

            m_isShielding = true;
            
            if (m_isShielding && m_bump > 0.3f)
            {
                StartCoroutine(ActivateBump(0.1f));
            }

        }
        else
        {
            m_isShielding = false;
        }


        if (m_fire > 0.2f && m_hasShield && !_isStuned)
        {
            ThrowShield();
        }


        if (m_isFlying)
        {
            //this.transform.position = transform.position + -transform.up * _speed * Time.deltaTime;
            if (!m_needHelp)
            {
                NeedHelp();
            }
        }

        if (XInput.instance.getButton(_playerId, 'B') == ButtonState.Pressed && !buttonPressedA && _canHelp && !m_needHelp && !_isStuned)
        {
            _playerToHelp.GetComponent<Player>()._reviveCount++;
            buttonPressedA = true;
        }
        else if (XInput.instance.getButton(_playerId, 'B') == ButtonState.Released && buttonPressedA)
        {
            buttonPressedA = false;
        }

        if(_reviveCount >= _maxReviveCount)
        {
            Revive(m_playerHelping[0]);
        }

    }

    void CheckCollision(Vector3 parDirection)
    {
        RaycastHit m_hit;
        if (Physics.SphereCast(transform.position, gameObject.transform.GetChild(0).GetComponent<CapsuleCollider>().radius, parDirection, out m_hit, Mathf.Infinity))
        {
            if ((m_hit.collider.tag == "Obstacle" || m_hit.collider.name == "Cage") && m_hit.distance <= gameObject.transform.GetChild(0).GetComponent<CapsuleCollider>().radius*2 + 0.1f)
            {
                Vector3 _tempPosition = transform.position;
                transform.DOKill(true);
                transform.DOMove(_tempPosition, 0.0f).OnComplete(() => _isBumped = false);

            }
        }
    }

    private void playerRotate(float parAngle)
    {
        if(!m_needHelp)
        {
            _mesh.transform.rotation = Quaternion.Slerp(_mesh.transform.rotation, Quaternion.Euler(0f, (parAngle * Mathf.Rad2Deg), 0f), _rotateSpeed);
        }
        
    }

    IEnumerator ActivateBump(float parTimer)
    {
        float m_currentTime = 0;
        while(m_currentTime < parTimer)
        {
            _meshTriggerShield.SetActive(true);
            m_currentTime += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        _meshTriggerShield.SetActive(false);
        
    }

    void CheckUnder()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, _mesh.gameObject.GetComponent<CapsuleCollider>().radius, -transform.up, out hit, 10))
        {
            if (hit.transform.tag == "Ground")
            {
                m_isFlying = false;
            }
        }
        else
        {
            m_isFlying = true;
        }
    }

    void ThrowShield()
    {
        m_hasShield = false;
        m_isShielding = false;
        GameObject shield = Instantiate(Resources.Load("Prefabs/Shield"), transform.position, Quaternion.identity) as GameObject;
        shield.GetComponent<ShieldBounce>().m_owner = _mesh.gameObject;
    }

    public void OnCollisionEnter(Collision parCollision)
    {

        if (parCollision.gameObject.tag == "Enemy")
        {
            if (_isBumped)
            {
                //parCollision.gameObject.GetComponent<NavMeshAgent>().Stop();

                Vector3 m_tempEnemyPosition = new Vector3(parCollision.transform.position.x, 0, parCollision.transform.position.z);
                Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
                Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;

                _currentBumpDirection.Normalize();
                m_bumpDirection.Normalize();
                
                float behind = Vector3.Dot(_currentBumpDirection, m_bumpDirection);

                if (behind < 0)
                {
                    parCollision.transform.DOMove(parCollision.transform.position + m_bumpDirection * _bumpMultiplier 
                        , 1f).SetEase(Ease.OutQuint).OnComplete(() => StartCoroutine(parCollision.gameObject.GetComponent<Monster>().Stun(2.0f)));
                }
            }
        }
        if (parCollision.gameObject.name == "Cage")
        {
            //_isBumped = true;
            Vector3 m_tempDirection = transform.position - parCollision.transform.position;
           
            _currentBumpDirection = m_tempDirection;
            m_tempDirection.Normalize();
           

            if (Vector3.Dot(m_tempDirection, transform.GetChild(0).transform.forward) <= -0.75f && m_isShielding && m_hasShield)
            {
                Vector3 _tempPosition = parCollision.transform.position;
                parCollision.transform.DOKill(true);
                parCollision.transform.DOMove(_tempPosition, 0.0f);
                transform.DOMove(transform.position + m_tempDirection*0.5f, 0.2f);
                parCollision.gameObject.GetComponent<Cage>()._isBumped = false;
            }
        }
    }


    void OnTriggerEnter(Collider parOtherPlayer)
    {
        if(parOtherPlayer.gameObject.tag == "Player")
        {
            if(GetComponent<SphereCollider>().enabled)
            {
                m_playerHelping.Add(parOtherPlayer.gameObject);
                parOtherPlayer.GetComponent<Player>()._playerToHelp = this.gameObject;
                parOtherPlayer.GetComponent<Player>()._canHelp = true;
            }
            
        }
    }


    void OnTriggerExit(Collider parOtherPlayer)
    {
        if (parOtherPlayer.gameObject.tag == "Player")
        {
            m_playerHelping.Remove(parOtherPlayer.gameObject);
            parOtherPlayer.GetComponent<Player>()._playerToHelp = null;
            parOtherPlayer.GetComponent<Player>()._canHelp = false;
        }
    }

    public void NeedHelp()
    {
        Debug.Log("need help");
        m_needHelp = true;

        Vector3 _tempPosition = transform.position;
        transform.DOKill(true);
        
        float m_playerHeight = GetComponent<CharacterController>().height*2f;
        transform.DOMove(new Vector3(_tempPosition.x, _tempPosition.y - m_playerHeight, _tempPosition.z), 0.0f);
  
        PlayerManager.GetInstance()._playerList.Remove(this.GetComponent<Player>());
        GetComponent<CharacterController>().enabled = false;
        GetComponent<SphereCollider>().enabled = true;
        transform.position = new Vector3(transform.position.x, transform.position.y - m_playerHeight, transform.position.z);
        _mesh.transform.LookAt(new Vector3(0.0f, transform.position.y, 0.0f));
    }

    public void Revive(GameObject parPlayer)
    {
        _reviveCount = 0;
        m_needHelp = false;
        PlayerManager.GetInstance()._playerList.Add(this.GetComponent<Player>());
        GetComponent<CharacterController>().enabled = true;
        GetComponent<SphereCollider>().enabled = false;
        transform.position = new Vector3(parPlayer.transform.position.x  - parPlayer.GetComponent<Player>()._mesh.transform.forward.x*2.0f,
                                        m_startPositionY, 
                                        parPlayer.transform.position.z  - parPlayer.GetComponent<Player>()._mesh.transform.forward.z*2.0f);
    }

    public IEnumerator Stun(float parTime)
    {
        _isStuned = true;
        CancelInvoke("Reset");
        GetComponent<PlayerAnimationManager>().Invoke("EndStun", parTime - 0.7f);
        Invoke("Reset", parTime);
        yield return null;

    }

    void Reset()
    {
        _isStuned = false;
    }

}
