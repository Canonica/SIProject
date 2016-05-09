using UnityEngine;
using System.Collections;
using DG.Tweening;
using XInputDotNetPure;

public class Player : MonoBehaviour {
    public int _playerId;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (XInput.instance.getButton(_playerId, 'A') == ButtonState.Pressed)
        {
            Debug.Log(_playerId + "A");
        }
    }
}
