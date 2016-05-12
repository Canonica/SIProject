using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
    public Transform _objectToRotateAround;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.LookAt(_objectToRotateAround);
        Camera.main.transform.Translate(Vector3.right * 10 *  Time.deltaTime);
    }
}
