using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;
//using UnityEngine.SceneManagement;

public class LobbyInput : MonoBehaviour
{
    public bool[] isEnter;
    public bool[] isReady;

    int nbOfPlayers;
    public bool[] buttonPressedStart;
    public bool[] buttonPressedX;
    public GameObject[] _playerPrefab;
    public GameObject[] _playerSpawnPosition;

    public Text EnterText;
    public Text ReadyText;

    public Text LaunchText;
    int nbOfSecondsBefore = 5;
    bool allPlayersAreReady;
    //public AudioClip audioclipMenuMove;
    //private GameObject speakerMenuMove;
    // Use this for initialization
    void Start ()
	{
        isReady = new bool[4];
        isEnter = new bool[4];

        buttonPressedStart = new bool[4];
        buttonPressedX = new bool[4];
        allPlayersAreReady = false;
        nbOfPlayers = 0;
    }

	void Update ()
	{
		if (GameManager.GetInstance().gamestate == GameManager.GameState.menu) {

            for(int i =1; i<5; i++)
            {
                if (XInput.instance.getButton(i, 'S') == ButtonState.Pressed && !buttonPressedStart[i - 1])
                {
                    buttonPressedStart[i - 1] = true;
                    isEnter[i - 1] = !isEnter[i - 1];
                    if(!isEnter[i - 1])
                    {
                        isReady[i - 1] = false;
                    }
                    IncreaseNbOfPlayers((i - 1));

                }
                else if (XInput.instance.getButton(i, 'S') == ButtonState.Released && buttonPressedStart[i - 1])
                {
                    buttonPressedStart[i - 1] = false;
                }

                if (XInput.instance.getButton(i, 'X') == ButtonState.Pressed && !buttonPressedX[i - 1])
                {
                    buttonPressedX[i - 1] = true;
                    if(isEnter[i - 1])
                    {
                        isReady[i - 1] = !isReady[i - 1];
                        IncreaseNbOfPlayers((i - 1));
                    }
                }
                else if (XInput.instance.getButton(i, 'X') == ButtonState.Released && buttonPressedX[i - 1])
                {
                    buttonPressedX[i - 1] = false;
                }

                
            }

           
        }
	}

    void IncreaseNbOfPlayers(int index)
    {
        if (isReady[index] && isEnter[index])
        {
            if(nbOfPlayers < 4)
            {
                nbOfPlayers++;
            }
        }
        else
        {
            if (nbOfPlayers > 0)
            {
                nbOfPlayers--;
            }
        }
        PlayerManager.GetInstance()._nbOfPlayers = nbOfPlayers;
        if (nbOfPlayers >= 2  && allPlayersAreReady)
        {
            StartCoroutine(LaunchGame());
        }
    }

    IEnumerator LaunchGame()
    {
        LaunchText.text = "Game starts in " + nbOfSecondsBefore;
        while (nbOfSecondsBefore > 0 && nbOfPlayers >= 2)
        {
            yield return new WaitForSeconds(1);
            nbOfSecondsBefore--;
            LaunchText.text = "Game starts in " + nbOfSecondsBefore;
            if (nbOfSecondsBefore == 0)
            {
                Launch();
            }
           
        }
        LaunchText.text = "";
    }

	void CheckReadiness ()
	{
		
//			HowToPlay.GetComponent<Animator> ().SetTrigger ("In");

			Launch ();
			GameObject.Find ("Player02").SetActive (false);
			GameObject.Find ("MainMenuButton").SetActive (false);
		
	}

	void Launch ()
	{
		Time.timeScale = 1;
		GameManager.GetInstance ().gamestate = GameManager.GameState.beforePlay;
		SceneManager.LoadScene (1);
	}

}
