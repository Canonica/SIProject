using UnityEngine;
using System.Collections;
using DG.Tweening;
public class SoundManager : MonoBehaviour
{

    static SoundManager instance;
    public GameObject speakerPrefab;
    private GameObject speaker;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    // getter
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Use this for initialization
    void Awake()
    {
        instance = this;
        speakerPrefab = Resources.Load<GameObject>("Prefabs/Speaker");
    }

    public GameObject playSound(AudioClip myclip, float volume, bool doRandomPitch, bool doIntro)
    {
        speaker = (GameObject)Instantiate(speakerPrefab, Vector3.zero, Quaternion.identity);
        AudioSource audioSource = speaker.GetComponent<AudioSource>();
        if (doRandomPitch)
        {
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            audioSource.pitch = randomPitch;
        }
        if (doIntro)
        {
            audioSource.DOFade(0, 0);
            audioSource.DOFade(0.2f, 8f);
        }
        audioSource.clip = myclip;
        audioSource.Play();
        audioSource.volume = volume;
        return speaker;
    }

    public GameObject RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        speaker = (GameObject)Instantiate(speakerPrefab, Vector3.zero, Quaternion.identity);
        AudioSource audioSource = speaker.GetComponent<AudioSource>();
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        audioSource.pitch = randomPitch;
        audioSource.clip = clips[randomIndex];
        audioSource.Play();
        return speaker;
    }
}