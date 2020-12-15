using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Prefabs, Game objects and Rigid Body components
    public GameObject bulletPrefab;
    public GameObject bulletBigPrefab;
    public GameObject bulletEmmitor;
    public GameObject explosionPrefab;
    public Rigidbody2D playerRigidbody;
    public BaseScript bScript;

    //Push force of recoil
    public int bulletPushForce;
    public int bulletBigPushForce;

    //Spinning speed of square
    public int regularSpinSpeed;
    public int fastSpinSpeed;

    //Pushback variables
    public int regularRecoil;
    public int strongRecoil;

    //Others
    public int score = 0;
    public int playerSpawnTime;
    private bool strong = false;
    private bool direction = true;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        bScript = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseScript>();
    }

    void Update()
    {

        //Calling Shoot function
        if(Input.GetKeyDown(KeyCode.Space))
        {
            direction = !direction;
            Shooting();
        }

        //Checking if tank is in strong mode
        if (Input.GetKey(KeyCode.LeftShift))
            strong = true;
        else
            strong = false;


        if (direction)
        {
            if (strong)
                transform.Rotate(0, 0, fastSpinSpeed);
            else
                transform.Rotate(0, 0, regularSpinSpeed);
        }
        else
        {
            if (strong)
                transform.Rotate(0, 0, -fastSpinSpeed);
            else
                transform.Rotate(0, 0, -regularSpinSpeed);
        }
    }

    void Shooting()
    {
        //Checking if strong is true or false when shooting. If true then shoot with big missles, if false shoot regular missles.
        if(strong)
        {
            GameObject bulletBig;
            bulletBig = Instantiate(bulletBigPrefab, bulletEmmitor.transform.position, bulletEmmitor.transform.rotation) as GameObject;
            Rigidbody2D bulletBigrb;
            bulletBigrb = bulletBig.GetComponent<Rigidbody2D>();
            bulletBigrb.velocity = transform.up * bulletBigPushForce;
            Destroy(bulletBig, 3);
            playerRigidbody.velocity = transform.up * -strongRecoil;
        }
        else
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletEmmitor.transform.position, bulletEmmitor.transform.rotation) as GameObject;
            Rigidbody2D bulletrb;
            bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.velocity = transform.up * bulletPushForce;
            Destroy(bullet, 3);
            playerRigidbody.velocity = transform.up * -regularRecoil;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boulder")
        {
            bScript.StartCoroutine(bScript.RespawnTimer());
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "OutOfBounds")
        {
            bScript.StartCoroutine(bScript.RespawnTimer());
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
