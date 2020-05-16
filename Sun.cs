using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    Light lighting;
    public GM gm;
    float rc, gc, bc;
    bool rs, gs, bs;
    public float r, g, b;
    Material mat;
    float speed;
    int ud, rl, fb;
    
    void Start()
    {
        speed = .02f;
        rs = true; gs = true; bs = true;
        r = Random.Range(.15f, .85f);
        g = Random.Range(.15f, .85f);
        b = Random.Range(.15f, .85f);
        rc = Random.Range(.003f, .008f);
        gc = Random.Range(.003f, .008f);
        bc = Random.Range(.003f, .008f);

        lighting = gameObject.AddComponent<Light>();
        lighting.type = LightType.Point;
        lighting.range = 15000f;
        lighting.color = new Color(r, g, b);
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = Random.Range(20000f, 20000f);
        GetComponent<MeshRenderer>().material = gm.mat[0];
        

        float s = Random.Range(35f, 85f);
        gameObject.transform.localScale = new Vector3(s, s, s);

        int i = Random.Range(0, 2);
        ud = 1;
        if (i == 0) { ud = -1; }

        i = Random.Range(0, 2);
        rl = 1;
        if (i == 0) { rl = -1; }

        i = Random.Range(0, 2);
        fb = 1;
        if (i == 0) { fb = -1; }

        rb.AddForce(transform.up * Random.Range(.3f, .5f) * rb.mass * ud , ForceMode.Impulse);
        rb.AddForce(transform.right * Random.Range(15f, 20f) * rb.mass * rl, ForceMode.Impulse);
        rb.AddForce(transform.forward * Random.Range(15f, 20f) * rb.mass * fb, ForceMode.Impulse);
        mat = GetComponent<MeshRenderer>().material;

    }


    private void FixedUpdate()
    {
        lighting.color = new Color(r, g, b);
        if (rs == true) { r += rc * Time.fixedDeltaTime * 25; }
        if (rs == false) { r -= rc * Time.fixedDeltaTime * 25; }
        if (r >= .85f && rs == true) { rs = false; }
        if (r <= .05f && rs == false) { rs = true; }


        if (gs == true) { g += gc * Time.fixedDeltaTime * 25; }
        if (gs == false) { g -= gc * Time.fixedDeltaTime * 25; }
        if (g >= .85f && gs == true) { gs = false; }
        if (g <= .05f && gs == false) { gs = true; }

        if (bs == true) { b += bc * Time.fixedDeltaTime * 25; }
        if (bs == false) { b -= bc * Time.fixedDeltaTime * 25; }
        if (b >= .85f && bs == true) { bs = false; }
        if (b <= .05f && bs == false) { bs = true; }

        //transform.Rotate(0, 0, .5f * Time.fixedDeltaTime);
        mat.mainTextureOffset = new Vector2(
            mat.mainTextureOffset.x + Time.fixedDeltaTime * speed * rl,
            mat.mainTextureOffset.y + Time.fixedDeltaTime * speed * ud);
    }
}



/*
       // Invoke("GetOthers", .01f);
 *    public GM gm;
    float ud, rl;
    public Transform[] planetTF, starTF;
    public Rigidbody[] planetRB, starRB;
    public float[] planetDistance, planetMass, starDistance, starMass;
    public float speed, closest, furthest;
    Rigidbody rb;
    bool othersGot;
    Vector3[] planetDirection, starDirection;
    GameObject[] star, planet;
 *
 *
 *
 *
 * *        planet = new GameObject[gm.noOfPlanets];
        star = new GameObject[gm.noOfStars];

        planetTF = new Transform[gm.noOfPlanets];
        starTF = new Transform[gm.noOfStars];

        planetRB = new Rigidbody[gm.noOfPlanets];
        starRB = new Rigidbody[gm.noOfStars];

        planetMass = new float[gm.noOfPlanets];
        starMass = new float[gm.noOfStars];

        planetDistance = new float[gm.noOfPlanets];
        starDistance = new float[gm.noOfStars];

        planetDirection = new Vector3[gm.noOfPlanets];
        starDirection = new Vector3[gm.noOfStars];

        void GetOthers()
    {
        for (int i = 0; i < gm.noOfPlanets; i++)
            if (gm.planet[i] != this.gameObject)
            {
                planet[i] = gm.planet[i];
                planetTF[i] = gm.planet[i].transform;
                planetRB[i] = gm.planet[i].GetComponent<Rigidbody>();
                planetMass[i] = planetRB[i].mass;
            }

        othersGot = true;
        for (int i = 0; i < gm.noOfStars; i++)
        {
            star[i] = gm.star[i];
            starRB[i] = star[i].GetComponent<Rigidbody>();
            starTF[i] = star[i].transform;
            starMass[i] = starRB[i].mass;

        void FixedUpdate()
    {
        if (othersGot == true)
        {
            for (int i = 0; i < gm.noOfPlanets; i++)
            {
                planetDistance[i] = Vector3.Distance(transform.position, planetTF[i].transform.position);
                planetDirection[i] = planetTF[i].position - transform.position;
                rb.AddForce(planetDirection[i] * 6.5f * ((planetMass[i] * rb.mass) /
                    (Mathf.Pow(planetDistance[i], 2))) * Time.fixedfixedDeltaTime, ForceMode.Force);
            }

            for (int i = 0; i < gm.noOfStars; i++)
            {
                starDistance[i] = Vector3.Distance(transform.position, starTF[i].transform.position);
                starDirection[i] = starTF[i].position - transform.position;
                rb.AddForce(starDirection[i] * 6.5f * ((starMass[i] * rb.mass) /
                    (Mathf.Pow(starDistance[i], 2))) * Time.fixedfixedDeltaTime, ForceMode.Force);
            }
        }
    }
        }
    }
 * */
