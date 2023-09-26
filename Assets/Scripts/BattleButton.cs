using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButton : MonoBehaviour
{
    
    public int price;
    public int originalPrice;
    public int regenRate;
    public string LocationName;
    public Button[] unlockedAfterThis;
    public bool disabled;
    public Sprite Adversary;
    public Sprite AdversaryDemise;
    public ConquerButton button;
    public bool bought;
    float Scale;
    public bool idol;
    public int reward;
    public GameObject banner;
    public Sprite bannerImage;
    public Image icon;
    public void PulseCall(float scale)
    {
        if (!bought)
        {
            StartCoroutine(Pulse());
            Scale = scale;
        }
    }
    public IEnumerator Pulse()
    {
        transform.localScale = new Vector3(Scale, Scale, Scale);
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(Scale + (i / 100f), Scale + (i / 100f), Scale + (i / 100f));
            yield return new WaitForSeconds(.005f);
        }
        for (int i = 10; i > 0; i--)
        {
            transform.localScale = new Vector3(Scale + (i / 100f), Scale + (i / 100f), Scale + (i / 100f));
            yield return new WaitForSeconds(.01f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPrice = price;
        regenRate = originalPrice / 350;
        GetComponent<Button>().image.alphaHitTestMinimumThreshold = .01f;
        if (icon != null)
            icon.color = Color.grey;

        banner = Instantiate(GameManager.instance.bannerPrefab, GameManager.instance.warmap.transform);
        banner.transform.position = this.transform.position;
        if (bought != true)
        {
            banner.GetComponent<Image>().sprite = bannerImage;
        }
        else
            banner.GetComponent<Image>().sprite = GameManager.instance.goblinBanner;

        if (disabled)
        {
            GetComponent<Button>().interactable = false;
            banner.GetComponent<Image>().color = Color.grey;
        }
        if (bought != true)
            bought = false;
    }
    float timer = 0;
    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > .083333333f && price < originalPrice && !bought)
        {
            price += (int)(regenRate / 12);
            timer = 0;
            if (price > originalPrice)
            {
                price = originalPrice;
            }
            if (button.currentTerritory == this.GetComponent<BattleButton>())
                button.price = price;
        }
    }

    public void Pressed()
    {
        if (!bought && !button.warShop.up)
            button.Display(price, LocationName, unlockedAfterThis, Adversary, AdversaryDemise, GetComponent<Image>(), reward, banner, this.GetComponent<BattleButton>());
    }
}
