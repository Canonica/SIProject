using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;
using DG.Tweening;
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

    public GameObject[] _playerVisual;

    public Image EnterText;
    public Image ReadyText;

    public Text LaunchText;
    int currentNbOfSecondsBefore;
    int maxNbOfSecondsBefore = 5;
    public bool playersReady;
    bool isInStarting;
    //public AudioClip audioclipMenuMove;
    //private GameObject speakerMenuMove;
    // Use this for initialization
    void Start ()
	{
        isInStarting = false;
        currentNbOfSecondsBefore = maxNbOfSecondsBefore;
        isReady = new bool[4];
        isEnter = new bool[4];
        _playerVisual = new GameObject[4];
        _playerPrefab = new GameObject[4];
        GameObject[] tempSpawner = GameObject.FindGameObjectsWithTag("PlayerSpawner");
        _playerSpawnPosition = new GameObject[4];
        for (int i = 1; i < 5; i++)
        {
            _playerPrefab[i - 1] = Resources.Load("Prefabs/GraphedPlayer" + i) as GameObject;
            _playerSpawnPosition[i-1] = tempSpawner[i-1];
        }
        System.Array.Reverse(_playerSpawnPosition);
        buttonPressedStart = new bool[4];
        buttonPressedX = new bool[4];
        playersReady = false;
    }

	void Update ()
	{
		if (GameManager.GetInstance().gamestate == GameManager.GameState.menu) {
            GetButtonStart();
            GetbuttonX();
            bool _playersReady = true;
            
            nbOfPlayers = 0;
            for(int i = 0; i<4; i++)
            {
                if (isEnter[i])
                {
                    if (!isReady[i])
                    {
                        _playersReady = false;
                        break;
                    }
                    else
                        nbOfPlayers++;
                }
                else
                {
                    isReady[i] = false;
                }
            }
            if (nbOfPlayers < 2 && _playersReady)
                _playersReady = false;

            if (_playersReady != playersReady)
            {
                playersReady = _playersReady;
                if (_playersReady && (nbOfPlayers >= 2))
                {
                    if (!isInStarting)
                    {
                        Debug.Log("StartCoroutine");
                        isInStarting = true;
                        currentNbOfSecondsBefore = maxNbOfSecondsBefore;
                        StartCoroutine(LaunchGame());
                    }
                }
                else
                {
                    Debug.Log("StopCoroutine");
                    StopCoroutine("LaunchGame");
                    isInStarting = false;
                    LaunchText.text = "";
                }
            }
        }
	}

    void GetButtonStart()
    {
        for (int i = 1; i < 5; i++)
        {
            if(XInput.instance.getButton(i, 'S') == ButtonState.Pressed && !buttonPressedStart[i - 1])
            {
                //EnterText.DOKill();
                EnterText.transform.DOShakeScale(0.2f, 0.3f, 5).OnComplete((() => EnterText.transform.DOScale(new Vector3(1, 1, 1), 0f)));
                //EnterText.DOKill();
                buttonPressedStart[i - 1] = true;
                isEnter[i - 1] = !isEnter[i - 1];
                if (isEnter[i - 1])
                {
                    _playerVisual[i - 1] = Instantiate(_playerPrefab[i - 1], _playerSpawnPosition[i - 1].transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
                }
                if (isEnter[i - 1] == false)
                {
                    Destroy(_playerVisual[i - 1].gameObject);
                }
            }
            else if(XInput.instance.getButton(i, 'S') == ButtonState.Released && buttonPressedStart[i - 1])
            {
                buttonPressedStart[i - 1] = false;
            }
        }   
    }

    void GetbuttonX()
    {
        for (int i = 1; i < 5; i++)
        {
            if(XInput.instance.getButton(i, 'X') == ButtonState.Pressed && !buttonPressedX[i - 1])
            {
                buttonPressedX[i - 1] = true;
                if (isEnter[i - 1])
                {
                    isReady[i - 1] = !isReady[i - 1];
                }
                //ReadyText.DOKill();
                ReadyText.transform.DOShakeScale(0.2f, 0.3f, 5).OnComplete((() => ReadyText.transform.DOScale(new Vector3(1, 1, 1), 0f)));
                //ReadyText.DOKill();
            }
            else if (XInput.instance.getButton(i, 'X') == ButtonState.Released && buttonPressedX[i - 1])
            {
                buttonPressedX[i - 1] = false;
            }
        }
    }

    IEnumerator LaunchGame()
    {
        LaunchText.text = "Game starts in " + currentNbOfSecondsBefore;
        while (currentNbOfSecondsBefore >= 0 && playersReady && isInStarting)
        {
            yield return new WaitForSeconds(1);
            if (currentNbOfSecondsBefore == 0)
            {
                PlayerManager.GetInstance()._nbOfPlayers = nbOfPlayers;
                Launch();
            }
            currentNbOfSecondsBefore--;
            LaunchText.text = "Game starts in " + currentNbOfSecondsBefore;
        }
        LaunchText.text = "";
        isInStarting = false;
        yield return null;
    }

	void Launch ()
	{
		Time.timeScale = 1;
		GameManager.GetInstance ().gamestate = GameManager.GameState.beforePlay;
		SceneManager.LoadScene (1);
	}

}
