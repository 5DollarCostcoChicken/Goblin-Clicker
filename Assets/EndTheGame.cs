using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTheGame : MonoBehaviour
{
    int count;
    public ShopMenu shopMenu;
    public ShopButton shopButton;
    public ShopButton winButton;
    public WarButton warButton;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    public void Credits()
    {
        GameManager.autoGoblins = 0;
        GameManager.goblins = 0;
        SceneManager.LoadScene(2);
    }
    public void Pressed()
    {
        count++;
        if (count == 2)
        {
            shopMenu.SendMessage("Lower");
            shopButton.SendMessage("Lower");
            winButton.SendMessage("Bounce");
            warButton.SendMessage("Lower");
        }
    }
}
