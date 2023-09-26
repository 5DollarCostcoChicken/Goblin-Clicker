using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudPools : MonoBehaviour
{
    public int value;
    public Text valueDisplay;
    public GameObject Pool;
    public GameObject MudGobs;
    private void Start()
    {
        if (value == 0)
            value = 10000;
        Pool.transform.localScale = new Vector3(Pool.transform.localScale.x / 2.65f, Pool.transform.localScale.y / 2.65f, Pool.transform.localScale.z / 2.65f);
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
                GameManager.autoGoblins += 50 * IdolOfMire.multiplier;
            else
                GameManager.autoGoblins += 50;
            Pool.transform.localScale = new Vector3(Pool.transform.localScale.x + .1f, Pool.transform.localScale.y + .075f, Pool.transform.localScale.z + .05f);
            GameManager.goblins -= value;
            GameManager.mudpools++;
            switch (value)
            {
                case 10000:
                    value = 13000;
                    Pool.SetActive(true);
                    MudGobs.SetActive(true);
                    break;
                case 13000:
                    value = 16000;
                    break;
                case 16000:
                    value = 19000;
                    break;
                case 19000:
                    value = 22000;
                    break;
                case 22000:
                    value = 25000;
                    break;
                case 25000:
                    value = 28000;
                    break;
                case 28000:
                    value = 31000;
                    break;
                case 31000:
                    value = 34000;
                    break;
                case 34000:
                    value = 37000;
                    break;
                case 37000:
                    value = 40000;
                    break;
                case 40000:
                    value = 45000;
                    break;
                case 45000:
                    value = 50000;
                    break;
                case 50000:
                    value = 55000;
                    break;
                case 55000:
                    value = 60000;
                    break;
                case 60000:
                    value = 65000;
                    break;
                case 65000:
                    value = 70000;
                    break;
                case 70000:
                    value = 75000;
                    break;
                case 75000:
                    value = 80000;
                    break;
                case 80000:
                    value = 85000;
                    break;
                case 85000:
                    value = 69;
                    break;
            }
        }
    }
}
