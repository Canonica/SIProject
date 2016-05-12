using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
public class MenuManager : MonoBehaviour
{

    public static MenuManager instance = null;

    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject TutoCanvas;
    public GameObject LobbyCanvas;

    public CanvasGroup MainMenuCanvasGroup;
    public CanvasGroup CreditsCanvasGroup;
    public CanvasGroup TutoCanvasGroup;
    public CanvasGroup LobbyCanvasGroup;

    bool isInCredit;
    bool isIntuto;
    bool buttonPressedB;
    bool isInLobby;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    void OnLeveLWasLoaded(int sceneNumber)
    {
        if(sceneNumber == 0)
        {
            MainMenuCanvas = GameObject.Find("CanvasMainMenu");
            CreditsCanvas = GameObject.Find("CanvasCredits");
            TutoCanvas = GameObject.Find("CanvasTuto");
            LobbyCanvas = GameObject.Find("CanvasLobby");

            MainMenuCanvasGroup = MainMenuCanvas.GetComponent<CanvasGroup>();
            CreditsCanvasGroup = CreditsCanvas.GetComponent<CanvasGroup>();
            TutoCanvasGroup = TutoCanvas.GetComponent<CanvasGroup>();
            LobbyCanvasGroup = LobbyCanvas.GetComponent<CanvasGroup>();
        }
    }
    // Use this for initialization
    void Start()
    {
        MainMenuCanvas = GameObject.Find("CanvasMainMenu");
        CreditsCanvas = GameObject.Find("CanvasCredits");
        TutoCanvas = GameObject.Find("CanvasTuto");
        LobbyCanvas = GameObject.Find("CanvasLobby");

        MainMenuCanvasGroup = MainMenuCanvas.GetComponent<CanvasGroup>();
        CreditsCanvasGroup = CreditsCanvas.GetComponent<CanvasGroup>();
        TutoCanvasGroup = TutoCanvas.GetComponent<CanvasGroup>();
        LobbyCanvasGroup = LobbyCanvas.GetComponent<CanvasGroup>();

        CreditsCanvasGroup.DOFade(0f, 0f);
        CreditsCanvas.SetActive(false);
        TutoCanvasGroup.DOFade(0f, 0f);
        TutoCanvas.SetActive(false);
        LobbyCanvasGroup.DOFade(0f, 0f);
        LobbyCanvas.SetActive(false);

        buttonPressedB = false;
        isInLobby = false;
        isInCredit = false;
        isIntuto = false;
        //CreditsCanvas.GetComponent<MenuHandler>().enabled = false;
    }

    void Update()
    {
        for(int i = 1; i < 5; i++)
        {
            if (XInput.instance.getButton(i, 'B') == ButtonState.Pressed && !buttonPressedB)
            {
                buttonPressedB = true;

                if (isInCredit)
                {
                    isInCredit = false;
                    Main_Menu_From_Credit();
                }
                else if (isIntuto)
                {
                    isIntuto = false;
                    MainMenuFromTuto();
                }
                else if (isInLobby)
                {
                    isInLobby = false;
                    MainMenuFromLobby();
                }
            }
            else if (XInput.instance.getButton(i, 'B') == ButtonState.Released && buttonPressedB)
            {
                buttonPressedB = false;
            }
        }
        
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Main_Menu()
    {
        HideAll();
        MainMenuCanvas.SetActive(true);
        ChangeCanvas(MainMenuCanvasGroup, MainMenuCanvasGroup);
        SceneManager.LoadScene(0);
        //CreditsCanvas.GetComponent<MenuHandler>().enabled = false;
    }

    public void MainMenuFromLobby()
    {
        HideAll();
        MainMenuCanvas.SetActive(true);
        ChangeCanvas(LobbyCanvasGroup, MainMenuCanvasGroup);
    }

    public void Main_Menu_From_Credit()
    {
        HideAll();
        MainMenuCanvas.SetActive(true);
        //CreditsCanvas.GetComponent<MenuHandler>().enabled = false;
        //MainMenuCanvas.GetComponent<MenuHandler>().enabled = true;
        ChangeCanvas(CreditsCanvasGroup, MainMenuCanvasGroup);
        
    }

    public void MainMenuFromTuto()
    {
        HideAll();
        MainMenuCanvas.SetActive(true);
        //CreditsCanvas.GetComponent<MenuHandler>().enabled = false;
        //MainMenuCanvas.GetComponent<MenuHandler>().enabled = true;
        ChangeCanvas(TutoCanvasGroup, MainMenuCanvasGroup);

    }

    public void ShowCredits()
    {
        HideAll();
        //CreditsCanvas.GetComponent<MenuHandler>().enabled = true;
        ChangeCanvas(MainMenuCanvasGroup, CreditsCanvasGroup);
        CreditsCanvas.SetActive(true);
        isInCredit = true;
    }

    public void ShowTuto()
    {
        HideAll();
        //CreditsCanvas.GetComponent<MenuHandler>().enabled = true;
        ChangeCanvas(MainMenuCanvasGroup, TutoCanvasGroup);
        TutoCanvas.SetActive(true);
        isIntuto = true;
    }

    public void ShowLobby()
    {
        HideAll();
        ChangeCanvas(MainMenuCanvasGroup, LobbyCanvasGroup);
        LobbyCanvas.SetActive(true);
        isInLobby = true;
    }

    private void ChangeCanvas(CanvasGroup canvasOut, CanvasGroup canvasIn)
    {
        canvasOut.DOFade(0, 0.5f);
        canvasIn.DOFade(1, 0.5f);
    }

    private void HideAll()
    {
        CreditsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
    }
}

