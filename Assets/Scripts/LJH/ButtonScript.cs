using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void GameStartBtn(){
        SceneManager.LoadScene("StoryScene");
    }

    public void QuitBtn(){
        Application.Quit();
    }

    public void GoToTitle(){
        AudioManager.instance.Play("Intro");
        AudioManager.instance.Stop("Gameplay");
        SceneManager.LoadScene("TitleScene");
    }
}
