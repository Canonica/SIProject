using UnityEngine;
using System.Collections;
using DG.Tweening;
public class ClignotageMonster : MonoBehaviour {

    public GameObject objectToGetRenderer;
    Renderer renderer;

    float _initialFresnel;
    // Use this for initialization
    void Start () {
        renderer = objectToGetRenderer.GetComponent<Renderer>();
        _initialFresnel = renderer.materials[1].GetFloat("_fresnel_strength");
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void HitClignote()
    {
        renderer.materials[1].DOFloat(0, "_fresnel_strength", 0.2f).OnComplete(() => renderer.materials[1].DOFloat(_initialFresnel, "_fresnel_strength", 1f));
    }
}
