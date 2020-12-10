using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{

    //Default parameters
    int baseLives = 5;
    public SpriteRenderer baseMaterial;
    public PlayerScript pScript;

    void Start()
    {
        baseMaterial.color = Color.green;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boulder")
            baseLives -= 1;
        
        if (baseLives == 3)
            baseMaterial.color = Color.yellow;
        if (baseLives == 1)
            baseMaterial.color = Color.red;
        if (baseLives == 0)
        {
            pScript.GameOver();
            Destroy(this.gameObject);
        }
    }
}
