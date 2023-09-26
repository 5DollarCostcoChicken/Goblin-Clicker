using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    float aridVolume = 0;
    float battleVolume = 0;
    float sfxVolume = 0;

    public void pause()
    {
        pauseMenu.SetActive(true);
        aridVolume = GameManager.aridAudioSource.volume;
        battleVolume = GameManager.battleAudioSource.volume;
        sfxVolume = GameManager.battleSFXSource.volume;
        GameManager.aridAudioSource.volume = 0;
        GameManager.battleSFXSource.volume = 0;
        GameManager.battleAudioSource.volume = 0;
        Time.timeScale = 0f;
    }
    public void unPause()
    {
        pauseMenu.SetActive(false);
        GameManager.aridAudioSource.volume = aridVolume;
        GameManager.battleSFXSource.volume = sfxVolume;
        GameManager.battleAudioSource.volume = battleVolume;
        Time.timeScale = 1f;
    }

    public void saveAndExit()
    {
        SaveSystem.SavePlayer();
        Application.Quit();
    }
}
