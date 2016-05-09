using UnityEngine;
using System.Collections;
using DG.Tweening;
using XInputDotNetPure;

public class Player : MonoBehaviour {
    public int _playerId;
    public GameObject _mesh;

    public float _speed;
    public float _rotateSpeed;

    float m_hLeft;
    float m_vLeft;
    float m_hRight;
    float m_vRight;

    Rigidbody m_rigidbody;
    Vector3 _velocity;

    bool m_needHelp;
    bool m_hasShield;
    bool m_isShielding;
    bool m_isMoving;

    float delayToLaunch;
    // Use this for initialization
    void Start () {
        m_rigidbody = this.GetComponent<Rigidbody>();
        m_isMoving = false;
        m_isShielding = false;
        m_hasShield = true;
    }
	
	// Update is called once per frame
	void Update () {
        m_vLeft = XInput.instance.getYStickLeft(_playerId);
        m_hLeft = XInput.instance.getXStickLeft(_playerId);

        m_vRight = XInput.instance.getYStickRight(_playerId);
        m_hRight = XInput.instance.getXStickRight(_playerId);

        Vector3 _movHorizontal = transform.right * m_hLeft;
        Vector3 _movVertical = transform.forward * m_vLeft;
        float angleTRight = Mathf.Atan2(m_hRight, m_vRight);
        float angleTLeft = Mathf.Atan2(m_hLeft, m_vLeft);

        _velocity = (_movHorizontal + _movVertical).normalized;
        transform.position = transform.position + _velocity * _speed *  Time.deltaTime;

        if(m_vLeft !=0 || m_hLeft != 0)
        {
            m_isMoving = true;
        }
        else
        {
            m_isMoving = false;
        }

        if (m_hRight != 0 || m_vRight != 0 && m_hasShield)
        {
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

    }

    private void playerRotate(float parAngle)
    {
        _mesh.transform.rotation = Quaternion.Slerp(_mesh.transform.rotation, Quaternion.Euler(0f, (parAngle * Mathf.Rad2Deg), 0f), _rotateSpeed);
    }

}
