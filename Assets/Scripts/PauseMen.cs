using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public string newGameScene;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public bool isPause;
    bool isOver = false;

    void Update()
    {
        if(Keyboard.current.pKey.wasPressedThisFrame){
            if(isPause){
                ResumeGame();
            } else{
                isPause = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void EndGame(){
        if (isOver == false){
            isOver = true;
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    public void NewGame(){
        SceneManager.LoadScene(newGameScene);
        Time.timeScale = 1f;
    }


    public void ResumeGame(){
        isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame(){
        Application.Quit();
    }
}
