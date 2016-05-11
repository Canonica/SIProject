using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class Levels : MonoBehaviour {
    public Waves[] _wavesArray;
    public Text _waveText;
    public Waves _currentWave;

	// Use this for initialization
	void Start () {
        _wavesArray[0].StartSpawning();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartWave()
    {

    }
}
