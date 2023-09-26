using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleSimulation : MonoBehaviour
{
    [Header("Patches")]
    public SpriteRenderer[] patches;
    public Image currentButtonImage;
    public BattleButton currentTerritory;
    public Camera mainCamera;
    public Image victoryButton;
    public Sprite victory;
    public Sprite defeat;
    public GameObject pauseScreen;
    //
    GameObject Banner;
    Sprite AdversarySprite;
    double totalArmyCount;
    double enemyArmyCount;
    public float clicksModifier = 0;
    int clicksPerSecond;
    [Header("Ceilings")]
    public SpriteRenderer ceiling;
    public Sprite ceilingSand;
    public Sprite ceilingForest;
    public Sprite ceilingRiver;
    public Sprite ceilingIcy;
    public Sprite ceilingGrassyMountain;
    public Sprite ceilingAesindel;
    public Sprite ceilingEnchantedForest;
    public Sprite ceilingRottenForest;
    public Sprite ceilingLavamountains;
    public Sprite ceilingRockyMountain;
    public Sprite ceilingCrystalMountain;
    [Header("Bar")]
    public Image adversaryImage;
    public GameObject warBarBlue;
    public GameObject warBarRed;
    public GameObject swordClash;
    public Image number3;
    public Image number2;
    public Image number1;
    public Image spam;
    public Button fightButton;

    [Header("Castles")]
    public Image castle;
    public Image castleAdversary;
    public Image castleBanner1;
    public Image castleBanner2;
    public Image castleIdol;

    public Sprite idolSuperion;
    public Sprite idolPlagueDoctor;
    public Sprite idolNecromancer;
    public Sprite idolVirion;
    public Sprite idolGodslayer;

    public Sprite castleGoblinFort; 
    public Sprite castleVikings;
    public Sprite castleSamurai;
    public Sprite castleAstinor;
    public Sprite castleMountaintop;
    public Sprite castleEvos;
    public Sprite castleNezeroth;
    public Sprite castleRottenFort;
    public Sprite castleIvoroth;
    public Sprite castleWorldTree;
    public Sprite castleNilvenora;
    public Sprite castleSarshiya;
    public Sprite castleIrindel;
    public Sprite castleAellion;
    public Sprite castleFrontier;
    public Sprite castleArcaneAcademy;
    public Sprite castleCrystalMountain;
    public Sprite castleHomeDefense;

    [Header("ArmyNumbers")]
    public Sprite buffed;
    public Sprite debuffed;
    public Sprite nuthin;
    public Image goblinBuffed;
    public Image orcBuffed;
    public Image wizardBuffed;
    public Image trollBuffed;
    public Image catapultBuffed;
    public TextMeshProUGUI goblinText;
    public TextMeshProUGUI orcText;
    public TextMeshProUGUI wizardText;
    public TextMeshProUGUI trollText;
    public TextMeshProUGUI catapultText;
    public Text goblinArmyText;
    public Text enemyArmyText;
    public void Establish(Image b, GameObject banner, Sprite adversary, int armyCount, BattleButton territory)
    {
        currentButtonImage = b;
        Banner = banner;
        AdversarySprite = adversary;
        enemyArmyCount = armyCount;
        currentTerritory = territory;
    }

    [Header("ArmyStats")]
    public double totalGoblinArmyPower;
    public double totalEnemyArmyPower;
    public float goblinPowerModifier;
    public float orcPowerModifier;
    public float wizardPowerModifier;
    public float trollPowerModifier;
    public float catapultPowerModifier;
    float battlespeed = 1;
    float battleDifficulty = 1;
    double autoGoblins;
    public void RenderBattle()
    {
        goblinPowerModifier = 1;
        goblinBuffed.sprite = nuthin;
        orcPowerModifier = 1;
        orcBuffed.sprite = nuthin;
        wizardPowerModifier = 1;
        wizardBuffed.sprite = nuthin;
        trollPowerModifier = 1;
        trollBuffed.sprite = nuthin;
        catapultPowerModifier = 1;
        catapultBuffed.sprite = nuthin;

        fightButton.interactable = false;
        fightButton.GetComponent<Image>().color = new Color(.7f, .7f, .7f, .7f);

        castleIdol.gameObject.SetActive(false);
        enemyWizards = false;
        enemyCatapults = false;
        GameManager.battleAudioSource.clip = generic;
        switch (currentButtonImage.name.Substring(8, 2))
        {
            //sandy
            case "2)": //Gobby Rivals
                mainCamera.backgroundColor = new Color(203f / 256, 191f / 256, 139f / 256);
                ceiling.sprite = ceilingSand;
                castle.sprite = castleGoblinFort;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinSwords.texture);
                break;
            case "3)": //Cier Goblins
                mainCamera.backgroundColor = new Color(203f / 256, 191f / 256, 139f / 256);
                ceiling.sprite = ceilingSand;
                castle.sprite = castleGoblinFort;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinSwords.texture);
                break;
            case "24": //Kharak-Thel Orcs
                mainCamera.backgroundColor = new Color(203f / 256, 191f / 256, 139f / 256);
                ceiling.sprite = ceilingSand;
                castle.sprite = castleGoblinFort;
                wizardPowerModifier = 0.75f;

                enemySprites.SetTexture("_MainTex", GameManager.instance.orcArmor1.texture);
                break;
            case "26": //Kaniedas Sand
                mainCamera.backgroundColor = new Color(203f / 256, 191f / 256, 139f / 256);
                ceiling.sprite = ceilingSand;
                castle.sprite = castleSarshiya;
                wizardPowerModifier = 0.5f;
                catapultPowerModifier = 1.25f;
                enemyWizards = true;
                battleDifficulty = 1.2f;
                GameManager.battleAudioSource.clip = samuraiTheme;

                enemySprites.SetTexture("_MainTex", GameManager.instance.orcArmor1.texture);
                enemyWizardSprites.SetTexture("_MainTex", GameManager.instance.wizardArmor2.texture);
                break;
            case "27": //Sarka
                mainCamera.backgroundColor = new Color(203f / 256, 191f / 256, 139f / 256);
                ceiling.sprite = ceilingSand;
                castle.sprite = castleSarshiya;
                battleDifficulty = 0.6f;

                enemySprites.SetTexture("_MainTex", GameManager.instance.orcArmor1.texture);
                break;

            //icy
            case "5)": //Wizard Goblin
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleGoblinFort;
                wizardPowerModifier = 0.5f;
                goblinPowerModifier = 1.25f;
                enemyWizards = true;
                battleDifficulty = 0.8f;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinSwords.texture);
                enemyWizardSprites.SetTexture("_MainTex", GameManager.instance.wizardArmor1.texture);
                break;
            case "6)": //Velengard Viking
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleVikings;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", vikings.texture);
                break;
            case "7)": //Revenant Ice
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleVikings;
                enemyWizards = true;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", vikings.texture);
                enemyWizardSprites.SetTexture("_MainTex", humanWizards.texture);
                break;
            case "12": //House Winter
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleSamurai;
                battlespeed = .9f;
                GameManager.battleAudioSource.clip = samuraiTheme;

                enemySprites.SetTexture("_MainTex", samurai.texture);
                break;
            case "17": //Skota
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleVikings;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", vikings.texture);
                break;
            case "31": //Serpent's Pass
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleEvos;
                catapultPowerModifier = 0.25f;
                orcPowerModifier = 1.25f;
                enemyWizards = true;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", GameManager.instance.orcArmor4.texture);
                enemyWizardSprites.SetTexture("_MainTex", GameManager.instance.wizardArmor4.texture);
                break;
            case "32": //Akileuks
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleNezeroth;
                goblinPowerModifier = 0.75f;
                orcPowerModifier = 1.25f;
                enemyWizards = true;
                battleDifficulty = 1.2f;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinArmor5.texture);
                enemyWizardSprites.SetTexture("_MainTex", GameManager.instance.wizardArmor5.texture);
                break;
            case "55": //Ivoroth
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleIvoroth;
                goblinPowerModifier = 0.9f;
                trollPowerModifier = 0.9f;
                wizardPowerModifier = 1.25f;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", elvesIvoroth.texture);
                break;
            case "56": //GILLION
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleIvoroth;
                goblinPowerModifier = 0.9f;
                trollPowerModifier = 0.9f;
                wizardPowerModifier = 1.25f;
                battlespeed = .8f;
                enemyWizards = true;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", elvesIvoroth.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;
            case "57": //Ivoroth Shattered Mountains
                mainCamera.backgroundColor = new Color(219f / 256, 219f / 256, 219f / 256);
                ceiling.sprite = ceilingIcy;
                castle.sprite = castleIvoroth;
                goblinPowerModifier = 0.9f;
                trollPowerModifier = 0.9f;
                wizardPowerModifier = 1.25f;
                battlespeed = .8f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.4f;
                GameManager.battleAudioSource.clip = iceTheme;

                enemySprites.SetTexture("_MainTex", elvesIvoroth.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor2.texture);
                break;

            //forest
            case "8)": //Plague Doctor
                ceiling.sprite = ceilingForest;
                castleIdol.sprite = idolPlagueDoctor;
                castleIdol.gameObject.SetActive(true);
                castle.sprite = castleAstinor;
                goblinPowerModifier = 0.25f;
                orcPowerModifier = 0.25f;
                wizardPowerModifier = 0.25f;
                trollPowerModifier = 0.25f;
                catapultPowerModifier = 1.9f;
                battlespeed = .7f;
                GameManager.battleAudioSource.clip = pyroTheme;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "9)": //Astinor
                ceiling.sprite = ceilingForest;
                castle.sprite = castleAstinor;
                battleDifficulty = 0.6f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "41": //Arcane Academy
                ceiling.sprite = ceilingForest;
                castle.sprite = castleArcaneAcademy;
                wizardPowerModifier = 0.25f;
                goblinPowerModifier = 1.25f;
                enemyWizards = true;
                battleDifficulty = 1.2f;

                enemySprites.SetTexture("_MainTex", humanWizards.texture);
               enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;
            case "42": //Dimwood
                ceiling.sprite = ceilingForest;
                castle.sprite = castleFrontier;
                orcPowerModifier = 1.25f;
                wizardPowerModifier = 1.25f;
                trollPowerModifier = 1.25f;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinArmor1.texture);
                break;
            case "45": //Irindel
                ceiling.sprite = ceilingForest;
                castle.sprite = castleIrindel;
                wizardPowerModifier = 1.1f;
                orcPowerModifier = 1.25f;
                goblinPowerModifier = 0.8f;

                enemySprites.SetTexture("_MainTex", elvesIrindel.texture);
                break;
            case "46": //Aellion
                ceiling.sprite = ceilingForest;
                castle.sprite = castleAellion;
                wizardPowerModifier = 1.1f;
                orcPowerModifier = 1.25f;
                goblinPowerModifier = 0.8f;
                battleDifficulty = 0.8f;

                enemySprites.SetTexture("_MainTex", elvesAellion.texture);
                break;
            case "47": //Aellion
                ceiling.sprite = ceilingForest;
                castle.sprite = castleAellion;
                wizardPowerModifier = 1.1f;
                goblinPowerModifier = 0.8f;
                enemyWizards = true;

                enemySprites.SetTexture("_MainTex", elvesAellion.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;
            case "48": //Aellion
                ceiling.sprite = ceilingForest;
                castle.sprite = castleAellion;
                wizardPowerModifier = 1.1f;
                goblinPowerModifier = 0.8f;
                enemyWizards = true;

                enemySprites.SetTexture("_MainTex", elvesAellion.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;
            case "49": //Irindel
                ceiling.sprite = ceilingForest;
                castle.sprite = castleIrindel;
                wizardPowerModifier = 1.1f;
                goblinPowerModifier = 0.8f;
                trollPowerModifier = 0.25f;
                enemyWizards = true;

                enemySprites.SetTexture("_MainTex", elvesIrindel.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;

            //river
            case "10": //Wolfpack
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleAstinor;
                goblinPowerModifier = 1.1f;
                battleDifficulty = 0.8f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "11": //Resistance
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleAstinor;
                battleDifficulty = 1.1f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "15": //House Sun
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleSamurai;
                battlespeed = .9f;
                GameManager.battleAudioSource.clip = samuraiTheme;

                enemySprites.SetTexture("_MainTex", samurai.texture);
                break;
            case "16": //catteleya
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleAstinor;
                goblinPowerModifier = 0.9f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "18": //Silver Isles
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleSarshiya;
                goblinPowerModifier = 0.5f;
                orcPowerModifier = 1.5f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "19": //ajax dawn
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleAstinor;
                enemyWizards = true;
                battleDifficulty = 1.2f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                enemyWizardSprites.SetTexture("_MainTex", humanWizards.texture);
                break;
            case "20": //astinor
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleAstinor;
                battleDifficulty = 0.7f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "23": //superion
                ceiling.sprite = ceilingRiver;
                castleIdol.sprite = idolSuperion;
                castle.sprite = castleMountaintop;
                castleIdol.gameObject.SetActive(true);
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.4f;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor1.texture);
                break;
            case "39": //frontier
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleFrontier;
                battleDifficulty = 0.5f;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                break;
            case "40": //FENN
                ceiling.sprite = ceilingRiver;
                castle.sprite = castleFrontier;
                enemyWizards = true;
                battleDifficulty = 1.2f;
                GameManager.battleAudioSource.clip = fennTheme;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                enemyWizardSprites.SetTexture("_MainTex", humanWizards.texture);
                break;

            //mountains
            case "13": //House Sparrow
                ceiling.sprite = ceilingGrassyMountain;
                castle.sprite = castleSamurai;
                battlespeed = .9f;
                GameManager.battleAudioSource.clip = samuraiTheme;

                enemySprites.SetTexture("_MainTex", samurai.texture);
                break;
            case "14": //House Rain
                ceiling.sprite = ceilingGrassyMountain;
                castle.sprite = castleSamurai;
                battlespeed = .9f;
                battleDifficulty = 0.8f;
                GameManager.battleAudioSource.clip = samuraiTheme;

                enemySprites.SetTexture("_MainTex", samurai.texture);
                break;
            case "21": //Astoria (GildedGuy)
                ceiling.sprite = ceilingGrassyMountain;
                castle.sprite = castleAstinor;
                goblinPowerModifier = 0.9f;
                enemyCatapults = true;

                enemySprites.SetTexture("_MainTex", humanKnights.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor1.texture);
                break;

            //aesindel
            case "59":
                mainCamera.backgroundColor = new Color(92f / 256, 86f / 256, 78f / 256);
                ceiling.sprite = ceilingAesindel;
                castle.sprite = castleMountaintop;
                goblinPowerModifier = 0.75f;
                wizardPowerModifier = 1.25f;
                trollPowerModifier = 1.25f;
                catapultPowerModifier = 1.25f;
                enemyWizards = true;
                enemyCatapults = true;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor2.texture);
                break;
            case "60":
                mainCamera.backgroundColor = new Color(92f / 256, 86f / 256, 78f / 256);
                ceiling.sprite = ceilingAesindel;
                castle.sprite = castleMountaintop;
                goblinPowerModifier = 0.75f;
                wizardPowerModifier = 1.25f;
                trollPowerModifier = 1.25f;
                catapultPowerModifier = 1.25f;
                enemyWizards = true;
                enemyCatapults = true;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
               enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor2.texture);
                break;
            case "61": //Wraith
                mainCamera.backgroundColor = new Color(92f / 256, 86f / 256, 78f / 256);
                ceiling.sprite = ceilingAesindel;
                castle.sprite = castleMountaintop;
                goblinPowerModifier = 0.75f;
                trollPowerModifier = 1.25f;
                catapultPowerModifier = 1.25f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.1f;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor2.texture);
                break;
            case "62": //Aesthetic
                mainCamera.backgroundColor = new Color(92f / 256, 86f / 256, 78f / 256);
                ceiling.sprite = ceilingAesindel;
                castle.sprite = castleMountaintop;
                goblinPowerModifier = 0.75f;
                trollPowerModifier = 1.25f;
                battlespeed = .9f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.2f;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor2.texture);
                break;
            case "63": //Citadel
                mainCamera.backgroundColor = new Color(92f / 256, 86f / 256, 78f / 256);
                ceiling.sprite = ceilingAesindel;
                castle.sprite = castleMountaintop;
                goblinPowerModifier = 0.5f;
                orcPowerModifier = 0.5f;
                wizardPowerModifier = 1.25f;
                catapultPowerModifier = 1.25f;
                battlespeed = .9f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.6f;
                GameManager.battleAudioSource.clip = pyroTheme;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor3.texture);
                break;

            //enchanted forest
            case "43": //Haze
                mainCamera.backgroundColor = new Color(91f / 256, 142f / 256, 97f / 256);
                ceiling.sprite = ceilingEnchantedForest;
                castle.sprite = castleFrontier;
                battleDifficulty = 0.7f;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinSwords.texture);
                break;
            case "44": //Haze
                mainCamera.backgroundColor = new Color(91f / 256, 142f / 256, 97f / 256);
                ceiling.sprite = ceilingEnchantedForest;
                castle.sprite = castleFrontier;
                orcPowerModifier = 0.75f;
                wizardPowerModifier = 1.25f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.8f;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor1.texture);
                break;
            case "53": //ivoroth
                mainCamera.backgroundColor = new Color(91f / 256, 142f / 256, 97f / 256);
                ceiling.sprite = ceilingEnchantedForest;
                castle.sprite = castleIvoroth;
                orcPowerModifier = 0.75f;
                wizardPowerModifier = 1.25f;

                enemySprites.SetTexture("_MainTex", elvesIvoroth.texture);
                break;
            case "54": //ivoroth
                mainCamera.backgroundColor = new Color(91f / 256, 142f / 256, 97f / 256);
                ceiling.sprite = ceilingEnchantedForest;
                castle.sprite = castleIvoroth;
                enemyWizards = true;

                enemySprites.SetTexture("_MainTex", elvesIvoroth.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;
            case "58": //First Tree
                mainCamera.backgroundColor = new Color(91f / 256, 142f / 256, 97f / 256);
                ceiling.sprite = ceilingEnchantedForest;
                castleIdol.sprite = idolGodslayer;
                //castleIdol.gameObject.SetActive(true);
                castle.sprite = castleWorldTree;
                orcPowerModifier = 0.75f;
                wizardPowerModifier = 0.1f;
                catapultPowerModifier = 1.75f;
                battlespeed = .6f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.8f;
                GameManager.battleAudioSource.clip = godslayerTheme;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor3.texture);
                break;

            //rotten forest
            case "25": //badlands
                mainCamera.backgroundColor = new Color(82f / 256, 63f / 256, 21f / 256);
                ceiling.sprite = ceilingRottenForest;
                castle.sprite = castleEvos;
                orcPowerModifier = 1.5f;

                enemySprites.SetTexture("_MainTex", GameManager.instance.orcArmor4.texture);
                break;
            case "35": //looming marshes
                mainCamera.backgroundColor = new Color(82f / 256, 63f / 256, 21f / 256);
                ceiling.sprite = ceilingRottenForest;
                castle.sprite = castleRottenFort;
                battleDifficulty = 0.8f;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinSwords.texture);
                break;
            case "36": //tempestum
                mainCamera.backgroundColor = new Color(82f / 256, 63f / 256, 21f / 256);
                ceiling.sprite = ceilingRottenForest;
                castle.sprite = castleRottenFort;
                orcPowerModifier = 1.5f;
                enemyWizards = true;
                battleDifficulty = 1.2f;

                enemySprites.SetTexture("_MainTex", elvesAellion.texture);
               enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;
            case "37": //rotten forest
                mainCamera.backgroundColor = new Color(82f / 256, 63f / 256, 21f / 256);
                ceiling.sprite = ceilingRottenForest;
                castle.sprite = castleRottenFort;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinSwords.texture);
                break;
            case "38": //pyrus
                mainCamera.backgroundColor = new Color(82f / 256, 63f / 256, 21f / 256);
                ceiling.sprite = ceilingRottenForest;
                castle.sprite = castleRottenFort;
                orcPowerModifier = 1.5f;
                goblinPowerModifier = 1.5f;
                enemyWizards = true;
                battleDifficulty = 1.2f;
                GameManager.battleAudioSource.clip = lavaTheme;

                enemySprites.SetTexture("_MainTex", elvesNilvenora.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                break;

            //lava mountains
            case "29": //phantom
                mainCamera.backgroundColor = new Color(51f / 256, 41f / 256, 40f / 256);
                ceiling.sprite = ceilingLavamountains;
                castle.sprite = castleMountaintop;
                orcPowerModifier = 1.5f;
                enemyWizards = true;
                battleDifficulty = 1.4f;
                GameManager.battleAudioSource.clip = lavaTheme;

                enemySprites.SetTexture("_MainTex", blackLegion.texture);
                enemyWizardSprites.SetTexture("_MainTex", blackLegionWizards.texture);
                break;
            case "30": //ghosht
                mainCamera.backgroundColor = new Color(51f / 256, 41f / 256, 40f / 256);
                ceiling.sprite = ceilingLavamountains;
                castle.sprite = castleNezeroth;
                enemyWizards = true;
                battleDifficulty = 1.4f;
                GameManager.battleAudioSource.clip = lavaTheme;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinArmor4.texture);
                enemyWizardSprites.SetTexture("_MainTex", GameManager.instance.wizardArmor4.texture);
                break;
            case "34": //necromancer
                mainCamera.backgroundColor = new Color(51f / 256, 41f / 256, 40f / 256);
                ceiling.sprite = ceilingLavamountains;
                castleIdol.sprite = idolNecromancer;
                castleIdol.gameObject.SetActive(true);
                castle.sprite = castleNezeroth;
                orcPowerModifier = .5f;
                battlespeed = .8f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.4f;
                GameManager.battleAudioSource.clip = lavaTheme;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinArmor5.texture);
               enemyWizardSprites.SetTexture("_MainTex", GameManager.instance.wizardArmor5.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor2.texture);
                break;
            case "51": //dark elves
                mainCamera.backgroundColor = new Color(51f / 256, 41f / 256, 40f / 256);
                ceiling.sprite = ceilingLavamountains;
                castle.sprite = castleNilvenora;
                trollPowerModifier = 1.5f;
                catapultPowerModifier = .5f;
                GameManager.battleAudioSource.clip = lavaTheme;

                enemySprites.SetTexture("_MainTex", elvesNilvenora.texture);
                break;
            case "52": //oberaun
                mainCamera.backgroundColor = new Color(51f / 256, 41f / 256, 40f / 256);
                ceiling.sprite = ceilingLavamountains;
                castle.sprite = castleNilvenora;
                trollPowerModifier = 1.5f;
                catapultPowerModifier = .5f;
                battlespeed = .9f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 1.2f;
                GameManager.battleAudioSource.clip = lavaTheme;

                enemySprites.SetTexture("_MainTex", elvesNilvenora.texture);
                enemyWizardSprites.SetTexture("_MainTex", elvenWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor1.texture);
                break;

            //grey rock
            case "4)"://Kharak-Thel Armored Goblins
                mainCamera.backgroundColor = new Color(53f / 256, 53f / 256, 53f / 256);
                ceiling.sprite = ceilingRockyMountain;
                castle.sprite = castleGoblinFort;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinArmor3.texture);
                break;
            case "22": //dormuth
                mainCamera.backgroundColor = new Color(53f / 256, 53f / 256, 53f / 256);
                ceiling.sprite = ceilingRockyMountain;
                castle.sprite = castleNezeroth;

                enemySprites.SetTexture("_MainTex", GameManager.instance.goblinArmor2.texture);
                break;
            case "28": //badlands
                mainCamera.backgroundColor = new Color(53f / 256, 53f / 256, 53f / 256);
                ceiling.sprite = ceilingRockyMountain;
                castle.sprite = castleEvos;
                battleDifficulty = 0.8f;

                enemySprites.SetTexture("_MainTex", GameManager.instance.orcArmor4.texture);
                break;
            case "33": //lord fovos
                mainCamera.backgroundColor = new Color(53f / 256, 53f / 256, 53f / 256);
                ceiling.sprite = ceilingRockyMountain;
                castle.sprite = castleEvos;
                goblinPowerModifier = .5f;
                trollPowerModifier = .5f;
                wizardPowerModifier = 2f;
                battlespeed = .8f;
                enemyWizards = true;
                battleDifficulty = 1.6f;
                GameManager.battleAudioSource.clip = lavaTheme;

                enemySprites.SetTexture("_MainTex", GameManager.instance.orcArmor5.texture);
                enemyWizardSprites.SetTexture("_MainTex", GameManager.instance.wizardArmor4.texture);
                break;

            //crystal mountain
            case "50": //who the fuck you think
                mainCamera.backgroundColor = new Color(56f / 256, 35f / 256, 46f / 256);
                ceiling.sprite = ceilingCrystalMountain;
                castleIdol.sprite = idolVirion;
                castleIdol.gameObject.SetActive(true);
                castle.sprite = castleCrystalMountain;
                goblinPowerModifier = 0.5f;
                orcPowerModifier = 0.5f;
                wizardPowerModifier = 0.5f;
                trollPowerModifier = 0.5f;
                catapultPowerModifier = 0.5f;
                battlespeed = .6f;
                enemyWizards = true;
                enemyCatapults = true;
                battleDifficulty = 2f;
                GameManager.battleAudioSource.clip = virionTheme;

                enemySprites.SetTexture("_MainTex", virionArmy.texture);
                enemyWizardSprites.SetTexture("_MainTex", virionWizards.texture);
                enemyCatapultSprites.SetTexture("_MainTex", GameManager.instance.catapultArmor3.texture);
                break;
        }
        foreach (SpriteRenderer patch in patches)
            patch.color = mainCamera.backgroundColor;


        adversaryImage.sprite = Banner.GetComponent<Image>().sprite;
        fightButton.gameObject.SetActive(true);
        castleAdversary.sprite = AdversarySprite;
        castleBanner1.sprite = Banner.GetComponent<Image>().sprite;
        castleBanner2.sprite = Banner.GetComponent<Image>().sprite;
        StartCoroutine(countdown());
    }
    [Header("Particle Effects")]
    public ParticleSystem goblinWalkUp;
    public ParticleSystem orcWalkUp;
    public ParticleSystem wizardWalkUp;
    public ParticleSystem trollWalkUp;
    public ParticleSystem catapultWalkUp;

    public ParticleSystem goblinConstant;
    public ParticleSystem orcConstant;
    public ParticleSystem wizardConstant;
    public ParticleSystem trollConstant;
    public ParticleSystem catapultConstant;

    public ParticleSystem smokeCloudParticles;
    public ParticleSystem goblinArrows;
    public ParticleSystem enemyArrows;
    public ParticleSystem goblinFireballs;
    public ParticleSystem enemyFireballs;
    public ParticleSystem goblinPults;
    public ParticleSystem enemyPults;

    public ParticleSystem enemyWalkUp;
    public ParticleSystem enemyConstant;
    public ParticleSystem enemyWizardWalkUp;
    public ParticleSystem enemyWizardConstant;
    public ParticleSystem enemyCatapultWalkUp;
    public ParticleSystem enemyCatapultConstant;

    public Material enemySprites;
    public Material enemyWizardSprites;
    public Material enemyCatapultSprites;

    bool enemyWizards = false;
    bool enemyCatapults = false;

    public Sprite humanKnights;
    public Sprite humanWizards;
    public Sprite samurai;
    public Sprite vikings;
    public Sprite blackLegion;
    public Sprite blackLegionWizards;
    public Sprite elvenWizards;
    public Sprite elvesIrindel;
    public Sprite elvesAellion;
    public Sprite elvesIvoroth;
    public Sprite elvesNilvenora;
    public Sprite virionArmy;
    public Sprite virionWizards;

    [Header("Sound Effects")]
    public AudioClip generic;
    public AudioClip iceTheme;
    public AudioClip samuraiTheme;
    public AudioClip pyroTheme;
    public AudioClip lavaTheme;
    public AudioClip fennTheme;
    public AudioClip godslayerTheme;
    public AudioClip virionTheme;

    IEnumerator countdown()
    {
        autoGoblins = GameManager.autoGoblins;
        GameManager.autoGoblins = 0;
        double orcsPower = GameManager.instance.orcArmyCount * GameManager.instance.orcUpgradeCount * orcPowerModifier;
        double wizardsPower = GameManager.instance.wizardArmyCount * GameManager.instance.wizardUpgradeCount * wizardPowerModifier;
        float trollsPower = GameManager.instance.trollArmyCount * GameManager.instance.trollUpgradeCount * trollPowerModifier;
        float catapultsPower = GameManager.instance.catapultArmyCount * GameManager.instance.catapultUpgradeCount * catapultPowerModifier;
        totalGoblinArmyPower = (GameManager.goblins * (1 + (GameManager.instance.swordUpgradeCount / 5f)) * goblinPowerModifier)
                             + (orcsPower * 6.25f) + (wizardsPower * 225f) + (trollsPower * 10000f) + (catapultsPower * 150000f);

        totalArmyCount = totalGoblinArmyPower + GameManager.instance.orcArmyCount + GameManager.instance.wizardArmyCount + GameManager.instance.trollArmyCount + GameManager.instance.catapultArmyCount;

        totalEnemyArmyPower = enemyArmyCount;


        Vector2 currentSize = warBarBlue.GetComponent<RectTransform>().sizeDelta;
        currentSize.x = Mathf.Clamp((float)(totalArmyCount / (totalArmyCount + enemyArmyCount)) * 1060f, 0, 1030);
        warBarBlue.GetComponent<RectTransform>().sizeDelta = currentSize;
        Vector2 currentSize2 = warBarRed.GetComponent<RectTransform>().sizeDelta;
        currentSize2.x = Mathf.Clamp((float)(enemyArmyCount / (totalArmyCount + enemyArmyCount)) * 1060f, 0, 1030);
        warBarRed.GetComponent<RectTransform>().sizeDelta = currentSize2;
        swordClash.GetComponent<RectTransform>().localPosition = new Vector3(Mathf.Clamp((float)(totalArmyCount / (totalArmyCount + enemyArmyCount) * 1000f - 500), -500, 500), swordClash.GetComponent<RectTransform>().localPosition.y, swordClash.GetComponent<RectTransform>().localPosition.z);

        goblinWalkUp.Emit(2000);
        if (GameManager.instance.orcArmyCount > 0)
            orcWalkUp.Emit(200);
        if (GameManager.instance.wizardArmyCount > 0)
            wizardWalkUp.Emit(40);
        if (GameManager.instance.trollArmyCount > 0)
            trollWalkUp.Emit(10);
        if (GameManager.instance.catapultArmyCount > 0)
            catapultWalkUp.Emit(5);

        enemyWalkUp.Emit(2000);
        if (enemyWizards)
            enemyWizardWalkUp.Emit(40);
        if (enemyCatapults)
            enemyCatapultWalkUp.Emit(5);
        double goblinString = (totalArmyCount - GameManager.instance.orcArmyCount - GameManager.instance.wizardArmyCount - GameManager.instance.trollArmyCount - GameManager.instance.catapultArmyCount);
        goblinText.text = goblinString.ToString("n0");
        orcText.text = GameManager.instance.orcArmyCount.ToString("n0");
        wizardText.text = GameManager.instance.wizardArmyCount.ToString("n0");
        trollText.text = GameManager.instance.trollArmyCount.ToString("n0");
        catapultText.text = GameManager.instance.catapultArmyCount.ToString("n0");
        totalArmyCount = GameManager.goblins + GameManager.instance.orcArmyCount + GameManager.instance.wizardArmyCount + GameManager.instance.trollArmyCount + GameManager.instance.catapultArmyCount;
        goblinArmyText.text = totalArmyCount.ToString("n0");
        enemyArmyText.text = enemyArmyCount.ToString("n0");
        //sound
        GameManager.battleAudioSource.Play();
        for (int i = 1; i <= 25; i++)
        {
            GameManager.battleAudioSource.volume = i / 25f;
            GameManager.aridAudioSource.volume = 1f - (i / 25f);
            yield return new WaitForSeconds(.02f);
        }

        number3.transform.localScale *= 3;
        number3.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            number3.transform.localScale /= 1.115f;
            yield return new WaitForSecondsRealtime(.025f);
        }
        number3.transform.localScale *= 1.05f;
        yield return new WaitForSecondsRealtime(.025f);
        number3.transform.localScale /= 1.05f;
        //
        yield return new WaitForSecondsRealtime(.5f);
        number3.gameObject.SetActive(false);
        //
        
        
        number2.transform.localScale *= 3;
        number2.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            number2.transform.localScale /= 1.115f;
            yield return new WaitForSecondsRealtime(.025f);
        }
        number2.transform.localScale *= 1.05f;
        yield return new WaitForSecondsRealtime(.025f);
        number2.transform.localScale /= 1.05f;
        //
        yield return new WaitForSecondsRealtime(.5f);
        number2.gameObject.SetActive(false);
        //
        
        
        number1.transform.localScale *= 3;
        number1.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            number1.transform.localScale /= 1.115f;
            yield return new WaitForSecondsRealtime(.025f);
        }
        number1.transform.localScale *= 1.05f;
        yield return new WaitForSecondsRealtime(.025f);
        number1.transform.localScale /= 1.05f;
        //
        yield return new WaitForSecondsRealtime(.5f);
        number1.gameObject.SetActive(false);
        //
        
        
        spam.transform.localScale *= 3;
        spam.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            spam.transform.localScale /= 1.115f;
            yield return new WaitForSecondsRealtime(.025f);
        }
        spam.transform.localScale *= 1.05f;
        yield return new WaitForSecondsRealtime(.025f);
        spam.transform.localScale /= 1.05f;
        yield return new WaitForSecondsRealtime(.25f);
        StartCoroutine(simulate());
        fightButton.interactable = true;
        fightButton.GetComponent<Image>().color = Color.white;
        yield return new WaitForSecondsRealtime(.25f);
        spam.gameObject.SetActive(false);
        StartCoroutine(updateClickModifier());
        StartCoroutine(activateSmokecloud());
    }
    IEnumerator simulate()
    {
        goblinConstant.gameObject.SetActive(true);
        if (GameManager.instance.orcArmyCount > 0)
            orcConstant.gameObject.SetActive(true);
        if (GameManager.instance.wizardArmyCount > 0)
            wizardConstant.gameObject.SetActive(true);
        if (GameManager.instance.trollArmyCount > 0)
            trollConstant.gameObject.SetActive(true);
        if (GameManager.instance.catapultArmyCount > 0)
            catapultConstant.gameObject.SetActive(true);

        enemyConstant.gameObject.SetActive(true);
        if (enemyWizards)
            enemyWizardConstant.gameObject.SetActive(true);
        if (enemyCatapults)
            enemyCatapultConstant.gameObject.SetActive(true);

        goblinArrows.gameObject.SetActive(true);
        if (GameManager.instance.wizardArmyCount > 0)
            goblinFireballs.gameObject.SetActive(true);
        if (GameManager.instance.catapultArmyCount > 0)
            goblinPults.gameObject.SetActive(true);
        enemyArrows.gameObject.SetActive(true);
        if (enemyWizards)
            enemyFireballs.gameObject.SetActive(true);
        if (enemyCatapults)
            enemyPults.gameObject.SetActive(true);

        if (goblinPowerModifier > 1)
            goblinBuffed.sprite = buffed;
        else if (goblinPowerModifier < 1)
            goblinBuffed.sprite = debuffed;
        if (orcPowerModifier > 1)
            orcBuffed.sprite = buffed;
        else if (orcPowerModifier < 1)
            orcBuffed.sprite = debuffed;
        if (goblinPowerModifier > 1)
            goblinBuffed.sprite = buffed;
        else if (goblinPowerModifier < 1)
            goblinBuffed.sprite = debuffed;
        if (trollPowerModifier > 1)
            trollBuffed.sprite = buffed;
        else if (trollPowerModifier < 1)
            trollBuffed.sprite = debuffed;
        if (catapultPowerModifier > 1)
            catapultBuffed.sprite = buffed;
        else if (catapultPowerModifier < 1)
            catapultBuffed.sprite = debuffed;

        float newLifeTime = Mathf.Clamp((float)(totalArmyCount / (totalArmyCount + enemyArmyCount)) * 2.45f, 0.1f, 2f);

        ParticleSystem.MainModule mainModule = goblinConstant.main;
        mainModule.startLifetime = newLifeTime;
        mainModule = orcConstant.main;
        mainModule.startLifetime = newLifeTime;
        mainModule = trollConstant.main;
        mainModule.startLifetime = newLifeTime * 1.4f;
        mainModule = catapultConstant.main;
        mainModule.startLifetime = newLifeTime * 1.525f;

        newLifeTime = Mathf.Clamp((float)(enemyArmyCount / (totalArmyCount + enemyArmyCount)) * 2.45f, 0.1f, 2f);

        mainModule = enemyConstant.main;
        mainModule.startLifetime = newLifeTime;
        mainModule = enemyCatapultConstant.main;
        mainModule.startLifetime = newLifeTime * 1.525f;

        while (totalArmyCount > 0 && enemyArmyCount > 0) {
            yield return new WaitForSeconds(.05f);

            double goblinString = (totalArmyCount - GameManager.instance.orcArmyCount - GameManager.instance.wizardArmyCount - GameManager.instance.trollArmyCount - GameManager.instance.catapultArmyCount);
            goblinText.text = goblinString.ToString("n0");
            orcText.text = GameManager.instance.orcArmyCount.ToString("n0");
            wizardText.text = GameManager.instance.wizardArmyCount.ToString("n0");
            trollText.text = GameManager.instance.trollArmyCount.ToString("n0");
            catapultText.text = GameManager.instance.catapultArmyCount.ToString("n0");



            enemyArmyCount -= (totalGoblinArmyPower / 1800f) * battlespeed * (.05f + clicksModifier / 3f) / battleDifficulty; 
            if (enemyArmyCount < 0)
                enemyArmyCount = 0;
            totalArmyCount -= (totalEnemyArmyPower / 1800f) * battlespeed * (5f / (clicksModifier + 1)) / (1 + (GameManager.instance.armorUpgradeCount / 5f)) * battleDifficulty;
            if (totalArmyCount < 0)
                totalArmyCount = 0;

            GameManager.goblins -= (GameManager.goblins / totalArmyCount) * (totalEnemyArmyPower / 1800f) * battlespeed * (5f / (clicksModifier + 1)) / (1 + (GameManager.instance.armorUpgradeCount / 5f));
            if (GameManager.goblins < 0)
                GameManager.goblins = 0;
            GameManager.instance.orcArmyCount -= ((double)GameManager.instance.orcArmyCount / totalArmyCount) * (totalEnemyArmyPower / 1800f) * battlespeed * (5f / (clicksModifier + 1)) / (1 + (GameManager.instance.armorUpgradeCount / 5f));
            if (GameManager.instance.orcArmyCount < 0)
                GameManager.instance.orcArmyCount = 0;
            GameManager.instance.wizardArmyCount -= ((double)GameManager.instance.wizardArmyCount / totalArmyCount) * (totalEnemyArmyPower / 1800f) * battlespeed * (5f / (clicksModifier + 1)) / (1 + (GameManager.instance.armorUpgradeCount / 5f));
            if (GameManager.instance.wizardArmyCount < 0)
                GameManager.instance.wizardArmyCount = 0;
            GameManager.instance.trollArmyCount -= (int)((double)(GameManager.instance.trollArmyCount / totalArmyCount) * (totalEnemyArmyPower / 1800f) * battlespeed * (5f / (clicksModifier + 1)) / (1 + (GameManager.instance.armorUpgradeCount / 5f)));
            if (GameManager.instance.trollArmyCount < 0)
                GameManager.instance.trollArmyCount = 0;
            GameManager.instance.catapultArmyCount -= (int)((double)(GameManager.instance.catapultArmyCount / totalArmyCount) * (totalEnemyArmyPower / 1800f) * battlespeed * (5f / (clicksModifier + 1)) / (1 + (GameManager.instance.armorUpgradeCount / 5f)));
            if (GameManager.instance.catapultArmyCount < 0)
                GameManager.instance.catapultArmyCount = 0;

            Vector2 currentSize = warBarBlue.GetComponent<RectTransform>().sizeDelta;
            currentSize.x = Mathf.Clamp((float)(totalArmyCount / (totalArmyCount + enemyArmyCount)) * 1060f, 0, 1030);
            warBarBlue.GetComponent<RectTransform>().sizeDelta = currentSize;
            Vector2 currentSize2 = warBarRed.GetComponent<RectTransform>().sizeDelta;
            currentSize2.x = Mathf.Clamp((float)(enemyArmyCount / (totalArmyCount + enemyArmyCount)) * 1060f, 0, 1030);
            warBarRed.GetComponent<RectTransform>().sizeDelta = currentSize2;
            swordClash.GetComponent<RectTransform>().localPosition = new Vector3(Mathf.Clamp((float)(totalArmyCount / (totalArmyCount + enemyArmyCount) * 1000f - 500), -500, 500), swordClash.GetComponent<RectTransform>().localPosition.y, swordClash.GetComponent<RectTransform>().localPosition.z);

            goblinArmyText.text = totalArmyCount.ToString("n0");
            enemyArmyText.text = enemyArmyCount.ToString("n0");

            newLifeTime = Mathf.Clamp((float)(totalArmyCount / (totalArmyCount + enemyArmyCount)) * 2.45f, 0.1f, 2f);
            
            mainModule = goblinConstant.main;
            mainModule.startLifetime = newLifeTime;
            mainModule = orcConstant.main;
            mainModule.startLifetime = newLifeTime;
            mainModule = trollConstant.main;
            mainModule.startLifetime = newLifeTime * 1.4f;
            mainModule = catapultConstant.main;
            mainModule.startLifetime = newLifeTime * 1.525f;

            newLifeTime = Mathf.Clamp((float)(enemyArmyCount / (totalArmyCount + enemyArmyCount)) * 2.45f, 0.1f, 2f);
            
            mainModule = enemyConstant.main;
            mainModule.startLifetime = newLifeTime;
            mainModule = enemyCatapultConstant.main;
            mainModule.startLifetime = newLifeTime * 1.525f;

            if (totalArmyCount > enemyArmyCount)
                smokeCloudParticles.transform.localPosition = new Vector3(Mathf.Clamp((float)(totalArmyCount / (totalArmyCount + enemyArmyCount)) * 1160f - 280f, -280f, 780f), smokeCloudParticles.transform.localPosition.y, smokeCloudParticles.transform.localPosition.z);
            else
                smokeCloudParticles.transform.localPosition = new Vector3(Mathf.Clamp((float)(enemyArmyCount / (totalArmyCount + enemyArmyCount)) * -1160f + 780f, -280f, 780f), smokeCloudParticles.transform.localPosition.y, smokeCloudParticles.transform.localPosition.z);
        }
        pauseScreen.SetActive(true);
        victoryButton.gameObject.SetActive(true);
        fightButton.gameObject.SetActive(false);
        if (totalArmyCount > 0)
            victoryButton.sprite = victory;
        else
        {
            victoryButton.sprite = defeat;
            GameManager.goblins = 0;
            GameManager.instance.orcArmyCount = 0;
            GameManager.instance.wizardArmyCount = 0;
            GameManager.instance.trollArmyCount = 0;
            GameManager.instance.catapultArmyCount = 0;
        }
        victoryButton.gameObject.transform.localScale = new Vector3(12, 12, 12);
        GameManager.battleSFXSource.Stop();
        for (int i = 1; i <= 5; i++)
        {
            yield return new WaitForSeconds(.025f);
            GameManager.battleAudioSource.volume = 1f - (i / 5f);
            victoryButton.gameObject.transform.localScale -= new Vector3(1.2f, 1.2f, 1.2f);
        }
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.02f);
            victoryButton.gameObject.transform.localScale += new Vector3(.20f, .20f, .20f);
        }
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.02f);
            victoryButton.gameObject.transform.localScale -= new Vector3(.20f, .20f, .20f);
        }

        GameManager.battleAudioSource.Stop();
        for (int i = 1; i <= 50; i++)
        {
            GameManager.aridAudioSource.volume = (i / 50);
            yield return new WaitForSeconds(.02f);
        }
        GameManager.autoGoblins = autoGoblins;
        if (totalArmyCount > 0)
            currentTerritory.button.Conquer();
        else
        {
            currentTerritory.price = (int)((float)(enemyArmyCount + currentTerritory.originalPrice) / 2);
            currentTerritory.button.price = currentTerritory.price;
        }
        GameManager.instance.game.Transition("war");
    }

    IEnumerator updateClickModifier()
    {
        while (totalArmyCount > 0 && enemyArmyCount > 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            clicksModifier = clicksPerSecond;
            clicksPerSecond = 0;
        }
    }
    IEnumerator activateSmokecloud()
    {
        yield return new WaitForSecondsRealtime(1f);
        if (totalArmyCount > 0 && enemyArmyCount > 0)
        {
            smokeCloudParticles.gameObject.SetActive(true);
            GameManager.battleSFXSource.Play();
        }
    }

    public void click()
    {
        clicksPerSecond++;
    }
}
