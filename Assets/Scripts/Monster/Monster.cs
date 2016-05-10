using UnityEngine;
using System.Collections;

abstract public class Monster : MonoBehaviour {

    public bool _isBumped;
    public float _speed;
    public GameObject _target;
    public NavMeshAgent _agent;

    abstract public void FindTarget();
    abstract public void Attack();

    abstract public void Death();
	
}
