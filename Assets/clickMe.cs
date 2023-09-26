using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickMe : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.goblins > 0)
            Destroy(this.gameObject);
    }
}
