using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public Text goblinCounter;
    public Text goblinMultiplierCounter;
    public Text autoGoblinCounter;
    public GameObject goblinCounterTexts;
    public GoblinIncrementParticles incrementParticles;
    public ShopButton shopButton;
    public WarButton warButton;
    float timer = 0;
    public GameObject transition;
    public GameObject[] warUI;
    public GameObject[] goblinUI;
    public GameObject[] battleUI;
    public bool isMoving = false;
    public GameObject armyCounters;
    public TextMeshProUGUI orcNumbers;
    public TextMeshProUGUI wizardNumbers;
    public TextMeshProUGUI trollNumbers;
    public TextMeshProUGUI catapultNumbers;
    public Image victoryButton;
    public GameObject pauseScreen;
    public void Update()
    {
        goblinCounter.text = "Goblins: " + GameManager.goblins.ToString("n0");
        orcNumbers.text = "" + GameManager.instance.orcArmyCount.ToString("n0");
        wizardNumbers.text = "" + GameManager.instance.wizardArmyCount.ToString("n0");
        trollNumbers.text = "" + GameManager.instance.trollArmyCount.ToString("n0");
        catapultNumbers.text = "" + GameManager.instance.catapultArmyCount.ToString("n0");
        if (GameManager.autoGoblins == 0)
            autoGoblinCounter.enabled = false;
        else
            autoGoblinCounter.enabled = true;
        autoGoblinCounter.text = "Goblins Per Second: " + GameManager.autoGoblins.ToString("n0");
        goblinMultiplierCounter.text = "Goblins Per Click: " + GameManager.multiplier.ToString();
        timer += Time.deltaTime;
        if (timer > (1f / GameManager.autoGoblins) && GameManager.autoGoblins < 12)
        {
            GameManager.goblins++;
            timer = 0;
        }
        else if (timer > .083333333f && GameManager.autoGoblins >= 12)
        {
            GameManager.goblins += (int)(GameManager.autoGoblins / 12);
            timer = 0;
        }
    }
    public void Increment()
    {
        GameManager.goblins += GameManager.multiplier;
        incrementParticles.Pulse();
        if (GameManager.goblins >= 10 && !GameManager.ShopOpen)
            shopButton.SpringUp();
        if ((!GameManager.bar || GameManager.goblins >= 10000) && !GameManager.WarOpen)
        {
            warButton.SpringUp();
            armyCounters.SetActive(true);
            GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinSwords.texture;
        }
    }
    public void Increment2()
    {
        GameManager.goblins += GameManager.multiplier;
    }
    public void Transition(string UIState)
    {
        if (!isMoving)
            StartCoroutine(TransitionMove(UIState));
    }
    IEnumerator TransitionMove(string UIState)
    {
        isMoving = true;
        transition.transform.position = new Vector3(3500 * (Screen.width / 1920f), transition.transform.position.y, transition.transform.position.z);
        int i = 0;
        while (transition.transform.position.x > 975 * (Screen.width / 1920f))
        {
            transition.transform.position = new Vector3(3500 * (Screen.width / 1920f) - .2f * Mathf.Pow(i, 2) * (Screen.width / 1920f), transition.transform.position.y, transition.transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        yield return new WaitForSeconds(.1f);
        switch (UIState)
        {
            case "goblin":
                RenderGoblin();
                break;
            case "war":
                RenderWar();
                break;
            case "battle":
                RenderBattle();
                break;
        }
        i = 0;
        while (transition.transform.position.x > -1500 * (Screen.width / 1920f))
        {
            transition.transform.position = new Vector3(975 * (Screen.width / 1920f) - .2f * Mathf.Pow(i, 2) * (Screen.width / 1920f), transition.transform.position.y, transition.transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        isMoving = false;
    }
    public void RenderWar()
    {
        foreach (GameObject element in goblinUI)
            element.SetActive(false);
        foreach (GameObject element in battleUI)
            element.SetActive(false);
        foreach (GameObject element in warUI)
            element.transform.position -= new Vector3(10000, 0, 0);
        goblinCounterTexts.SetActive(true);
        pauseScreen.SetActive(false);
        victoryButton.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.goblinConstant.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.orcConstant.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.wizardConstant.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.trollConstant.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.catapultConstant.gameObject.SetActive(false);

        GameManager.instance.battleSimulation.enemyConstant.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.enemyWizardConstant.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.enemyCatapultConstant.gameObject.SetActive(false);

        GameManager.instance.battleSimulation.goblinArrows.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.goblinFireballs.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.goblinPults.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.enemyArrows.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.enemyFireballs.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.enemyPults.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.smokeCloudParticles.gameObject.SetActive(false);
        GameManager.instance.battleSimulation.mainCamera.backgroundColor = new Color(136f / 256, 142f / 256, 91f / 256);
    }
    public void RenderGoblin()
    {
        foreach (GameObject element in warUI)
            element.transform.position += new Vector3(10000, 0, 0);
        foreach (GameObject element in battleUI)
            element.SetActive(false);
        foreach (GameObject element in goblinUI)
            element.SetActive(true);
        goblinCounterTexts.SetActive(true);
    }
    public void RenderBattle()
    {
        foreach (GameObject element in warUI)
            element.transform.position += new Vector3(10000, 0, 0);
        foreach (GameObject element in goblinUI)
            element.SetActive(false);
        foreach (GameObject element in battleUI)
            element.SetActive(true);
        goblinCounterTexts.SetActive(false);
        GameManager.instance.battleSimulation.RenderBattle();
    }
    public void x10(GameObject button)
    {
        GameManager.multiplier *= 10;
        Destroy(button.gameObject);
    }
    private void Start()
    {
        StartCoroutine(waitStart());
    }
    IEnumerator waitStart()
    {
        foreach (GameObject element in warUI)
            element.SetActive(true);
        yield return new WaitForSeconds(.02f);
        RenderGoblin();
    }
}
