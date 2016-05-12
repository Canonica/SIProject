using UnityEngine;
using System.Collections;

/*
 * Comment émettre un event:
		SoundManagerEvent.emit(SoundManagerType.ENEMY_HIT);
 * 
 * Comment traiter un event (dans un start ou un initialisation)
		EventManagerScript.onEvent += (EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
 * ou:
		void maCallback(EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
		EventManagerScript.onEvent += maCallback;
 * 
 * qui permet de:
		EventManagerScript.onEvent -= maCallback; //Retire l'appel
 */


public enum MusicType
{
    Menu,
    InGame
}

public enum SoundType
{
    ShieldBump,
    ShieldImpact,
    ShieldPickup,
    ShieldThrow,
    PrinceFall,
    PrinceCries,
    Hit,
    CageHit,
    CageCreak,

}

public enum PlayerType
{
    PrincessGrunts,
    PrincessCries,
}

public enum MonsterType
{
    MonsterGrunts
}

public enum ExtraType
{
    Victory,
    HomeRun
}

public enum MenuType
{
    MenuMove
}

public enum VoiceType
{
    W_FlowerPot
}

public class SoundManagerEvent : MonoBehaviour
{

    #region Music
    public delegate void MusicEvent(MusicType emt);
    public static event MusicEvent PlayMusicEvent;

    public static void music(MusicType music)
    {

        if (PlayMusicEvent != null)
        {
            PlayMusicEvent(music);
        }
    }

    #endregion

    #region SoundEvent
    public delegate void SoundEvent(SoundType emt);
    public static event SoundEvent PlaySoundEvent;

    public static void sound(SoundType emt)
    {

        if (PlaySoundEvent != null)
        {
            PlaySoundEvent(emt);
        }
    }

    #endregion

    #region PlayerSound
    public delegate void PlayerSoundEvent(PlayerType emt);
	public static event PlayerSoundEvent PlayPlayerSoundEvent;

    public static void playerSound(PlayerType emt)
    {

        if (PlayPlayerSoundEvent != null)
        {
            PlayPlayerSoundEvent(emt);
        }
    }

    #endregion

    #region MonsterSound
    public delegate void MonsterSoundEvent(MonsterType emt);
    public static event MonsterSoundEvent PlayMonsterSoundEvent;

    public static void monsterSound(MonsterType emt)
    {

        if (PlayMonsterSoundEvent != null)
        {
            PlayMonsterSoundEvent(emt);
        }
    }

    #endregion

    #region Extra
    public delegate void ExtraEvent(ExtraType emt);
    public static event ExtraEvent PlayExtraEvent;

    public static void extra(ExtraType extra)
    {

        if (PlayExtraEvent != null)
        {
            PlayExtraEvent(extra);
        }
    }

    #endregion

    #region Menu
    public delegate void MenuEvent(MenuType emt);
    public static event MenuEvent PlayMenuEvent;

    public static void menu (MenuType menu)
    {

        if (PlayMusicEvent != null)
        {
            PlayMenuEvent(menu);
        }
    }

    #endregion
    
    #region Voices
    public delegate void VoiceEvent(VoiceType emt);
    public static event VoiceEvent PlayVoiceEvent;

    public static void voice(VoiceType voice)
    {

        if (PlayVoiceEvent != null)
        {
            PlayVoiceEvent(voice);
        }
    }

    #endregion

    #region Singleton
    static private SoundManagerEvent s_Instance;
	static public SoundManagerEvent instance
	{
		get
		{
			return s_Instance;
		}
	}
	


	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}
    #endregion

    void Start()
	{
        PlaySoundEvent += (SoundType emt) => { };
        PlayPlayerSoundEvent += (PlayerType emt) => {  };
        PlayMonsterSoundEvent += (MonsterType emt) => { };
        PlayMusicEvent += (MusicType emt) => { };
        PlayMenuEvent += (MenuType emt) => { };
        PlayExtraEvent += (ExtraType emt) => { };
        PlayVoiceEvent += (VoiceType emt) => { };
    }

	

    



}
