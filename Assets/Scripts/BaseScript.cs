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
    public int score;


    void Start()
    {
        score = 0;
        Debug.Log(score);
        baseMaterial.color = Color.green;
        GameObject Player;
        Player = Instantiate(playerPrefab, playerSpawnPos.transform.position, Quaternion.identity) as GameObject;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boulder")
            LiveReduction();
    }


    public void Respawn()
    {
        GameObject Player;
        Player = Instantiate(playerPrefab, playerSpawnPos.transform.position, Quaternion.identity) as GameObject;
    }


    public IEnumerator RespawnTimer()
    {
        LiveReduction();
        yield return new WaitForSeconds(playerRespawnTimer);
        Respawn();
    }

    public void ScoreIncrement()
    {
        score++;
        Debug.Log("Score is: " + score);
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
            Instantiate(baseExplosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Gameovertext.SetActive(true);
            Restartbutton.SetActive(true);
        }
    }

}
