using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
abstract public class Monster : MonoBehaviour {

    public bool _isBumped;
    public float _speed;
    public GameObject _target;
    public NavMeshAgent _agent;
    public bool m_isFlying;

    public float _bumpForce;
    public float _counterBumpForce;
    public float _bumpHeight;
    public float _bumpTime;

    abstract public void FindTarget();
    abstract public void Attack(GameObject parTarget);
    abstract public void Death();
    abstract public IEnumerator Stun(float parTime);
	
}
