using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    private Rigidbody rigid;
    public float speed;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();


    }


    void Start()
    {

    }


    void Update()
    {

        rigid.velocity = -transform.forward * speed;
    }
}
