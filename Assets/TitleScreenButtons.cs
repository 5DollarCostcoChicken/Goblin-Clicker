using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    public LoadGame loadGame;

    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGameButton()
    {
        loadGame.Load();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
