using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    //Configuring Boulder
    public float speed;

    //Setting the objects and particles to use
    private Rigidbody2D rb;
    private ParticleSystem particles;
    public GameObject myPrefab;


    void Start()
    {
        particles = this.GetComponent<ParticleSystem>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Missle")
        {
            Instantiate(myPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


}
