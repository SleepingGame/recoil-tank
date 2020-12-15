using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    //Configuring Boulder
    public float speed;

    //Setting the objects and particles to use
    private Rigidbody2D rb;
    public GameObject explosionPrefab;
    BaseScript bScript;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left;
        bScript = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
            bScript.LiveReduction();
        if (collision.gameObject.tag == "Missle")
            bScript.ScoreIncrement();


     Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
     Destroy(this.gameObject);
    }


}
