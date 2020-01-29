using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform projectilePrefab;
    public Transform dogPrefab;
    
    public GameObject dog;
    public GameObject walls;
    public Camera cam;

    Transform[] balls;

    bool loosingState;
    bool stop;
    int projectiles;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        projectiles = 0;
        loosingState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop && !loosingState && Input.GetKeyDown(KeyCode.Mouse0))
        {
            dog.GetComponent<DogMovement>().enabled = true;
            balls = new Transform[8];
            balls[0] = Instantiate(projectilePrefab);
            projectiles++;
            stop = false;
            color = cam.backgroundColor;
        }
        
        int wallHits = walls.GetComponent<HitCounter>().hits;
        if(projectiles < 2 && wallHits > 70)
        {
            projectiles = SpawnProjectiles(projectiles);
        }
        else if(projectiles < 3 && wallHits > 200)
        {
            projectiles = SpawnProjectiles(projectiles);
        }
        else if(projectiles < 5 && wallHits > 400)
        {
            projectiles = SpawnProjectiles(projectiles);
        }
        
        if(dog.GetComponent<HitCounter>().hits == 32)
        {
            BlinkBackground();
            Reset();
        }
    }

    int SpawnProjectiles(int prior)
    {
        for(int i = 0; i < prior; i++)
        {
            balls[i + prior] = Instantiate(projectilePrefab, balls[i].position, Quaternion.identity);
        }
        return prior * 2;
    }

    void Reset() {
        for(int i = 0; i < projectiles; i++)
        {
            Destroy(balls[i].gameObject);
        }
        Destroy(dog);
        walls.GetComponent<HitCounter>().hits = 0;

        stop = true;

        dog = Instantiate(dogPrefab).gameObject;
        projectiles = 0;
    }

    void BlinkBackground() {
        loosingState = true;
        StartCoroutine(Blink());
    }
    
    IEnumerator Blink() {
        for (int i=0; i<12; i++) {
            if(cam.backgroundColor == color)
            {
                cam.backgroundColor = new Color(0.67f, 0.278f, 0.224f);
            }
            else
            {
                cam.backgroundColor = color;
            }
            yield return new WaitForSeconds(0.2f);
        }
        cam.backgroundColor = color;
        loosingState = false;
    }
}
