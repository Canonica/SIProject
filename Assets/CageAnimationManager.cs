using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Cage))]
public class CageAnimationManager : MonoBehaviour {

    public Animator m_Animator;
    private Cage m_Cage;

    //Helpers
    private bool m_currentlyBumped;

    // Use this for initialization
    void Start () {
        m_Cage = GetComponent<Cage>();

    }
	
	// Update is called once per frame
	void Update () {
        if (m_Cage._isBumped)
        {
            if (!m_currentlyBumped)
            {
                m_Animator.SetTrigger("StartBumped");
            }
        }
        /*else if (!m_Cage._isBumped)
        {
            if (m_currentlyBumped)
            {
                m_Animator.SetTrigger("EndBumped");
            }
        }*/

        m_currentlyBumped = m_Cage._isBumped;

    }
}
