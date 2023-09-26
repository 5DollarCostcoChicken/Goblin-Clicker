using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null; public static GameManager instance { get { return _instance; } }
    [Header("Base Game Variables")]
    public static double goblins = 50000;
    public static float multiplier = 1;
    public static double autoGoblins;
    public static bool ShopOpen;
    public static bool WarOpen;
    public static float warDiscount;
    public static int victories;
    public static int alchemists;
    public static int amoromancers;
    public static int mudpools;
    public static bool Virion;
    public static bool Godslayer;
    public static AudioSource audioSource;
    public  AudioSource AudioSource;
    public static AudioSource aridAudioSource;
    public AudioSource AridAudioSource;
    public static AudioSource battleAudioSource;
    public AudioSource BattleAudioSource;
    public static AudioSource battleSFXSource;
    public AudioSource BattleSFXSource;
    public static AudioClip aridExploration;
    public static AudioClip pop;
    public AudioClip Pop;
    public AudioClip AridExploration;
    public static AudioClip goblinBattleMusic;
    public AudioClip GoblinBattleMusic;
    public static AudioClip goblinBattleSFX;
    public AudioClip GoblinBattleSFX;
    public static bool win;
    public Camera mainCamera;
    [Header("War Map Sprites")]
    public Sprite goblinBanner;
    public GameObject bannerPrefab;
    public GameObject warmap;
    [Header("Regional Amounts")]
    public int velengard = 3;
    public int nakimata = 4;
    public int astinor = 10;
    public int izinor = 9;
    public int sarshiya = 2;
    public int ivoroth = 5;
    [Header("War Shop Unlocks (unlocked through conquered territory)")]
    public GameObject warShopButton;
    public GameObject warShop;
    public int swordUnlocks = 0;
    public int armorUnlocks = 0;
    public int orcUnlocks = 0;
    public int wizardUnlocks = 0;
    public int trollUnlocks = 0;
    public int catapultUnlocks = 0;
    [Header("War Shop Upgrades (bought through upgrade buttons)")]
    public int swordUpgradeCount = 0;
    public int armorUpgradeCount = 0;
    public int orcUpgradeCount = 0;
    public int wizardUpgradeCount = 0;
    public int trollUpgradeCount = 0;
    public int catapultUpgradeCount = 0;
    [Header("Army Amounts")]
    public double orcArmyCount = 0;
    public double wizardArmyCount = 0;
    public int trollArmyCount = 0;
    public int catapultArmyCount = 0;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        autoGoblins = 0;
        ShopOpen = false;
        WarOpen = false;
        victories = 0;
        alchemists = 0;
        amoromancers = 0;
        mudpools = 0;
        Virion = false;
        Godslayer = false;
        audioSource = AudioSource;
        battleAudioSource = BattleAudioSource;
        battleSFXSource = BattleSFXSource;
        aridAudioSource = AridAudioSource;
        pop = Pop;
        aridExploration = AridExploration;
        goblinBattleMusic = GoblinBattleMusic;
        goblinBattleSFX = GoblinBattleSFX;
        win = false;
        GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinsParticles.texture;
        GameManager.instance.orcParticles.mainTexture = GameManager.instance.orcArmor1.texture;
        GameManager.instance.wizardParticles.mainTexture = GameManager.instance.wizardArmor1.texture;
        GameManager.instance.trollParticles.mainTexture = GameManager.instance.trollArmor1.texture;
        GameManager.instance.catapultParticles.mainTexture = GameManager.instance.catapultArmor1.texture;
    }

    [Header("Base Upgrades")]
    public static int houseUpgrades = 0;
    public UpgradeButton house;
    public Amoromancers amoro;
    public MudPools mud;
    public LovePotions lovePot;
    public Game game;
    [Header("Sync War Idols")]
    public static List<string> warNamesConquered = new List<string>();
    public BattleButton[] warTerritories;

    public GameObject idolWarButton;
    public static int idolWarCount;
    public GameObject idolElixirButton;
    public static int idolElixirCount;
    public GameObject idolSorceryButton;
    public static int idolSorceryCount;
    public GameObject idolMudButton;
    public static int idolMudCount;
    public GameObject idolDestructionButton;
    public static bool idolDestructionCount;
    public GameObject idolCreationButton;
    public static bool idolCreationCount;

    public IdolOfWar idolW;
    public IdolOfMire idolM;
    public IdolOfSorcery idolS;
    public IdolOfElixir idolE;
    public IdolOfDestruction idolD;
    public IdolOfCreation idolC;
    [Header("Army Materials / Sprites")]
    public Material goblinParticles;
    public Sprite goblinsParticles;
    public Sprite goblinSwords;
    public Sprite goblinArmor1;
    public Sprite goblinArmor2;
    public Sprite goblinArmor3;
    public Sprite goblinArmor4;
    public Sprite goblinArmor5;

    public Material orcParticles;
    public ParticleSystem orcParticleSystem;
    public Sprite orcArmor1;
    public Sprite orcArmor2;
    public Sprite orcArmor3;
    public Sprite orcArmor4;
    public Sprite orcArmor5;

    public Material wizardParticles;
    public ParticleSystem wizardParticleSystem;
    public Sprite wizardArmor1;
    public Sprite wizardArmor2;
    public Sprite wizardArmor3;
    public Sprite wizardArmor4;
    public Sprite wizardArmor5;

    public Material trollParticles;
    public ParticleSystem trollParticleSystem;
    public Sprite trollArmor1;
    public Sprite trollArmor2;
    public Sprite trollArmor3;

    public Material catapultParticles;
    public ParticleSystem catapultParticleSystem;
    public Sprite catapultArmor1;
    public Sprite catapultArmor2;
    public Sprite catapultArmor3;

    public BattleSimulation battleSimulation;

    public static bool bar = true;
    public static void Load(GameData data)
    {
        GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinsParticles.texture;
        GameManager.instance.orcParticles.mainTexture = GameManager.instance.orcArmor1.texture;
        GameManager.instance.wizardParticles.mainTexture = GameManager.instance.wizardArmor1.texture;
        GameManager.instance.trollParticles.mainTexture = GameManager.instance.trollArmor1.texture;
        GameManager.instance.catapultParticles.mainTexture = GameManager.instance.catapultArmor1.texture;
        goblins = double.MaxValue;
        #region Upgrades
        //house upgrades
        int h = data.houseUpgrades;
        instance.house.value = 100;
        for (int i = 0; i < h; i++)
        {
            instance.house.Pressed();
        }
        //alchemists
        int l = data.alchemists;
        instance.lovePot.value = 15;
        for (int i = 0; i < l; i++)
        {
            instance.lovePot.Pressed();
        }
        //amoromancers
        int a = data.amoromancers;
        instance.amoro.value = 800;
        for (int i = 0; i < a; i++)
        {
            instance.amoro.Pressed();
        }
        //mud pools
        int m = data.mudpools;
        instance.mud.value = 10000;
        for (int i = 0; i < m; i++)
        {
            instance.mud.Pressed();
        }
        #endregion

        #region war shit
        warNamesConquered = data.warNamesConquered;
        for (int i = 0; i < warNamesConquered.Count; i++)
        {
            string warName = warNamesConquered[i].Substring(8, 2);
            if (warName.Substring(1, 1).Equals(")"))
            {
                warName = warName.Substring(0, 1);
            }
            BattleButton currentButton = instance.warTerritories[int.Parse(warName)];
            foreach (Button button in currentButton.unlockedAfterThis)
            {
                button.interactable = true;
                button.gameObject.GetComponent<BattleButton>().disabled = false;
                button.GetComponent<BattleButton>().banner.GetComponent<Image>().color = Color.white;
                if (button.GetComponent<BattleButton>().icon != null)
                    button.GetComponent<BattleButton>().icon.color = Color.white;
            }
            currentButton.GetComponent<Image>().color = Color.white;
            currentButton.GetComponent<BattleButton>().bought = true;
            autoGoblins += currentButton.reward;
            victories++;
            switch (currentButton.name.Substring(8, 2))
            {
                case "2)":
                    instance.idolWarButton.SetActive(true);
                    GameManager.instance.warShopButton.SetActive(true);
                    break;
                case "24":
                    instance.idolWarButton.SetActive(true);
                    GameManager.instance.warShopButton.SetActive(true);
                    break;
                case "8)":
                    instance.idolElixirButton.SetActive(true);
                    break;
                case "23":
                    instance.idolSorceryButton.SetActive(true);
                    break;
                case "34":
                    instance.idolMudButton.SetActive(true);
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
            if (victories == 62)
            {
                instance.idolDestructionButton.SetActive(true);
                instance.idolCreationButton.SetActive(true);
            }

            switch (currentButton.banner.GetComponent<Image>().sprite.name)
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
            if (currentButton.banner != null)
                currentButton.banner.GetComponent<Image>().sprite = instance.goblinBanner;
        }
        #endregion

        #region idols
        //house upgrades
        int iWar = data.idolWarCount;
        instance.idolW.value = 100000;
        for (int i = 0; i < iWar; i++)
        {
            instance.idolW.Pressed();
        }
        int iElixir = data.idolElixirCount;
        instance.idolE.value = 5000;
        for (int i = 0; i < iElixir; i++)
        {
            instance.idolE.Pressed();
        }
        int iMud = data.idolMudCount;
        instance.idolM.value = 20000000;
        for (int i = 0; i < iMud; i++)
        {
            instance.idolM.Pressed();
        }
        int iSorcery = data.idolSorceryCount;
        instance.idolS.value = 100000;
        for (int i = 0; i < iSorcery; i++)
        {
            instance.idolS.Pressed();
        }
        bool iDestruction = data.idolDestructionCount;
        if (iDestruction) {
            instance.idolD.Pressed();
        }
        bool iCreation = data.idolCreationCount;
        if (iCreation)
        {
            instance.idolC.Pressed();
        }
        #endregion

        #region warShop
        for (int i = 0; i < data.swordUpgradeCount; i++)
            instance.warShop.GetComponent<WarShopButtons>().swordPressed();

        for (int i = 0; i < data.armorUpgradeCount; i++)
            instance.warShop.GetComponent<WarShopButtons>().armorPressed();

        for (int i = 0; i < data.orcUpgradeCount; i++)
            instance.warShop.GetComponent<WarShopButtons>().orcPressed();

        for (int i = 0; i < data.wizardUpgradeCount; i++)
            instance.warShop.GetComponent<WarShopButtons>().wizardPressed();

        for (int i = 0; i < data.trollUpgradeCount; i++)
            instance.warShop.GetComponent<WarShopButtons>().trollPressed();

        for (int i = 0; i < data.catapultUpgradeCount; i++)
            instance.warShop.GetComponent<WarShopButtons>().catapultPressed();



        instance.orcArmyCount = data.orcArmyCount;
        instance.wizardArmyCount = data.wizardArmyCount;
        instance.trollArmyCount = data.trollArmyCount;
        instance.catapultArmyCount = data.catapultArmyCount;
        #endregion

        goblins = data.goblins;
        if (goblins >= 10 && !ShopOpen)
            instance.game.shopButton.SpringUp();
        if (goblins >= 10000 && !WarOpen)
        {
            instance.game.warButton.SpringUp();
            GameManager.instance.goblinParticles.mainTexture = GameManager.instance.goblinSwords.texture;
        }
        bar = data.bar;
        goblins -= multiplier;
        instance.game.Increment();
    }
}
