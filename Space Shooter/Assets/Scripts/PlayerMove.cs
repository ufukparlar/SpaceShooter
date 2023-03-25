using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 3f;
    public float rot;
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float nextFire = 1f;
    public AudioClip deathSound;



    private AudioSource audio;
    private Vector3 movement;
    private Rigidbody rigid;
    private float timer;
    public float minX, maxX, minZ, maxZ;
    public GameObject explosion;
    private CameraFollow cam;
    public GameObject gameOverImg, restart, mainMenu;
    public GameObject gameOverTxt;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        timer += Time.deltaTime;
        
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Move(h, v);

        if (Input.GetButton("Fire1") && timer > nextFire) 
        {
            Shoot();

        }


    }

    void Move (float h , float v)
    {
        movement.Set(h, 0, v);
        //movement = new Vector3(h, 0, v); aynýsý
        movement = movement * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);
        rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, minX, maxX), 0, Mathf.Clamp(rigid.position.z, minZ, maxZ));

        rigid.rotation = Quaternion.Euler(0, 0, -transform.position.x * rot);

    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
        audio.Play();
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameOverTxt.SetActive(true);
            gameOverImg.SetActive(true);
            restart.SetActive(true);
            mainMenu.SetActive(true);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            cam.enabled = false;
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        
    }
}
