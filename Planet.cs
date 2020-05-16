using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int p, s, ud, rl;
    public GM gm;
    float speed;
    Material mat;
    void Start()
    {
        speed = .02f;
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = Random.Range(75f, 75f);

        float scale = Random.Range(10f, 12f);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);

        float x = Random.Range(2000f, 2200f);
        float y = Random.Range(.01f, .05f);
        float z = Random.Range(2000f, 2200f);

        int r = Random.Range(0, 2);
        ud = 1;
        if (r == 0) { ud = -1; }

        r = Random.Range(0, 2);
        rl = 1;
        if (r == 0) { rl = -1; }

        r = Random.Range(0, 2);
        int fb = 1;
        if (r == 0) { fb = -1; }

        gameObject.transform.Translate(x * ((p * .2f) + 1) * rl, y * (p *.2f) * ud, z * ((p * .2f) + 1) * fb);
        transform.LookAt(gm.body[s].transform);
        rb.AddForce(transform.up * Random.Range(.1f, .15f) * rb.mass * ud, ForceMode.Impulse);
        rb.AddForce(transform.right * Random.Range(1f, 2f) * rb.mass * rl, ForceMode.Impulse);
        rb.AddForce(transform.forward * Random.Range(1f, 2f) * rb.mass, ForceMode.Impulse);
        mat = GetComponent<MeshRenderer>().material = gm.mat[Random.Range(1, 3)];
    }
    private void FixedUpdate()
    {
       // transform.Rotate(0, Random.Range(2f, 5f)* Time.fixedDeltaTime, 0);
        //transform.LookAt(gm.body[0].transform); // to look at the sun.
        mat.mainTextureOffset = new Vector2(
            mat.mainTextureOffset.x + (Time.fixedDeltaTime * speed * rl),
            mat.mainTextureOffset.y + (Time.fixedDeltaTime * speed * ud));
    }
}
