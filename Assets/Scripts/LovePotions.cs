using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LovePotions : MonoBehaviour
{
    public int value;
    public Text valueDisplay;
    public GameObject alchemist1_;
    public GameObject potion1_1;
    public GameObject potion1_2;
    public GameObject potion1_3;
    public GameObject potion1_4;
    public GameObject potion1_5;
    public GameObject alchemist2_;
    public GameObject potion2_1;
    public GameObject potion2_2;
    public GameObject potion2_3;
    public GameObject potion2_4;
    public GameObject potion2_5;
    public GameObject alchemist3_;
    public GameObject potion3_1;
    public GameObject potion3_2;
    public GameObject potion3_3;
    public GameObject potion3_4;
    public GameObject potion3_5;
    public GameObject alchemist4_;
    public GameObject potion4_1;
    public GameObject potion4_2;
    public GameObject potion4_3;
    public GameObject potion4_4;
    public GameObject potion4_5;
    public GameObject alchemist5_;
    public GameObject potion5_1;
    public GameObject potion5_2;
    public GameObject potion5_3;
    public GameObject potion5_4;
    public GameObject potion5_5;
    private void Start()
    {
        if (value == 0)
            value = 15;
    }
    // Update is called once per frame
    void Update()
    {
        if (value != 69)
            valueDisplay.text = "$" + value.ToString("n0");
        else
            valueDisplay.text = "MAX";
        if (GameManager.goblins >= value)
            valueDisplay.color = Color.white;
        else
            valueDisplay.color = Color.red;
    }
    public void Pressed()
    {
        if (GameManager.goblins >= value && value != 69)
        {
            if (IdolOfElixir.multiplier > 0)
                GameManager.autoGoblins += 1 * IdolOfElixir.multiplier;
            else
                GameManager.autoGoblins += 1;
            GameManager.alchemists++;
            GameManager.goblins -= value;
            switch (value)
            {
                case 15:
                    value = 30;
                    alchemist1_.SetActive(true);
                    break;
                case 30:
                    value = 45;
                    potion1_1.SetActive(true);
                    break;
                case 45:
                    value = 60;
                    potion1_2.SetActive(true);
                    break;
                case 60:
                    value = 75;
                    potion1_3.SetActive(true);
                    break;
                case 75:
                    value = 90;
                    potion1_4.SetActive(true);
                    break;
                case 90:
                    value = 200;
                    potion1_5.SetActive(true);
                    break;
                case 200:
                    value = 230;
                    alchemist2_.SetActive(true);
                    break;
                case 230:
                    value = 260;
                    potion2_1.SetActive(true);
                    break;
                case 260:
                    value = 290;
                    potion2_2.SetActive(true);
                    break;
                case 290:
                    value = 320;
                    potion2_3.SetActive(true);
                    break;
                case 320:
                    value = 350;
                    potion2_4.SetActive(true);
                    break;
                case 350:
                    value = 600;
                    potion2_5.SetActive(true);
                    break;
                case 600:
                    value = 650;
                    alchemist3_.SetActive(true);
                    break;
                case 650:
                    value = 700;
                    potion3_1.SetActive(true);
                    break;
                case 700:
                    value = 750;
                    potion3_2.SetActive(true);
                    break;
                case 750:
                    value = 800;
                    potion3_3.SetActive(true);
                    break;
                case 800:
                    value = 850;
                    potion3_4.SetActive(true);
                    break;
                case 850:
                    value = 1250;
                    potion3_5.SetActive(true);
                    break;
                case 1250:
                    value = 1325;
                    alchemist4_.SetActive(true);
                    break;
                case 1325:
                    value = 1400;
                    potion4_1.SetActive(true);
                    break;
                case 1400:
                    value = 1475;
                    potion4_2.SetActive(true);
                    break;
                case 1475:
                    value = 1550;
                    potion4_3.SetActive(true);
                    break;
                case 1550:
                    value = 1625;
                    potion4_4.SetActive(true);
                    break;
                case 1625:
                    value = 2000;
                    potion4_5.SetActive(true);
                    break;
                case 2000:
                    value = 2100;
                    alchemist5_.SetActive(true);
                    break;
                case 2100:
                    value = 2200;
                    potion5_1.SetActive(true);
                    break;
                case 2200:
                    value = 2300;
                    potion5_2.SetActive(true);
                    break;
                case 2300:
                    value = 2400;
                    potion5_3.SetActive(true);
                    break;
                case 2400:
                    value = 2500;
                    potion5_4.SetActive(true);
                    break;
                case 2500:
                    value = 69;
                    potion5_5.SetActive(true);
                    break;
            }
        }
    }
}
