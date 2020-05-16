using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public int noOfMoons, noOfPlanets, noOfStars, noOfBodies;
    public List<GameObject> body = new List<GameObject>();
    public List<Rigidbody> bodyRB = new List<Rigidbody>();
    public List<Transform> bodyTF = new List<Transform>();
    public List<Vector3> bodyDirection = new List<Vector3>();
    public List<float> bodyMass = new List<float>();
    public List<float> bodyDistance = new List<float>();
    public Material[] mat = new Material[3];
    public Camera cam;

    void Start()
    {
        noOfStars = 1;//Random.Range(1, 4);
        for (int s = 0; s < noOfStars; s++)
        {
            int i = Random.Range(0, 2);
            int ud = 1;
            if (i == 0) { ud = -1; }

            i = Random.Range(0, 2);
            int rl = 1;
            if (i == 0) { rl = -1; }

            i = Random.Range(0, 2);
            int fb = 1;
            if (i == 0) { fb = -1; }

            body.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));

            int d = body.Count;
            body[d - 1].name = ("Star: " + s);
           // body[d - 1].gameObject.transform.position = new Vector3(Random.Range(5250f, 5750f) * (3 + s) * ud,
             //   Random.Range(5250f, 5750f) * (3 + s) * rl, Random.Range(5250f, 5750f) * (3 + s) * fb);
            body[d - 1].AddComponent<Sun>().gm = GetComponent<GM>();

            noOfPlanets = Random.Range(3, 6);
            for (int x = 0; x < noOfPlanets; x++)
            {
                body.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
                int b = body.Count;

                if (x == 0 && s == 0)
                {
                    body[b - 1].AddComponent<MyCamera>().gm = GetComponent<GM>();
                    body[b - 1].AddComponent<Player>().gm = GetComponent<GM>();
                }

                body[b - 1].name = ("Planet: " + s + ", " + x);
                body[b - 1].gameObject.transform.position = body[d - 1].gameObject.transform.position;
                body[b - 1].AddComponent<Planet>().gm = GetComponent<GM>();
                body[b - 1].GetComponent<Planet>().p = x;
                body[b - 1].GetComponent<Planet>().s = d - 1;

                noOfMoons = 1; //Random.Range(1, 4);
                //if (noOfMoons <= 0)
                //{ noOfMoons = 0; }
                for (int m = 0; m < noOfMoons; m++)
                {
                    body.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
                    int n = body.Count;
                    body[n - 1].name = ("Moon: " + s + ", " + x + ", " + m);
                    // body[n - 1].gameObject.transform.position = body[b - 1].gameObject.transform.position;
                    body[n - 1].AddComponent<Moon>().gm = GetComponent<GM>();
                    body[n - 1].GetComponent<Moon>().m = m;
                    body[n - 1].GetComponent<Moon>().startTF = body[b - 1].transform;
                }
            }
        }
        gameObject.AddComponent<Grid>().gm = GetComponent<GM>();
        Invoke("Next", Time.deltaTime);
    }

    void Next()
    {
        for (int i = 0; i < body.Count; i++)
        {
            bodyTF.Add(body[i].transform);
            bodyRB.Add(body[i].GetComponent<Rigidbody>());
            bodyMass.Add(bodyRB[i].mass);
        }
        Gravity gravity = gameObject.AddComponent<Gravity>();
        gravity.gm = this.gameObject.GetComponent<GM>();
        gravity.b = body.Count;
    }
}

/*

//GameObject planet = new GameObject("planet");
//planet.AddComponent<planetCollider>();
//planet.AddComponent<MeshFilter>();
//planet.AddComponent<MeshRenderer>();


//planetOneA = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//planetOneA.name = ("Planet One");
//planetOneA.AddComponent<Gravity>().gm = this.gameObject.GetComponent<GM>();



//planetTwoA = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//planetTwoA.name = ("Planet Two");
//planetTwoA.AddComponent<Gravity>().gm = this.gameObject.GetComponent<GM>();




        //planetTF = new Transform[noOfPlanets];
        //starTF = new Transform[noOfStars];
        //bodyTF = new Transform[noOfBodies];

        //planetRB = new Rigidbody[noOfPlanets];
        //starRB = new Rigidbody[noOfStars];
       // bodyRB = new Rigidbody[noOfBodies];

        //planetMass = new float[noOfPlanets];
        //starMass = new float[noOfStars];
        //bodyMass = new float[noOfBodies];

        //planetDistance = new float[noOfPlanets];
        //starDistance = new float[noOfStars];
        //bodyDistance = new float[noOfBodies];

        //planetDirection = new Vector3[noOfPlanets];
        //starDirection = new Vector3[noOfStars];
        //bodyDirection = new Vector3[noOfBodies];





            //for (int i = 0; i < noOfPlanets; i++)
        //{ 
        //    if (planet[i] != this.gameObject)
        //    {
        //        planet[i] = planet[i];
        //        planetTF[i] = planet[i].transform;
        //        planetRB[i] = planet[i].GetComponent<Rigidbody>();
        //        planetMass[i] = planetRB[i].mass;
        //    }
        //}

        //for (int i = 0; i < noOfStars; i++)
        //{
        //    if (star[i] != this.gameObject)
        //    {
        //        star[i] = star[i];
        //        starRB[i] = star[i].GetComponent<Rigidbody>();
        //        starTF[i] = star[i].transform;
        //        starMass[i] = starRB[i].mass;
        //    }
        //}

    */
