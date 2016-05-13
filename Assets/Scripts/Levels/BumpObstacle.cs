using UnityEngine;
using System.Collections;

public class BumpObstacle : MonoBehaviour {

    public float force = 10f;
	// Use this for initialization
	public void Bump(Vector3 parDirection)
    {
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        transform.GetComponent<Rigidbody>().AddForce(parDirection * force);
    }
}
