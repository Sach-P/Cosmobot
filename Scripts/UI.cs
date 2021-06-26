using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;

    public GameObject pauseMenuUI;

    public GameObject gameOverUI;

    public GameObject controlsMenuUI;
    public GameObject settingsMenuUI;
    public GameAudioManager gameAudioManager;

    public AudioMixer audioMixer;

    void Awake(){
        Time.timeScale = 1f;
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if(!GameIsOver)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        controlsMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Controls(){
        controlsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void Settings(){
        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void GameOver(){
        gameOverUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        GameIsOver = true;
        Time.timeScale = 1f;
    }

    public void MainMenu(){
        GameIsOver = false;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void PlayAgain(){
        GameIsOver = false;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Click(){
        AudioManager.instance.Play("UIone");
    }

    public void Hover(){
        AudioManager.instance.Play("UItwo");
    }

    public void ClickPlay(){
        AudioManager.instance.Play("Play");
    }

    public void setVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
    }

}
