using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _camera;
    private static GameManager _instance = null;
    public Text _textWin;
    public static GameManager GetInstance()
    {
        return _instance;
    }
    public enum GameState { menu, pause, playing, endOfGame, beforePlay };
    public GameState gamestate;
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

        
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            _textWin = GameObject.Find("TextWin").GetComponent<Text>();
            _textWin.DOFade(0, 0);
        }
    }

    public void EndGame(bool won)
    {
        if (!won)
        {
            _textWin.text = "DEFEAT";
            _textWin.DOFade(1, 0.7f).OnComplete(()=>_textWin.transform.DOShakePosition(3, 2, 10).OnComplete(() => _textWin.DOFade(0, 0.7f)));
            Invoke("GoBackMainMenu", 4);
        }
        else
        {
            _textWin.text = "VICTORY";
            _textWin.DOFade(1, 0.7f).OnComplete(() => _textWin.transform.DOShakePosition(3, 2, 10).OnComplete(()=> _textWin.DOFade(0, 0.7f)));
            Invoke("GoBackMainMenu", 4);
        }
    }

    public void GoBackMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}