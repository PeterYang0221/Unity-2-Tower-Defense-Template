﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{   
    public ProjectileType self;
    public float maxActiveTime = 5f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.localScale *= self.size;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = self.sprite;
        this.gameObject.GetComponent<SpriteRenderer>().color = self.color;
        //Destroy(this.gameObject,maxActiveTime);
        StartCoroutine(ActiveTime());

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null )
        {
            this.transform.position = Vector3.MoveTowards(
                this.transform.position,//the projectile's position
                target.transform.position,//destination: the target's position
                self.speed * Time.deltaTime);//how fast to get from projectile position to destination
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyManager>() != null)
        {
            collision.GetComponent<EnemyManager>().ProjectileHit(self.damage);
            Destroy(this.gameObject);
        }
    }
    IEnumerator ActiveTime()
    {
        yield return new WaitForSeconds(maxActiveTime);
        Destroy(this.gameObject);
    }
}
