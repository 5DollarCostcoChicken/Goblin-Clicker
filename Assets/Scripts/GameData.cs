using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public double goblins;
    public int houseUpgrades;
    public int alchemists;
    public int amoromancers;
    public int mudpools;
    public List<string> warNamesConquered;
    public bool bar;

    public int idolWarCount;
    public int idolElixirCount;
    public int idolSorceryCount;
    public int idolMudCount;
    public bool idolDestructionCount;
    public bool idolCreationCount;

    public int swordUpgradeCount = 0;
    public int armorUpgradeCount = 0;
    public int orcUpgradeCount = 0;
    public int wizardUpgradeCount = 0;
    public int trollUpgradeCount = 0;
    public int catapultUpgradeCount = 0;

    public double orcArmyCount;
    public double wizardArmyCount;
    public int trollArmyCount;
    public int catapultArmyCount;

    public GameData()
    {
        goblins = GameManager.goblins;
        houseUpgrades = GameManager.houseUpgrades;
        alchemists = GameManager.alchemists;
        amoromancers = GameManager.amoromancers;
        mudpools = GameManager.mudpools;
        warNamesConquered = GameManager.warNamesConquered;
        bar = GameManager.bar;

        idolWarCount = GameManager.idolWarCount;
        idolElixirCount = GameManager.idolElixirCount;
        idolSorceryCount = GameManager.idolSorceryCount;
        idolMudCount = GameManager.idolMudCount;
        idolDestructionCount = GameManager.idolDestructionCount;
        idolCreationCount = GameManager.idolCreationCount;

        swordUpgradeCount = GameManager.instance.swordUpgradeCount;
        armorUpgradeCount = GameManager.instance.armorUpgradeCount;
        orcUpgradeCount = GameManager.instance.orcUpgradeCount;
        wizardUpgradeCount = GameManager.instance.wizardUpgradeCount;
        trollUpgradeCount = GameManager.instance.trollUpgradeCount;
        catapultUpgradeCount = GameManager.instance.catapultUpgradeCount;

        orcArmyCount = GameManager.instance.orcArmyCount;
        wizardArmyCount = GameManager.instance.wizardArmyCount;
        trollArmyCount = GameManager.instance.trollArmyCount;
        catapultArmyCount = GameManager.instance.catapultArmyCount;
    }
}
