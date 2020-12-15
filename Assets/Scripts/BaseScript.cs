using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{

    //Default parameters
    int baseLives = 5;
    public SpriteRenderer baseMaterial;
    public PlayerScript pScript;
    public GameObject baseExplosion;
    public GameObject playerPrefab, playerSpawnPos;
    public GameObject Gameovertext, Restartbutton;
    public int playerRespawnTimer;
    GameObject[] boulder;
    public bool safe;


    void Start()
    {
        baseMaterial.color = Color.green;
        GameObject Player;
        Player = Instantiate(playerPrefab, playerSpawnPos.transform.position, Quaternion.identity) as GameObject;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boulder")
            LiveReduction();
    }

    public void RespawnSafe()
    {
        for (int i = 0; i < boulder.Length; i++)
        {
            boulder = GameObject.FindGameObjectsWithTag("Boulder");
            Destroy(boulder[i].gameObject);
        }
        GameObject Player;
        Player = Instantiate(playerPrefab, playerSpawnPos.transform.position, Quaternion.identity) as GameObject;
    }
    public void RespawnNSafe()
    {
        GameObject Player;
        Player = Instantiate(playerPrefab, playerSpawnPos.transform.position, Quaternion.identity) as GameObject;
    }


    public IEnumerator RespawnTimer()
    {
        LiveReduction();
        yield return new WaitForSeconds(playerRespawnTimer);
        if (safe)
            RespawnSafe();
        else
            RespawnNSafe();
    }


    public void LiveReduction()
    {
        baseLives -= 1;

        if (baseLives == 3)
            baseMaterial.color = Color.yellow;
        if (baseLives == 1)
            baseMaterial.color = Color.red;
        if (baseLives == 0)
        {
            Destroy(this.gameObject);
            Instantiate(baseExplosion, this.transform.position, Quaternion.identity);
            Gameovertext.SetActive(true);
            Restartbutton.SetActive(true);
        }
    }

}
