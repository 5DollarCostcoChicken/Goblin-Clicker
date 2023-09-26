using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConquerButton : MonoBehaviour
{
    public Text location;
    public Text priceText;
    public int price;
    Button[] unlockables;
    public GameObject adversary;
    Sprite demise;
    public Image currentButton;
    public BattleButton currentTerritory;
    public WarShop warShop;
    int reward;
    public GameObject idolWarButton;
    public GameObject idolElixirButton;
    public GameObject idolSorceryButton;
    public GameObject idolMudButton;
    public GameObject idolDestructionButton;
    public GameObject idolCreationButton;
    GameObject Banner;
    public bool moving = false;
    public Game game;
    // Start is called before the first frame update
    void Start()
    {
        price = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = "\u265F" + ((int)(price)).ToString("n0");
        /*
        if (GameManager.goblins > ((int)(price)))
        {
            priceText.color = Color.green;
        }
        else
        {
            priceText.color = Color.red;
        }
        */
    }
    public void Display(int p, string l, Button[] unlocks, Sprite a1, Sprite a2, Image b, int r, GameObject banner, BattleButton territory)
    {
        price = p;
        location.text = l;
        adversary.GetComponent<Image>().sprite = a1;
        demise = a2;
        unlockables = unlocks;
        currentButton = b;
        GetComponent<Button>().interactable = true;
        GetComponent<Image>().enabled = true;
        priceText.enabled = true;
        reward = r;
        Banner = banner;
        currentTerritory = territory;
    }
    public void Battle()
    {
        if (!game.isMoving)
        {
            game.Transition("battle");
            GameManager.instance.battleSimulation.Establish(currentButton, Banner, adversary.GetComponent<Image>().sprite, price, currentTerritory);
        }
    }
    public void Conquer()
    {
        if (true)
        {
            foreach (Button button in unlockables)
            {
                button.interactable = true;
                button.GetComponent<BattleButton>().banner.GetComponent<Image>().color = Color.white;
                if (button.GetComponent<BattleButton>().icon != null)
                    button.GetComponent<BattleButton>().icon.color = Color.white;
            }
            if (currentButton.GetComponent<BattleButton>().bought != true)
                GameManager.victories++;
            currentButton.color = Color.white;
            currentButton.GetComponent<BattleButton>().bought = true;
            GameManager.warNamesConquered.Add(currentButton.name);
            //GameManager.goblins -= ((int)(price));
            StartCoroutine(WarBounce());
            GameManager.autoGoblins += reward;
            switch (currentButton.name.Substring(8, 2))
            {
                case "2)":
                    idolWarButton.SetActive(true);
                    GameManager.instance.warShopButton.SetActive(true);
                    break;
                case "24":
                    idolWarButton.SetActive(true);
                    GameManager.instance.warShopButton.SetActive(true);
                    break;
                case "8)":
                    idolElixirButton.SetActive(true);
                    break;
                case "23":
                    idolSorceryButton.SetActive(true);
                    break;
                case "34":
                    idolMudButton.SetActive(true);
                    break;

                case "17":
                    GameManager.instance.armorUnlocks++;
                    break;
                case "18":
                    GameManager.instance.orcUnlocks++;
                    break;
                case "21":
                    GameManager.instance.swordUnlocks++;
                    break;
                case "25":
                    GameManager.instance.armorUnlocks++;
                    break;
                case "27":
                    GameManager.instance.swordUnlocks++;
                    break;
                case "31":
                    GameManager.instance.swordUnlocks++;
                    break;
                case "32":
                    GameManager.instance.orcUnlocks++;
                    break;
                case "33":
                    GameManager.instance.wizardUnlocks++;
                    break;
                case "38":
                    GameManager.instance.orcUnlocks++;
                    break;
                case "39":
                    GameManager.instance.trollUnlocks++;
                    break;
                case "41":
                    GameManager.instance.wizardUnlocks++;
                    break;
                case "51":
                    GameManager.instance.catapultUnlocks++;
                    break;
                case "53":
                    GameManager.instance.trollUnlocks++;
                    break;
                case "54":
                    GameManager.instance.armorUnlocks++;
                    break;
                case "55":
                    GameManager.instance.wizardUnlocks++;
                    break;
                case "57":
                    GameManager.instance.swordUnlocks++;
                    break;
                case "59":
                    GameManager.instance.orcUnlocks++;
                    break;
                case "61":
                    GameManager.instance.wizardUnlocks++;
                    break;
                case "62":
                    GameManager.instance.armorUnlocks++;
                    break;
                case "63":
                    GameManager.instance.catapultUnlocks++;
                    break;
            }
            if (GameManager.victories == 62)
            {
                idolDestructionButton.SetActive(true);
                idolCreationButton.SetActive(true);
            }

            switch (Banner.GetComponent<Image>().sprite.name)
            {
                case "VelengardBanner":
                    GameManager.instance.velengard--;
                    break;
                case "4HousesBanner":
                    GameManager.instance.nakimata--;
                    break;
                case "AstinorBanner":
                    GameManager.instance.astinor--;
                    break;
                case "SarshiyaBanner":
                    GameManager.instance.sarshiya--;
                    break;
                case "IzinorBanner":
                    GameManager.instance.izinor--;
                    break;
                case "IvorothBanner":
                    GameManager.instance.ivoroth--;
                    break;
            }
            Banner.GetComponent<Image>().sprite = GameManager.instance.goblinBanner;
        }
    }
    IEnumerator WarBounce()
    {
        moving = true;
        int i = 0;
        /*
        while (warShop.transform.localPosition.x < 1630)
        {
            warShop.transform.localPosition = new Vector3(.4f * Mathf.Pow(i, 2), warShop.transform.localPosition.y, warShop.transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        */
        warShop.transform.localPosition = new Vector3(1630, warShop.transform.localPosition.z);
        yield return new WaitForSeconds(1.2f);
        warShop.transform.localPosition = new Vector3(1630, warShop.transform.localPosition.z);
        GetComponent<Button>().interactable = false;
        GetComponent<Image>().enabled = false;
        priceText.enabled = false;
        adversary.GetComponent<Image>().sprite = demise;
        location.text = "\n\nRewards:\n\nG.P.S: +" + reward.ToString("n0");
        switch (currentButton.name.Substring(8, 2))
        {
            case "8)":
                location.text += ",\nIdol of Elixir";
                break;
            case "23":
                location.text += ",\nIdol of Sorcery";
                break;
            case "34":
                location.text += ",\nIdol of Mire";
                break;
        }
        if (GameManager.victories == 1)
        {
            location.text += ",\nIdol of War";
            location.text += ",\nWar Shop";
        }
        if (GameManager.victories == 62)
        {
            location.text += ",\nIdol of Destruction";
            location.text += ",\nIdol of Creation";
        }
        i = 0;
        while (warShop.transform.localPosition.x > 0)
        {
            warShop.transform.localPosition = new Vector3(1630 - .4f * Mathf.Pow(i, 2), warShop.transform.localPosition.y, warShop.transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (warShop.transform.localPosition.x < 70)
        {
            warShop.transform.localPosition = new Vector3(3f * i + .8f * Mathf.Pow(i, 1.5f), warShop.transform.localPosition.y, warShop.transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (warShop.transform.localPosition.x > 0)
        {
            warShop.transform.localPosition = new Vector3(105 - .4f * Mathf.Pow(i, 2), warShop.transform.localPosition.y, warShop.transform.localPosition.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        moving = false;
    }
}
