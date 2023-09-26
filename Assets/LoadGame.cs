using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void Load()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(1);
        StartCoroutine(load());
    }
    IEnumerator load()
    {
        yield return new WaitForSeconds(.01f);
        GameData data = SaveSystem.LoadPlayer();
        GameManager.Load(data);
    }
}
