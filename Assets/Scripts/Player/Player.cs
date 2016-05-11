using UnityEngine;
using System.Collections;
using DG.Tweening;
using XInputDotNetPure;

public class Player : MonoBehaviour {
    public int _playerId;
    public GameObject _mesh;
    public GameObject _meshTriggerShield;
    public GameObject _meshShield;


    public float _speed;
    public float _rotateSpeed;

    float m_hLeft;
    float m_vLeft;
    float m_hRight;
    float m_vRight;

    float m_fire;

    Rigidbody m_rigidbody;
    Vector3 _velocity;

    public bool m_needHelp;
    public bool m_hasShield;
    public bool m_isShielding;
    bool m_isMoving;
    public bool _isBumped;
    bool m_isFlying;

    public Vector3 _currentBumpDirection;
    public float _bumpMultiplier;

    float delayToLaunch;
    // Use this for initialization
    void Start () {
        m_rigidbody = this.GetComponent<Rigidbody>();
        m_isMoving = false;
        m_isShielding = false;
        m_hasShield = true;
        _isBumped = false;
        _meshTriggerShield.SetActive(false);
        CheckUnder();
        InvokeRepeating("CheckUnder", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (m_isFlying)
        {
            this.transform.position = transform.position + -transform.up * _speed * Time.deltaTime;
        }

        m_vLeft = XInput.instance.getYStickLeft(_playerId);
        m_hLeft = XInput.instance.getXStickLeft(_playerId);

        m_vRight = XInput.instance.getYStickRight(_playerId);
        m_hRight = XInput.instance.getXStickRight(_playerId);

        m_fire = XInput.instance.getTrigger(1);

        Vector3 _movHorizontal = transform.right * m_hLeft;
        Vector3 _movVertical = transform.forward * m_vLeft;
        float angleTRight = Mathf.Atan2(m_hRight, m_vRight);
        float angleTLeft = Mathf.Atan2(m_hLeft, m_vLeft);

        _velocity = (_movHorizontal + _movVertical).normalized;
        transform.position = transform.position + _velocity * _speed *  Time.deltaTime;
        _meshShield.SetActive(m_isShielding);
       
        if(m_fire > 0.2f && m_hasShield)
        {
            ThrowShield();
        }

        if (m_vLeft !=0 || m_hLeft != 0)
        {
            m_isMoving = true;
        }
        else
        {
            m_isMoving = false;
        }

        if (m_hRight != 0 || m_vRight != 0 && m_hasShield)
        {
            if(!m_isShielding)
            {
                StartCoroutine(ActivateBump(0.1f));
            }
            m_isShielding = true;
            
        }
        else
        {
            m_isShielding = false;
        }

        if (m_isShielding)
        {
            playerRotate(angleTRight);
        }
        else if(m_isMoving)
        {
            playerRotate(angleTLeft);
        }

        if (m_isFlying)
        {
            this.transform.position = transform.position + -transform.up * _speed * Time.deltaTime;
        }

    }

    private void playerRotate(float parAngle)
    {
        _mesh.transform.rotation = Quaternion.Slerp(_mesh.transform.rotation, Quaternion.Euler(0f, (parAngle * Mathf.Rad2Deg), 0f), _rotateSpeed);
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
        if (Physics.SphereCast(transform.position, _mesh.gameObject.GetComponent<CapsuleCollider>().radius, -transform.up, out hit, 1))
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
        GameObject shield = Instantiate(Resources.Load("Prefabs/Shield"), transform.position, Quaternion.identity) as GameObject;
        shield.GetComponent<ShieldBounce>().m_owner = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void OnCollisionEnter(Collision parCollision)
    {
        //Debug.Log(parCollision.gameObject.tag);

        if (parCollision.gameObject.tag == "Enemy")
        {
            if (_isBumped)
            {
                parCollision.gameObject.GetComponent<NavMeshAgent>().Stop();

                Vector3 m_tempEnemyPosition = new Vector3(parCollision.transform.position.x, 0, parCollision.transform.position.z);
                Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
                Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;

                _currentBumpDirection.Normalize();
                m_bumpDirection.Normalize();
                
                float behind = Vector3.Dot(_currentBumpDirection, m_bumpDirection);

                if (behind < 0)
                {
                    parCollision.transform.DOMove(parCollision.transform.position + m_bumpDirection * _bumpMultiplier 
                        , 1f).SetEase(Ease.OutQuint).OnComplete(() => parCollision.gameObject.GetComponent<NavMeshAgent>().Resume());
                }
            }
        }
    }


}
