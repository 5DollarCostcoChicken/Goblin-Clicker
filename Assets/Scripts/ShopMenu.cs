using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject defaultShop;
    public GameObject warShop;
    public GameObject idolShop;
    string currentShop = "shop";
    bool moving = false;
    public void SpringUp()
    {
        if (!moving)
        {
            if (currentShop.Equals("shop"))
            {
                if (transform.position.y < -36f * (Screen.height / 1080f))
                    StartCoroutine(Bounce());
                else
                    StartCoroutine(Lower());
            }
            else
                StartCoroutine(SwitchShops("shop"));
        }
    }
    IEnumerator Bounce()
    {
        moving = true;
        int i = 0;
        while (transform.position.y < -36f * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -1186 * (Screen.height / 1080f) + .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (transform.position.y > -76f * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -36f * (Screen.height / 1080f) - 3 * i * (Screen.height / 1080f) + .1f * Mathf.Pow(i, 1.5f) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (transform.position.y < -36f * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -76f * (Screen.height / 1080f) + .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        moving = false;
    }
    IEnumerator Lower()
    {
        moving = true;
        int i = 0;
        while (transform.position.y > -1186 * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -36f * (Screen.height / 1080f) - .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        moving = false;
    }
    public void Switch(string shop)
    {
        
        StartCoroutine(SwitchShops(shop));
    }
    IEnumerator SwitchShops(string shopType)
    {
        moving = true;
        int i = 0;
        while (transform.position.y > -1186 * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -36f * (Screen.height / 1080f) - .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        switch (shopType)
        {
            case "shop":
                defaultShop.SetActive(true);
                warShop.SetActive(false);
                idolShop.SetActive(false);
                currentShop = "shop";
                break;
            case "War":
                defaultShop.SetActive(false);
                warShop.SetActive(true);
                idolShop.SetActive(false);
                currentShop = "War";
                break;
            case "Idol":
                defaultShop.SetActive(false);
                warShop.SetActive(false);
                idolShop.SetActive(true);
                currentShop = "Idol";
                break;
        }
        i = 0;
        while (transform.position.y < -36f * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -1186 * (Screen.height / 1080f) + .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (transform.position.y > -76f * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -36f * (Screen.height / 1080f) - 3 * i * (Screen.height / 1080f) + .1f * Mathf.Pow(i, 1.5f) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        i = 0;
        while (transform.position.y < -36f * (Screen.height / 1080f))
        {
            transform.position = new Vector3(transform.position.x, -76f * (Screen.height / 1080f) + .2f * Mathf.Pow(i, 2) * (Screen.height / 1080f), transform.position.z);
            i++;
            yield return new WaitForSeconds(.005f);
        }
        moving = false;
    }
}
