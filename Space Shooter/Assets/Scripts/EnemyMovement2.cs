using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public Transform startPos, pos1, pos2;
    public float speed;

    public float nextFire = 3f;
    public GameObject enemyBullet;
    public Transform bulletSpawn;
    private float timer;
    public GameObject explosion;
    public AudioClip deathSound;


    private AudioSource audio;
    private Rigidbody rigid;
    private Vector3 nextPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        nextPos = startPos.position;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        if (timer > nextFire)
        {
            Shoot();
        }

    }
    void Shoot()
    {
        Instantiate(enemyBullet, bulletSpawn.position, bulletSpawn.rotation);
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
