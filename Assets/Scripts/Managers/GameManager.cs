using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

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

    public void EndGame(bool won)
    {
        if (!won)
        {
            Debug.Log("loose");
        }
        else
        {
            Debug.Log("win");
        }
    }


}