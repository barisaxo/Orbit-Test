using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GM gm;

    public float bodyDistance;
    const float g = 6.5f;
    public Vector3 bodyDirection;

    public int p, i, b;


    void FixedUpdate()
    {
        for (p = 0; p < b; p++)
        {
            for (i = 0; i < b; i++)
            {
                if (gm.body[i] != gm.body[p])
                {
                    bodyDistance = Vector3.Distance(gm.bodyTF[p].transform.position,
                        gm.bodyTF[i].transform.position);

                    bodyDirection = gm.bodyTF[i].position - gm.bodyTF[p].transform.position;

                    gm.bodyRB[p].AddForce(bodyDirection * g * (gm.bodyMass[i] * gm.bodyRB[p].mass /
                        Mathf.Pow(bodyDistance, 2)) * Time.fixedDeltaTime, ForceMode.Force);
                }
            }
        }
    }
}


/*
//otherObject.transform.position - transform.position).normalized


            pos1 = new Vector3(transform.position.x - planetTF[i].position.x,
                transform.position.y - planetTF[i].position.y, transform.position.z - planetTF[i].position.z);
            pos2 = new Vector3(transform.position.x - starTF.position.x,
                transform.position.y - starTF.position.y, transform.position.z - starTF.position.z);
    //public Transform[] planetTF, starTF;
    //public Rigidbody[] planetRB, starRB;
    //public float[] planetDistance, planetMass, starDistance, starMass;
    //public float speed, closest, furthest;
    //Rigidbody rb;
    //bool othersGot;
    //Vector3[] planetDirection, starDirection;
    //GameObject[] star, planet;

    F = G(mass1*mass2)/D squared.


                //for (int p = 0; p < gm.noOfStars; p++)
            //{
            //    for (int i = 0; i < gm.noOfStars; i++)
            //    {
            //        if (gm.star[i] != this.gameObject)
            //        {
            //            gm.starDistance[i] = Vector3.Distance(transform.position, starTF[i].transform.position);
            //            gm.starDirection[i] = starTF[i].position - transform.position;
            //            rb.AddForce(starDirection[i] * 6.5f * ((starMass[i] * rb.mass) /
            //                (Mathf.Pow(starDistance[i], 2))) * Time.fixedDeltaTime, ForceMode.Force);
            //        }
            //    }
            //}




                if (starDistance < closest)
            { closest = starDistance; }
            if (starDistance > furthest)
            { furthest = starDistance; }
            difference = dif - starDistance;
            dif = starDistance;




                //gameObject.transform.LookAt(starTF);
            //rb.AddForce(transform.right * speed * rb.mass * Time.deltaTime, ForceMode.Force);




    
        // transform.position = Vector3.MoveTowards(transform.position,
                planetplanet.position, speed * Time.deltaTime);
    //Debug.Log(this.gameObject + ", " + x * rl + ", " + y + ", " + z * fb);



        // i = Random.Range(0, 2);
        // ud = 1;
        //if (i == 0) { ud = -1; }

        //i = Random.Range(0, 2);
        //rl = 1;
        //if (i == 0) { rl = -1; }

        //i = Random.Range(0, 2);
        // fb = 1;
        //if (i == 0) { rl = -1; }

        ////gameObject.transform.LookAt(starTF);
        //rb.AddForce(transform.up * y * rb.mass * ud, ForceMode.Impulse);
        //rb.AddForce(transform.right * speed * rl * rb.mass, ForceMode.Impulse);
        //rb.AddForce(transform.forward * z * speed * rb.mass * fb, ForceMode.Force);


       void FixedUpdate()
    {
        if (gm.othersGot == true)
        {
            for (int p = 0; p < gm.noOfPlanets; p++)
            {
                for (int i = 0; i < gm.noOfPlanets; i++)
                {
                    if (gm.planet[i] != this.gameObject)
                    {
                        gm.planetDistance[i] = Vector3.Distance(gm.planetTF[p].transform.position, gm.planetTF[i].transform.position);
                        gm.planetDirection[i] = planetTF[i].position - gm.planetTF[p].transform.position;
                        gm.planetRB[p].AddForce(planetDirection[i] * 6.5f * ((planetMass[i] * gm.planetRB[p].mass) /
                            (Mathf.Pow(planetDistance[i], 2))) * Time.fixedDeltaTime, ForceMode.Force);
                    }
                }
            }


            for (int p = 0; p < gm.noOfStars; p++)
            {
                for (int i = 0; i < gm.noOfStars; i++)
                {
                    if (gm.star[i] != this.gameObject)
                    {
                        gm.starDistance[i] = Vector3.Distance(transform.position, starTF[i].transform.position);
                        gm.starDirection[i] = starTF[i].position - transform.position;
                        rb.AddForce(starDirection[i] * 6.5f * ((starMass[i] * rb.mass) /
                            (Mathf.Pow(starDistance[i], 2))) * Time.fixedDeltaTime, ForceMode.Force);
                    }
                }
            }
        }
    }


    */
