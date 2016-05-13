using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerAnimationManager : MonoBehaviour {


    public Animator m_Animator;
    private Player m_Player;
    Vector2 m_rightDirectionForward;
    Vector2 m_leftDirectionForward;

    Vector2 m_rightDirectionRight;
    Vector2 m_leftDirectionRight;
    public float dotForward;
    public float dotRight;
    //Helpers
    private bool m_currentlyBumped;
    private bool m_currentlyThrowing;
    private bool m_currentlyShielding;
    private bool m_currentlyStunned;

    private float m_xValue;
    private float m_yValue;

    // Use this for initialization
    void Start () {
        //m_Animator = GetComponent<Animator>();
        m_Player = GetComponent<Player>();

        m_currentlyShielding = false;
        m_currentlyBumped = false;
        m_currentlyThrowing = false;
        m_currentlyStunned = false;

        


    }
	
	// Update is called once per frame
	void Update () {

        if(!m_Player._isStuned && !m_Player.m_needHelp)
        {
            //m_Animator.SetFloat("SpeedY", m_Player.m_vLeft * -m_Player.m_vRight);
            //m_Animator.SetFloat("SpeedX", 1);

            /*m_xValue = m_Player.m_hLeft;
            m_yValue = m_Player.m_vLeft;

            m_rightDirectionForward = new Vector2(m_Player.m_hRight, m_Player.m_vRight);
            m_leftDirectionForward = new Vector2(m_Player.m_hLeft, m_Player.m_vLeft);

            m_rightDirectionRight = new Vector3(m_Player.m_hRight * Mathf.Cos(90) - m_Player.m_vRight * Mathf.Sin(90), m_Player.m_hRight * Mathf.Sin(90) + m_Player.m_vRight * Mathf.Cos(90));
            m_leftDirectionRight = new Vector3(m_Player.m_hLeft * Mathf.Cos(90) - m_Player.m_vLeft * Mathf.Sin(90), m_Player.m_hLeft * Mathf.Sin(90) + m_Player.m_vLeft * Mathf.Cos(90));

            dotForward = Vector2.Dot(m_rightDirectionForward, m_leftDirectionForward);
            dotRight = Vector2.Dot(m_rightDirectionRight, m_leftDirectionRight);


            m_Animator.SetFloat("SpeedX", ((m_Player.m_hLeft * Mathf.Cos(90) - m_Player.m_vLeft * Mathf.Sin(90)) + (m_Player.m_hLeft * Mathf.Sin(90) + m_Player.m_vLeft * Mathf.Cos(90))));
            m_Animator.SetFloat("SpeedY", -dotForward);*/

            m_Animator.SetFloat("SpeedX", m_Player.m_hLeft);
            m_Animator.SetFloat("SpeedY", m_Player.m_vLeft);


        }
        else
        {
            m_Animator.SetFloat("SpeedX", 0.0f);
            m_Animator.SetFloat("SpeedY", 0.0f);
        }
        
        


        //Shield States
        if(m_Player.m_hasShield)
        {
            if (!m_Player.m_isShielding)
            {
                if (m_currentlyShielding)
                {
                    m_Animator.SetTrigger("ShieldDown");
                }
            }
            else
            {
                if (!m_currentlyShielding)
                {
                    m_Animator.SetTrigger("ShieldUp");
                }
            }
        }
        

        //Throwing State
        if (!m_Player.m_hasShield)
        {
            if (!m_currentlyThrowing)
            {
                m_Animator.SetTrigger("StartThrowing");
            }
        }

    
        //Update Helpers
        m_currentlyShielding = m_Player.m_isShielding;
        m_currentlyThrowing = !m_Player.m_hasShield;
        m_currentlyBumped = m_Player._isBumped;
        m_currentlyStunned = m_Player._isStuned;
        
    }

    public void ShieldHit()
    {
        m_Animator.SetTrigger("ShieldHit");
    }

    public void ShieldUp()
    {
        m_Animator.SetTrigger("ShieldUp");
    }

    public void ShieldDown()
    {
        m_Animator.SetTrigger("ShieldDown");

    }

    public void EndStun()
    {
        CancelInvoke("EndStun");
        Debug.Log("EndBump");
        m_Animator.SetTrigger("EndBumped");
    }

    public void StartBump()
    {
        m_Animator.SetTrigger("StartBumped");
    }

    public void EndBump()
    {
        m_Animator.SetTrigger("EndBumped");
    }

    public void StartThrow()
    {
        m_Animator.SetTrigger("StartThrowing");
    }

    public void StartFalling()
    {
        m_Animator.SetTrigger("StartFalling");
    }

    public void EndFalling()
    {
        m_Animator.SetTrigger("EndFalling");
    }
}
