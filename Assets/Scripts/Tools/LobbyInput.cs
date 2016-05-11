using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;
//using UnityEngine.SceneManagement;

public class LobbyInput : MonoBehaviour
{
    public bool[] isReady;
	bool isReady_1 = false;
	bool isReady_2 = false;
    bool isReady_3 = false;
    bool isReady_4 = false;

    int nbOfPlayers;
    public bool[] buttonPressedX;

    public GameObject[] _playerPrefab;
    public GameObject[] _playerSpawnPosition;

    public Text EnterText;
    public Text ReadyText;

    //public AudioClip audioclipMenuMove;
    //private GameObject speakerMenuMove;
    // Use this for initialization
    void Start ()
	{
        isReady = new bool[4];

        buttonPressedX = new bool[4];
    }

	void Update ()
	{
		if (GameManager.GetInstance().gamestate == GameManager.GameState.menu) {

            for(int i =1; i<5; i++)
            {
                if (XInput.instance.getButton(i, 'S') == ButtonState.Pressed && !buttonPressedX[i - 1])
                {
                    buttonPressedX[i - 1] = true;
                    isReady[i - 1] = !isReady[i - 1];
                }
                else if (XInput.instance.getButton(i, 'S') == ButtonState.Released && buttonPressedX[i - 1])
                {
                    buttonPressedX[i - 1] = false;
                }
            }
        }
	}

    void IncreaseNbOfPlayers(bool isIncreased)
    {
        if (isIncreased)
        {
            nbOfPlayers++;
        }
    }

	void CheckReadiness ()
	{
		if (isReady_1 && isReady_2 || (isReady_3 || isReady_4)) {
//			HowToPlay.GetComponent<Animator> ().SetTrigger ("In");

			Launch ();
			GameObject.Find ("Player02").SetActive (false);
			GameObject.Find ("MainMenuButton").SetActive (false);
		}
	}

	void Launch ()
	{
		Time.timeScale = 1;
		GameManager.GetInstance ().gamestate = GameManager.GameState.beforePlay;
		SceneManager.LoadScene (1);
	}

}
