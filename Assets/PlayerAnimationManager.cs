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

    // Use this for initialization
    void Start () {
        //m_Animator = GetComponent<Animator>();
        m_Player = GetComponent<Player>();

        m_currentlyShielding = false;
        m_currentlyBumped = false;
        m_currentlyThrowing = false;

    }
	
	// Update is called once per frame
	void Update () {

        m_Animator.SetFloat("SpeedX", m_Player.m_vLeft);
        m_Animator.SetFloat("SpeedY", m_Player.m_hLeft);


        //Shield States
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

        //Bumped States

        if(m_Player._isBumped)
        {
            if (!m_currentlyBumped)
            {
                m_Animator.SetTrigger("StartBumped");
            }
        }
        else if(!m_Player._isBumped)
        {
            if (m_currentlyBumped)
            {
                m_Animator.SetTrigger("EndBumped");
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

    }
}
