using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public GM gm;
    public Transform startTF;
    Material mat;
    float speed;
    int ud, rl, fb;
    public int m;
    
    void Start()
    {
        speed = .02f;
        gameObject.transform.position = startTF.position;
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = Random.Range(.1f, .3f);
        float scale = Random.Range(1f, 5f);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);

        float x = Random.Range(35f, 35f);
        float y = Random.Range(.01f, .03f);
        float z = Random.Range(35f, 35f);



        int r = Random.Range(0, 2);
        ud = 1;
        if (r == 0) { ud = -1; }

        r = Random.Range(0, 2);
        rl = 1;
        if (r == 0) { rl = -1; }

        r = Random.Range(0, 2);
        fb = 1;
        if (r == 0) { fb = -1; }

        gameObject.transform.Translate(x * rl * (m + 1), y * ud, z * fb * (m + 1));
        rb.AddForce(transform.up * Random.Range(.1f, .15f) * rb.mass * ud, ForceMode.Impulse);
        rb.AddForce(transform.right * Random.Range(.1f, .2f) * rb.mass * rl, ForceMode.Impulse);
        rb.AddForce(transform.forward * Random.Range(.1f, .2f) * rb.mass, ForceMode.Impulse);
        mat = GetComponent<MeshRenderer>().material = gm.mat[Random.Range(1, 3)];
    }

    private void FixedUpdate()
    {
        mat.mainTextureOffset = new Vector2(
            mat.mainTextureOffset.x + (Time.fixedDeltaTime * speed * rl),
            mat.mainTextureOffset.y + (Time.fixedDeltaTime * speed * ud));
    }
}
