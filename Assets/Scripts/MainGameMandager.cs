using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameMandager : MonoBehaviour {

    bool isGamePaused = false;
    [SerializeField] Transform ballsContainer;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] TrajectoryRenderer trajectoryRenderer;
    [SerializeField] Camera camera;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] Image pauseButtonSpriteRenderer;

    [SerializeField] Sprite pauseButtonSprite;
    [SerializeField] Sprite resumeButtonSprite;

    private void Update() {}

    public void ToggleGamePause() {
        isGamePaused = !isGamePaused;

        if(isGamePaused) {
            PauseGame();
        } else if(!isGamePaused) {
            ResumeGame();
        }
    }

    public void PauseGame() {
        isGamePaused = true;

        Time.timeScale = 0;

        pauseMenu.SetActive(isGamePaused);
        pauseButtonSpriteRenderer.sprite = resumeButtonSprite;
    }

    public void ResumeGame() {
        isGamePaused = false;

        Time.timeScale = 1;

        pauseMenu.SetActive(isGamePaused);
        pauseButtonSpriteRenderer.sprite = pauseButtonSprite;
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        ResumeGame();
    }

    public void GoToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public GameObject AddBall() {
        GameObject ball = Instantiate(ballPrefab, ballsContainer);

        ball.transform.SetParent(ballsContainer);
        ball.GetComponent<Ball>().SetValues(camera, trajectoryRenderer);

        return ball;
    }

    public GameObject AddRandomBall() {
        GameObject ball = AddBall();

        ball.GetComponent<Ball>().SetRandomValues(true, "by mass", true, true);
        return ball;
    }

    public void AddRandomBallVoid() {
        AddRandomBall();
    }
}