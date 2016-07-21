using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{

    public Canvas exitMenu;
    public Button playButton;
    public Button exitButton;

    void Start()
    {
        exitMenu = exitMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        exitMenu.enabled = false;
    }

    public void ExitPress()
    {
        exitMenu.enabled = true; //enable the Quit menu when we click the Exit button
        playButton.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
        exitButton.enabled = false;
    }

    public void NoPress() //this function will be used for our "NO" button in our Quit Menu

    {
        exitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
        playButton.enabled = true; //enable the Play and Exit buttons again so they can be clicked
        exitButton.enabled = true;
    }

    public void StartLevel() //this function will be used on our Play button

    {
        SceneManager.LoadScene(1); //this will load our first level from our build settings. "1" is the second scene in our game
    }

    public void ExitGame() //This function will be used on our "Yes" button in our Quit menu

    {
        Application.Quit(); //this will quit our game. Note this will only work after building the game
    }

}
