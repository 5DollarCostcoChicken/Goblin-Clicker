using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdolOfSorcery : MonoBehaviour
{
    public int value;
    public Text valueDisplay;
    public Text elixirDisplay;
    int victoriesNeeded = 20;
    public GameObject statue;
    int count;
    public static int multiplier;
    // Start is called before the first frame update
    void Start()
    {
        if (value == 0)
            value = 100000;
        multiplier = 1;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        multiplier = (int)Mathf.Pow(2, count);
        if (victoriesNeeded <= GameManager.victories || value == 69)
        {
            if (value != 69)
                valueDisplay.text = "$" + value.ToString("n0");
            else
                valueDisplay.text = "MAX";
            if (GameManager.goblins >= value)
                valueDisplay.color = Color.green;
            else
                valueDisplay.color = Color.red;
        }
        else
        {
            valueDisplay.color = Color.white;
            valueDisplay.text = "" + (victoriesNeeded - GameManager.victories) + " more battles to unlock";
        }
        elixirDisplay.text = "Amoromancer Multiplier (scales with upgrades): " + multiplier + "x";
    }
    public void Pressed()
    {
        if (GameManager.goblins >= value && value != 69 && victoriesNeeded <= GameManager.victories)
        {
            GameManager.autoGoblins += (GameManager.amoromancers * 5 * Mathf.Pow(2, count));
            count++;
            GameManager.idolSorceryCount++;
            victoriesNeeded += 2;
            GameManager.goblins -= value;
            if (value == 100000)
            {
                elixirDisplay.gameObject.SetActive(true);
                statue.SetActive(true);
            }
            if (value < 1000000)
                value += 100000;
            else
                value = 69;
        }
    }
}
