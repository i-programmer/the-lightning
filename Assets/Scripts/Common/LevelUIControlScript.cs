using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIControlScript : MonoBehaviour {

    public Text pointText;
    public GameObject gameOverPauseScreen;
    public GameObject points;
    public Button pauseMenuBtn;
    public Button restartBtn;
    public Button resumeBtn;    

    public void ToMain() {
        GetComponentInParent<GameManager>().ClearScene();        
        SceneManager.LoadScene("Main");
    }


    public void PauseMenu() {        
        pauseMenuBtn.gameObject.SetActive(false);        
        gameOverPauseScreen.SetActive(true);

        resumeBtn.gameObject.SetActive(true);
    }


    public void ResumeGame() {
        pauseMenuBtn.gameObject.SetActive(true);
        gameOverPauseScreen.SetActive(false);        
        resumeBtn.gameObject.SetActive(false);
    }


    public void RestartGame() {
        restartBtn.gameObject.SetActive(false);    
        points.SetActive(false);
        gameOverPauseScreen.SetActive(false);        
    }


    public void GameOverMenu(int gamePoints) {
        resumeBtn.gameObject.SetActive(false);
        gameOverPauseScreen.SetActive(true);        
        restartBtn.gameObject.SetActive(true);

        pointText.text = gamePoints.ToString();
        points.SetActive(true);
    }
}
