using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

    public Canvas pauseMenu;
    public Button returnToMainButton;
    public Button restartButton;

    void Start() {
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        returnToMainButton = returnToMainButton.GetComponent<Button>();
        restartButton = restartButton.GetComponent<Button>();
        //pauseMenu.enabled = false;
    }

    public void ReturnPress() {
        SceneManager.LoadScene(0);
    }

    public void RestartPress() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
