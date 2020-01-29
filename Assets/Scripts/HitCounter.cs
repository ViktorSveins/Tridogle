using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    public int hits;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
    }

    public void Hit()
    {
        hits++;
    }
}
