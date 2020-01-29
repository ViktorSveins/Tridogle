using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Projectile")
        {
            GetComponentsInParent<HitCounter>()[0].Hit();
        }
    }
}
