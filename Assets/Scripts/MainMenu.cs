using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextScene;
    public int LevelSelection;
    #region Play Buttons Methods
    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(LevelSelection);
    }
    #endregion

    public void StartTimer() {
        GameRecorder.StartTimer();
    }

    public void Reset() {
        GameRecorder.Reset();
    }

    #region General Application Button Methods
    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    #endregion
}
