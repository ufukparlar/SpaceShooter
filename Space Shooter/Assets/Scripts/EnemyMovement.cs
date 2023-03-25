using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rigid;
    public float nextFire = 3f;
    public GameObject enemyBullet;
    public Transform bulletSpawn;
    private float timer;
    public float speed = 3f;
    private AudioSource audio;
    public GameObject explosion;
    public AudioClip deathSound;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        
        rigid.velocity = -transform.forward * speed;
        if (timer > nextFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(enemyBullet, bulletSpawn.position,bulletSpawn.rotation);
        audio.Play();
        timer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Instantiate(explosion, transform.position, transform.rotation);
            ScoreManager.score += 10; 
            AudioSource.PlayClipAtPoint(deathSound, transform.position);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
            
    }
}
