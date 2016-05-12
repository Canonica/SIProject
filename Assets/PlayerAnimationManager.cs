using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerAnimationManager : MonoBehaviour {


    public Animator m_Animator;
    private Player m_Player;

    //Helpers
    private bool m_currentlyBumped;
    private bool m_currentlyThrowing;
    private bool m_currentlyShielding;
    private bool m_currentlyStunned;

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
            m_Animator.SetFloat("SpeedX", m_Player.m_vLeft);
            m_Animator.SetFloat("SpeedY", m_Player.m_hLeft);
            
        }
        else
        {
            m_Animator.SetFloat("SpeedX", 0.0f);
            m_Animator.SetFloat("SpeedY", 0.0f);
        }
        
        


        /*//Shield States
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
        

        //Bumped States

        

        

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
        */
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
}
