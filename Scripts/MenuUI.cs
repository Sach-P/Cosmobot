using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject controlsMenuUI;

    public AudioManager audioManager;

    void Awake(){
        startMenuUI.SetActive(true);
    }

    public void Play(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Controls(){
        startMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
    }

    public void Menu(){
        startMenuUI.SetActive(true);
        controlsMenuUI.SetActive(false);
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
}
