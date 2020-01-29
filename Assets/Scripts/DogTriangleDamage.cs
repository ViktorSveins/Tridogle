using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTriangleDamage : MonoBehaviour
{
    SpriteRenderer sr;
    EdgeCollider2D ec;
    AudioSource audio;
    Color dmgColor;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ec = GetComponent<EdgeCollider2D>();
        audio = GetComponent<AudioSource>();
        dmgColor = new Color(0.1f, 0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Projectile")
        {
            audio.Play();
            sr.color = dmgColor;
            ec.enabled = false;
            GetComponentsInParent<HitCounter>()[0].Hit();
        }
    }
}
