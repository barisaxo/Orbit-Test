using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public GM gm;
    // Start is called before the first frame update
    void Start()
    {

        Camera cam = new GameObject("Camera").AddComponent<Camera>();
        gm.cam = cam;
        //Camera cam = new GameObject("Camera").AddComponent<Camera>();
        cam.transform.SetParent(gameObject.transform);
        cam.transform.position = cam.transform.parent.position;
        cam.transform.Translate (0, 0, 100);
        cam.transform.LookAt(gameObject.transform);
        cam.transform.Translate(0, 10, 0);

        //cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.x, cam.transform.rotation.y, cam.transform.rotation.z);
        cam.orthographic = false;
       // cam.orthographicSize = 50;
        cam.farClipPlane = 10000;
        cam.usePhysicalProperties = true;
        cam.focalLength = 50;
        cam.fieldOfView = 50;
        //cam.clearFlags = CameraClearFlags.SolidColor;
        //cam.backgroundColor = new Color(Random.Range(.1f, .15f),
        //	Random.Range(.12f, .2f), Random.Range(.1f, .15f), 1f);



    }

}
