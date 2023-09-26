using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sillyScroll : MonoBehaviour
{
    public string[] phrases;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirstText());
    }
    private void Update()
    {
        transform.localPosition += Vector3.left * Time.deltaTime * 300;
    }

    IEnumerator FirstText()
    {
        if (GameManager.bar)
            yield return new WaitForSeconds(133);
        while (!GameManager.win)
        {
            GetComponent<Text>().text = phrases[Random.Range(0, phrases.Length)];
            GetComponent<RectTransform>().anchoredPosition = new Vector3(1000, -26, 0);
            yield return new WaitForSeconds(20);
        }
    }
}
