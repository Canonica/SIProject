using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Clignotage : MonoBehaviour {

    public GameObject objectToGetRenderer;
    Renderer renderer;

    float _initialFresnel;
    // Use this for initialization
    void Start () {
        renderer = objectToGetRenderer.GetComponent<Renderer>();
        _initialFresnel = renderer.material.GetFloat("_fresnel_strength");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HitClignote();
        }
	}

    void HitClignote()
    {
        renderer.material.DOFloat(0, "_fresnel_strength", 0.2f).OnComplete(() => renderer.material.DOFloat(_initialFresnel, "_fresnel_strength", 1f));
    }
}
