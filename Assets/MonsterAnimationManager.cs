using UnityEngine;
using System.Collections;

public class MonsterAnimationManager : MonoBehaviour {

    public Animator m_Animator;
    private Monster m_Monster;

	// Use this for initialization
	void Start () {
        m_Monster = GetComponent<Monster>();

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void LaunchBump()
    {
        m_Animator.SetTrigger("StartBump");
    }

    public void StopBump()
    {
        m_Animator.SetTrigger("EndBump");
    }

    public void StartFalling()
    {
        m_Animator.SetTrigger("StartFalling");
    }

    public void StartAttack()
    {
        m_Animator.SetTrigger("StartAttack");
    }
}
