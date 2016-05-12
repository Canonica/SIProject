﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	#region Members

	[Header("MUSICS")]
	public List<AudioClip> Music = new List<AudioClip>();

	[Header("SOUNDS")]
	public List<AudioClip> Sound= new List<AudioClip>();

    [Header("PLAYER")]
    public List<AudioClip> Player = new List<AudioClip>();

    [Header("MONSTER")]
    public List<AudioClip> Monster = new List<AudioClip>();

    [Header("EXTRA")]
    public List<AudioClip> Extra = new List<AudioClip>();

    [Header("MENU")]
    public List<AudioClip> Menu = new List<AudioClip>();

    [Header("VOICES")]
	public List<AudioClip> Voice = new List<AudioClip>();

	[Header("Sound Listeners")]
	public List<AudioSource> Source = new List<AudioSource>();


    #endregion

    bool m_Ready = false;

	// Use this for initialization
	void Awake()
	{
        SoundManagerEvent.PlaySoundEvent += PlaySound;
        SoundManagerEvent.PlayPlayerSoundEvent += PlayPlayerSound;
        SoundManagerEvent.PlayMonsterSoundEvent += PlayMonsterSound;
        SoundManagerEvent.PlayMusicEvent += PlayMusic;
        SoundManagerEvent.PlayMenuEvent += PlayMenu;
        SoundManagerEvent.PlayExtraEvent += PlayExtra;
        SoundManagerEvent.PlayVoiceEvent += PlayVoice;
    }

	void OnDestroy()
	{
        SoundManagerEvent.PlaySoundEvent -= PlaySound;
        SoundManagerEvent.PlayPlayerSoundEvent -= PlayPlayerSound;
        SoundManagerEvent.PlayMonsterSoundEvent -= PlayMonsterSound;
        SoundManagerEvent.PlayMusicEvent -= PlayMusic;
        SoundManagerEvent.PlayMenuEvent -= PlayMenu;
        SoundManagerEvent.PlayExtraEvent -= PlayExtra;
        SoundManagerEvent.PlayVoiceEvent -= PlayVoice;
    }
    
    public void PlayMusic(MusicType emt)
    {
        switch (emt)
        {
            case MusicType.Menu:
                Source[0].Stop();
                Source[0].clip = Music[1];
                Source[0].Play();
                Source[0].loop = true;

                break;

            case MusicType.InGame:
                Source[0].Stop();
                Source[0].clip = Music[0];
                Source[0].Play();
                Source[0].loop = true;
                break;
        }
    }

    public void PlaySound(SoundType emt)
	{
		switch (emt)
		{
            case SoundType.ShieldBump:
                //multiple
                break;


            case SoundType.ShieldImpact:
                //Multiple
                break;

            case SoundType.ShieldPickup:
                //Solo
                break;

            case SoundType.ShieldThrow:
                //Solo
                break;

            case SoundType.PrinceFall:
                //Solo
                break;

            case SoundType.PrinceCries:
                //Multiple
                break;

            case SoundType.Hit:
                //Multiple
                break;

            case SoundType.CageHit:
                //Multiple
                break;

            case SoundType.CageCreak:
                //Multiple
                break;
                /*
            case SoundType.HitAir:
                Source[1].Stop();
                Source[1].clip = Sound[2];
                Source[1].Play();
                break;

            case SoundType.PotBreak:
                Source[2].Stop();

                if (Random.Range(1, 3) == 1)
                {
                    Source[2].clip = Sound[5];
                }
                else
                {
                    Source[2].clip = Sound[6];
                }

                Source[2].Play();
                break;
                */
        }
	}
    
    public void PlayPlayerSound(PlayerType emt)
    {
        /*
        switch (emt)
        {
            case MowerType.MowerStart:
                    Source[3].loop = false;
                    Source[3].Stop();
                    Source[3].clip = Mower[0];
                    Source[3].Play();
                Source[3].volume = 1f;
                break;

            case MowerType.MowerStartAndGo:
                    Source[3].loop = false;
                    Source[3].Stop();
                    Source[3].clip = Mower[1];
                    Source[3].Play();
                Source[3].volume = 1f;
                break;

            case MowerType.MoweGrass:

                    Source[3].Stop();
                    Source[3].clip = Mower[2];
                    Source[3].Play();
                    Source[3].loop = true;
                break;
        }
        */
    }

    public void PlayMonsterSound(MonsterType emt)
    {

    }

    public void PlayExtra(ExtraType emt)
    {
        switch (emt)
        {
            case ExtraType.HomeRun:

                Source[4].Stop();
                Source[4].clip = Extra[0];
                Source[4].Play();
                break;


            case ExtraType.Victory:

                Source[5].Stop();
                Source[5].clip = Extra[1];
                Source[5].Play();
                break;
        }
    }

    public void PlayMenu(MenuType emt)
    {
        switch (emt)
        {
            case MenuType.MenuMove:

                Source[11].Stop();
                Source[11].clip = Menu[0];
                Source[11].Play();

                break;
        }
    }

    public void PlayVoice(VoiceType emt)
    {
        switch (emt)
        {
            case VoiceType.W_FlowerPot:
                Source[9].Stop();
                Source[9].clip = Voice[0];
                Source[9].Play();
                break;
        }
    }





}
