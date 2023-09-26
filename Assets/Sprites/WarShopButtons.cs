using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarShopButtons : MonoBehaviour
{
    [Header("Text Objects")]
    public Text swordUpgradePrice;
    public Text armorUpgradePrice;
    public Text orcUpgradePrice;
    public Text wizardUpgradePrice;
    public Text trollUpgradePrice;
    public Text catapultUpgradePrice;
    public Text orcBuyPrice;
    public Text wizardBuyPrice;
    public Text trollBuyPrice;
    public Text catapultBuyPrice;

    [Header("Banners")]
    public GameObject swordBanner;
    public GameObject armorBanner;
    public GameObject orcBanner;
    public GameObject wizardBanner;
    public GameObject trollBanner;
    public GameObject catapultBanner;
    public Sprite swordBannerImage;
    public Sprite armorBannerImage;
    public Sprite orcBannerImage;
    public Sprite wizardBannerImage;
    public Sprite trollBannerImage;
    public Sprite catapultBannerImage;

    [Header("Buttons")]
    public GameObject orcButton;
    public GameObject wizardButton;
    public GameObject trollButton;
    public GameObject catapultButton;
    public Image orcRecruitButton;
    public Image wizardRecruitButton;
    public Image trollRecruitButton;
    public Image catapultRecruitButton;
    public Sprite orcUpgradeButton;
    public Sprite wizardUpgradeButton;
    public Sprite trollUpgradeButton;
    public Sprite catapultUpgradeButton;

    [Header("Button Number Images")]
    public Sprite plus1;
    public Sprite plus10;
    public Sprite plus100;
    public Sprite plus1000;
    public Sprite plus10000;
    public Sprite plus100000;

    [Header("Upgrade Prices")]
    public int swordValue;
    public int armorValue;
    public int orcValue;
    public int wizardValue;
    public int trollValue;
    public int catapultValue;

    [Header("Buy Prices")]
    public int orcPrice;
    public int wizardPrice;
    public int trollPrice;
    public int catapultPrice;

    [Header("Totem Unlocks on the Map")]
    public int swordUnlocksNeeded = 0;
    public int armorUnlocksNeeded = 0;
    public int orcUnlocksNeeded = 0;
    public int wizardUnlocksNeeded = 0;
    public int trollUnlocksNeeded = 0;
    public int catapultUnlocksNeeded = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (swordValue == 0)
            swordValue = 500000;
        if (armorValue == 0)
            armorValue = 500000;
        if (orcValue == 0)
            orcValue = 1500000;
        if (wizardValue == 0)
            wizardValue = 5000000;
        if (trollValue == 0)
            trollValue = 10000000;
        if (catapultValue == 0)
            catapultValue = 200000000;

        if (orcPrice == 0)
            orcPrice = 5000;
        if (wizardPrice == 0)
            wizardPrice = 15000;
        if (trollPrice == 0)
            trollPrice = 50000;
        if (catapultPrice == 0)
            catapultPrice = 50000;

        orcButton.GetComponent<Button>().interactable = false;
        wizardButton.GetComponent<Button>().interactable = false;
        trollButton.GetComponent<Button>().interactable = false;
        catapultButton.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.velengard == 0)
        {
            swordBanner.GetComponent<Image>().sprite = swordBannerImage;
            if (swordUnlocksNeeded <= GameManager.instance.swordUnlocks || swordValue == 69)
            {
                swordBanner.SetActive(false);
                if (swordValue != 69)
                    swordUpgradePrice.text = "$" + ((int)(swordValue / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                else
                    swordUpgradePrice.text = "MAX";
                if (GameManager.goblins >= ((int)(swordValue / 100f * (100 - GameManager.warDiscount))))
                    swordUpgradePrice.color = Color.green;
                else
                    swordUpgradePrice.color = Color.red;
            }
            else
            {
                swordUpgradePrice.color = Color.white;
                swordBanner.SetActive(true);
                swordUpgradePrice.text = "Conquer a        ";
            }
        }

        if (GameManager.instance.nakimata == 0)
        {
            armorBanner.GetComponent<Image>().sprite = armorBannerImage;
            if (armorUnlocksNeeded <= GameManager.instance.armorUnlocks || armorValue == 69)
            {
                armorBanner.SetActive(false);
                if (armorValue != 69)
                    armorUpgradePrice.text = "$" + ((int)(armorValue / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                else
                    armorUpgradePrice.text = "MAX";
                if (GameManager.goblins >= ((int)(armorValue / 100f * (100 - GameManager.warDiscount))))
                    armorUpgradePrice.color = Color.green;
                else
                    armorUpgradePrice.color = Color.red;
            }
            else
            {
                armorUpgradePrice.color = Color.white;
                armorBanner.SetActive(true);
                armorUpgradePrice.text = "Conquer a        ";
            }
        }

        if (GameManager.instance.astinor == 0)
        {
            orcBanner.GetComponent<Image>().sprite = orcBannerImage;
            if (orcUnlocksNeeded <= GameManager.instance.orcUnlocks || orcValue == 69)
            {
                orcBanner.SetActive(false);
                if (orcValue != 69)
                    orcUpgradePrice.text = "$" + ((int)(orcValue / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                else
                    orcUpgradePrice.text = "MAX";
                if (GameManager.goblins >= ((int)(orcValue / 100f * (100 - GameManager.warDiscount))))
                    orcUpgradePrice.color = Color.green;
                else
                    orcUpgradePrice.color = Color.red;
            }
            else
            {
                orcUpgradePrice.color = Color.white;
                orcBanner.SetActive(true);
                orcUpgradePrice.text = "Conquer a        ";
            }
            if (GameManager.instance.orcUpgradeCount > 0)
            {
                orcBuyPrice.text = "$" + ((int)(orcPrice / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                if (GameManager.goblins >= ((int)(orcPrice / 100f * (100 - GameManager.warDiscount))))
                    orcBuyPrice.color = Color.green;
                else
                    orcBuyPrice.color = Color.red;
            }
        }

        if (GameManager.instance.sarshiya == 0)
        {
            wizardBanner.GetComponent<Image>().sprite = wizardBannerImage;
            if (wizardUnlocksNeeded <= GameManager.instance.wizardUnlocks || wizardValue == 69)
            {
                wizardBanner.SetActive(false);
                if (wizardValue != 69)
                    wizardUpgradePrice.text = "$" + ((int)(wizardValue / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                else
                    wizardUpgradePrice.text = "MAX";
                if (GameManager.goblins >= ((int)(wizardValue / 100f * (100 - GameManager.warDiscount))))
                    wizardUpgradePrice.color = Color.green;
                else
                    wizardUpgradePrice.color = Color.red;
            }
            else
            {
                wizardUpgradePrice.color = Color.white;
                wizardBanner.SetActive(true);
                wizardUpgradePrice.text = "Conquer a        ";
            }
            if (GameManager.instance.wizardUpgradeCount > 0)
            {
                wizardBuyPrice.text = "$" + ((int)(wizardPrice / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                if (GameManager.goblins >= ((int)(wizardPrice / 100f * (100 - GameManager.warDiscount))))
                    wizardBuyPrice.color = Color.green;
                else
                    wizardBuyPrice.color = Color.red;
            }
        }

        if (GameManager.instance.izinor == 0)
        {
            trollBanner.GetComponent<Image>().sprite = trollBannerImage;
            if (trollUnlocksNeeded <= GameManager.instance.trollUnlocks || trollValue == 69)
            {
                trollBanner.SetActive(false);
                if (trollValue != 69)
                    trollUpgradePrice.text = "$" + ((int)(trollValue / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                else
                    trollUpgradePrice.text = "MAX";
                if (GameManager.goblins >= ((int)(trollValue / 100f * (100 - GameManager.warDiscount))))
                    trollUpgradePrice.color = Color.green;
                else
                    trollUpgradePrice.color = Color.red;
            }
            else
            {
                trollUpgradePrice.color = Color.white;
                trollBanner.SetActive(true);
                trollUpgradePrice.text = "Conquer a        ";
            }
            if (GameManager.instance.trollUpgradeCount > 0)
            {
                trollBuyPrice.text = "$" + ((int)(trollPrice / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                if (GameManager.goblins >= ((int)(trollPrice / 100f * (100 - GameManager.warDiscount))))
                    trollBuyPrice.color = Color.green;
                else
                    trollBuyPrice.color = Color.red;
            }
        }

        if (GameManager.instance.ivoroth == 0)
        {
            catapultBanner.GetComponent<Image>().sprite = catapultBannerImage;
            if (catapultUnlocksNeeded <= GameManager.instance.catapultUnlocks || catapultValue == 69)
            {
                catapultBanner.SetActive(false);
                if (catapultValue != 69)
                    catapultUpgradePrice.text = "$" + ((int)(catapultValue / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                else
                    catapultUpgradePrice.text = "MAX";
                if (GameManager.goblins >= ((int)(catapultValue / 100f * (100 - GameManager.warDiscount))))
                    catapultUpgradePrice.color = Color.green;
                else
                    catapultUpgradePrice.color = Color.red;
            }
            else
            {
                catapultUpgradePrice.color = Color.white;
                catapultBanner.SetActive(true);
                catapultUpgradePrice.text = "Conquer a        ";
            }
            if (GameManager.instance.catapultUpgradeCount > 0)
            {
                catapultBuyPrice.text = "$" + ((int)(catapultPrice / 100f * (100 - GameManager.warDiscount))).ToString("n0");
                if (GameManager.goblins >= ((int)(catapultPrice / 100f * (100 - GameManager.warDiscount))))
                    catapultBuyPrice.color = Color.green;
                else
                    catapultBuyPrice.color = Color.red;
            }
        }
    }

    public void swordPressed()
    {
        if (GameManager.goblins >= ((int)(swordValue / 100f * (100 - GameManager.warDiscount))) && swordValue != 69 && swordUnlocksNeeded <= GameManager.instance.swordUnlocks)
        {
            GameManager.instance.swordUpgradeCount++;
            swordUnlocksNeeded++;
            GameManager.goblins -= ((int)(swordValue / 100f * (100 - GameManager.warDiscount)));
            switch (swordValue)
            {
                case 500000:
                    swordValue = 1250000;                    
                    break;
                case 1250000:
                    swordValue = 3000000;
                    break;
                case 3000000:
                    swordValue = 8000000;
                    break;
                case 8000000:
                    swordValue = 300000000;
                    break;
                case 300000000:
                    swordValue = 69;
                    break;
            }
        }
    }

    public void armorPressed()
    {
        if (GameManager.goblins >= ((int)(armorValue / 100f * (100 - GameManager.warDiscount))) && armorValue != 69 && armorUnlocksNeeded <= GameManager.instance.armorUnlocks)
        {
            GameManager.instance.armorUpgradeCount++;
            armorUnlocksNeeded++;
            GameManager.goblins -= ((int)(armorValue / 100f * (100 - GameManager.warDiscount)));
            switch (armorValue)
            {
                case 500000:
                    armorValue = 1500000;
                    GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinArmor1.texture;
                    break;
                case 1500000:
                    armorValue = 4000000;
                    GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinArmor2.texture;
                    break;
                case 4000000:
                    armorValue = 100000000;
                    GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinArmor3.texture;
                    break;
                case 100000000:
                    armorValue = 700000000;
                    GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinArmor4.texture;
                    break;
                case 700000000:
                    armorValue = 69;
                    GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinArmor5.texture;
                    break;
            }
        }
    }

    public void orcPressed()
    {
        if (GameManager.goblins >= ((int)(orcValue / 100f * (100 - GameManager.warDiscount))) && orcValue != 69 && orcUnlocksNeeded <= GameManager.instance.orcUnlocks)
        {
            GameManager.instance.orcUpgradeCount++;
            orcUnlocksNeeded++;
            GameManager.goblins -= ((int)(orcValue / 100f * (100 - GameManager.warDiscount)));
            switch (orcValue)
            {
                case 1500000:
                    orcValue = 2500000;
                    orcRecruitButton.GetComponent<Image>().sprite = orcUpgradeButton;
                    orcButton.GetComponent<Button>().interactable = true;
                    break;
                case 2500000:
                    orcValue = 8000000;
                    orcPrice = 8000;
                    GameManager.instance.orcParticles.mainTexture = GameManager.instance.orcArmor2.texture;
                    break;
                case 8000000:
                    orcValue = 50000000;
                    orcButton.GetComponent<Image>().sprite = plus10000;
                    orcPrice = 100000;
                    GameManager.instance.orcParticles.mainTexture = GameManager.instance.orcArmor3.texture;
                    break;
                case 50000000:
                    orcValue = 500000000;
                    orcPrice = 200000;
                    GameManager.instance.orcParticles.mainTexture = GameManager.instance.orcArmor4.texture;
                    break;
                case 250000000:
                    orcValue = 69;
                    orcPrice = 4000000;
                    orcButton.GetComponent<Image>().sprite = plus100000;
                    GameManager.instance.orcParticles.mainTexture = GameManager.instance.orcArmor5.texture;
                    break;
            }
        }
    }

    public void wizardPressed()
    {
        if (GameManager.goblins >= ((int)(wizardValue / 100f * (100 - GameManager.warDiscount))) && wizardValue != 69 && wizardUnlocksNeeded <= GameManager.instance.wizardUnlocks)
        {
            GameManager.instance.wizardUpgradeCount++;
            wizardUnlocksNeeded++;
            GameManager.goblins -= ((int)(wizardValue / 100f * (100 - GameManager.warDiscount)));
            switch (wizardValue)
            {
                case 5000000:
                    wizardValue = 15000000;
                    wizardRecruitButton.GetComponent<Image>().sprite = wizardUpgradeButton;
                    wizardButton.GetComponent<Button>().interactable = true;
                    break;
                case 15000000:
                    wizardValue = 100000000;
                    wizardPrice = 30000;
                    GameManager.instance.wizardParticles.mainTexture = GameManager.instance.wizardArmor2.texture;
                    break;
                case 100000000:
                    wizardValue = 300000000;
                    wizardButton.GetComponent<Image>().sprite = plus1000;
                    GameManager.instance.wizardParticles.mainTexture = GameManager.instance.wizardArmor3.texture;
                    wizardPrice = 500000;
                    break;
                case 300000000:
                    wizardValue = 500000000;
                    wizardPrice = 7500000;
                    GameManager.instance.wizardParticles.mainTexture = GameManager.instance.wizardArmor4.texture;
                    break;
                case 500000000:
                    wizardValue = 69;
                    wizardPrice = 20000000;
                    wizardButton.GetComponent<Image>().sprite = plus10000;
                    GameManager.instance.wizardParticles.mainTexture = GameManager.instance.wizardArmor5.texture;
                    break;
            }
        }
    }

    public void trollPressed()
    {
        if (GameManager.goblins >= ((int)(trollValue / 100f * (100 - GameManager.warDiscount))) && trollValue != 69 && trollUnlocksNeeded <= GameManager.instance.trollUnlocks)
        {
            GameManager.instance.trollUpgradeCount++;
            trollUnlocksNeeded++;
            GameManager.goblins -= ((int)(trollValue / 100f * (100 - GameManager.warDiscount)));
            switch (trollValue)
            {
                case 10000000:
                    trollValue = 35000000;
                    trollRecruitButton.GetComponent<Image>().sprite = trollUpgradeButton;
                    trollButton.GetComponent<Button>().interactable = true;
                    break;
                case 35000000:
                    trollValue = 85000000;
                    trollButton.GetComponent<Image>().sprite = plus100;
                    trollPrice = 750000;
                    GameManager.instance.trollParticles.mainTexture = GameManager.instance.trollArmor2.texture;
                    break;
                case 85000000:
                    trollValue = 69;
                    trollPrice = 10000000;
                    trollButton.GetComponent<Image>().sprite = plus1000;
                    GameManager.instance.trollParticles.mainTexture = GameManager.instance.trollArmor3.texture;
                    break;
            }
        }
    }

    public void catapultPressed()
    {
        if (GameManager.goblins >= ((int)(catapultValue / 100f * (100 - GameManager.warDiscount))) && catapultValue != 69 && catapultUnlocksNeeded <= GameManager.instance.catapultUnlocks)
        {
            GameManager.instance.catapultUpgradeCount++;
            catapultUnlocksNeeded++;
            GameManager.goblins -= ((int)(catapultValue / 100f * (100 - GameManager.warDiscount)));
            switch (catapultValue)
            {
                case 200000000:
                    catapultValue = 450000000;
                    catapultRecruitButton.GetComponent<Image>().sprite = catapultUpgradeButton;
                    catapultButton.GetComponent<Button>().interactable = true;
                    break;
                case 450000000:
                    catapultValue = 800000000;
                    catapultButton.GetComponent<Image>().sprite = plus10;
                    catapultPrice = 750000;
                    GameManager.instance.catapultParticles.mainTexture = GameManager.instance.catapultArmor2.texture;
                    break;
                case 800000000:
                    catapultValue = 69;
                    catapultPrice = 10000000;
                    catapultButton.GetComponent<Image>().sprite = plus100;
                    GameManager.instance.catapultParticles.mainTexture = GameManager.instance.catapultArmor3.texture;
                    break;
            }
        }
    }



    public void orcBuy()
    {
        if (GameManager.goblins >= ((int)(orcPrice / 100f * (100 - GameManager.warDiscount))))
        {
            GameManager.goblins -= ((int)(orcPrice / 100f * (100 - GameManager.warDiscount)));
            switch (orcButton.GetComponent<Image>().sprite.name)
            {
                case "+1":
                    GameManager.instance.orcArmyCount += 1;
                    StartCoroutine(OrcPlay(1));
                    break;
                case "+10":
                    GameManager.instance.orcArmyCount += 10;
                    StartCoroutine(OrcPlay(10));
                    break;
                case "+100":
                    GameManager.instance.orcArmyCount += 100;
                    StartCoroutine(OrcPlay(100));
                    break;
                case "+1000":
                    GameManager.instance.orcArmyCount += 1000;
                    StartCoroutine(OrcPlay(1000));
                    break;
                case "+10000":
                    GameManager.instance.orcArmyCount += 10000;
                    StartCoroutine(OrcPlay(10000));
                    break;
                case "+100000":
                    GameManager.instance.orcArmyCount += 100000;
                    StartCoroutine(OrcPlay(100000));
                    break;
            }
        }
    }
    IEnumerator OrcPlay(int k)
    {
        int count = 100;
        if (k <= 100)
            count = k;
        for (int i = 0; i < count; i++)
        {
            GameManager.instance.orcParticleSystem.Emit(1);
            yield return new WaitForSeconds(.005f);
        }
    }

    public void wizardBuy()
    {
        if (GameManager.goblins >= ((int)(wizardPrice / 100f * (100 - GameManager.warDiscount))))
        {
            GameManager.goblins -= ((int)(wizardPrice / 100f * (100 - GameManager.warDiscount)));
            switch (wizardButton.GetComponent<Image>().sprite.name)
            {
                case "+1":
                    GameManager.instance.wizardArmyCount += 1;
                    StartCoroutine(WizardPlay(1));
                    break;
                case "+10":
                    GameManager.instance.wizardArmyCount += 10;
                    StartCoroutine(WizardPlay(10));
                    break;
                case "+100":
                    GameManager.instance.wizardArmyCount += 100;
                    StartCoroutine(WizardPlay(100));
                    break;
                case "+1000":
                    GameManager.instance.wizardArmyCount += 1000;
                    StartCoroutine(WizardPlay(1000));
                    break;
                case "+10000":
                    GameManager.instance.wizardArmyCount += 10000;
                    StartCoroutine(WizardPlay(10000));
                    break;
                case "+100000":
                    GameManager.instance.wizardArmyCount += 100000;
                    StartCoroutine(WizardPlay(100000));
                    break;
            }
        }
    }
    IEnumerator WizardPlay(int k)
    {
        int count = 100;
        if (k <= 100)
            count = k;
        for (int i = 0; i < count; i++)
        {
            GameManager.instance.wizardParticleSystem.Emit(1);
            yield return new WaitForSeconds(.005f);
        }
    }

    public void trollBuy()
    {
        if (GameManager.goblins >= ((int)(trollPrice / 100f * (100 - GameManager.warDiscount))))
        {
            GameManager.goblins -= ((int)(trollPrice / 100f * (100 - GameManager.warDiscount)));
            switch (trollButton.GetComponent<Image>().sprite.name)
            {
                case "+1":
                    GameManager.instance.trollArmyCount += 1;
                    StartCoroutine(TrollPlay(1));
                    break;
                case "+10":
                    GameManager.instance.trollArmyCount += 10;
                    StartCoroutine(TrollPlay(10));
                    break;
                case "+100":
                    GameManager.instance.trollArmyCount += 100;
                    StartCoroutine(TrollPlay(100));
                    break;
                case "+1000":
                    GameManager.instance.trollArmyCount += 1000;
                    StartCoroutine(TrollPlay(1000));
                    break;
                case "+10000":
                    GameManager.instance.trollArmyCount += 10000;
                    StartCoroutine(TrollPlay(10000));
                    break;
                case "+100000":
                    GameManager.instance.trollArmyCount += 100000;
                    StartCoroutine(TrollPlay(100000));
                    break;
            }
        }
    }
    IEnumerator TrollPlay(int k)
    {
        int count = 100;
        if (k <= 100)
            count = k;
        for (int i = 0; i < count; i++)
        {
            GameManager.instance.trollParticleSystem.Emit(1);
            yield return new WaitForSeconds(.005f);
        }
    }

    public void catapultBuy()
    {
        if (GameManager.goblins >= ((int)(catapultPrice / 100f * (100 - GameManager.warDiscount))))
        {
            GameManager.goblins -= ((int)(catapultPrice / 100f * (100 - GameManager.warDiscount)));
            switch (catapultButton.GetComponent<Image>().sprite.name)
            {
                case "+1":
                    GameManager.instance.catapultArmyCount += 1;
                    StartCoroutine(CatapultPlay(1));
                    break;
                case "+10":
                    GameManager.instance.catapultArmyCount += 10;
                    StartCoroutine(CatapultPlay(10));
                    break;
                case "+100":
                    GameManager.instance.catapultArmyCount += 100;
                    StartCoroutine(CatapultPlay(100));
                    break;
                case "+1000":
                    GameManager.instance.catapultArmyCount += 1000;
                    StartCoroutine(CatapultPlay(1000));
                    break;
                case "+10000":
                    GameManager.instance.catapultArmyCount += 10000;
                    StartCoroutine(CatapultPlay(10000));
                    break;
                case "+100000":
                    GameManager.instance.catapultArmyCount += 100000;
                    StartCoroutine(CatapultPlay(100000));
                    break;
            }
        }
    }
    IEnumerator CatapultPlay(int k)
    {
        int count = 100;
        if (k <= 100)
            count = k;
        for (int i = 0; i < count; i++)
        {
            GameManager.instance.catapultParticleSystem.Emit(1);
            yield return new WaitForSeconds(.005f);
        }
    }
}
