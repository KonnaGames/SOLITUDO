using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform bulletRightVFX;
    [SerializeField] private Transform bossProjectileVFX;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);      
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BulletRight")
        {
            Destroy(col.gameObject);
            Instantiate(bossProjectileVFX, transform.position, transform.rotation);
            Instantiate(bulletRightVFX, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
