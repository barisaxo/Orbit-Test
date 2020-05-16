using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int width, height, depth, rightLeft, upDown, forwardBack;
    public GM gm;
    Camera cam;
    public string[,,] grid;

    // Start is called before the first frame update
    void Start()
    {
        cam = gm.cam;
        Vector2 screenSize = new Vector2(cam.sensorSize.x, cam.sensorSize.y);
        height = (int)screenSize.x;
        width = height * (Screen.width / Screen.height);

        //rightLeft = Random.Range(25,100); //warning: larger numbers become non-performant
        //upDown = Random.Range(25, 100);
        //forwardBack = Random.Range(25, 100);


        //grid = new string[rightLeft, upDown, forwardBack];
        //for (int x = 0; x < rightLeft; x++)
        //{
        //    for (int y = 0; y < upDown; y++)
        //    {
        //        for (int z = 0; z < forwardBack; z++)
        //        {
        //            grid[x,y,z] = x + ", " + y + ", " + z;
        //            SpawnTile(x, y, z, grid[x,y,z]);
        //        }
        //    }
        //}

        // GameObject gO =  GameObject.CreatePrimitive(PrimitiveType.Sphere);
        SpawnTile(0,0,0,".");
    }

    private void SpawnTile(int x, int y, int z, string xyz)
    {
        // if (x == 0 || x == rightLeft - 1 || y == 0 || y == upDown - 1 || z == 0 || z == forwardBack - 1)

        int rx = Random.Range(-2000, 2000);
        int ry = Random.Range(-2000, 2000);
        int rz = Random.Range(-2000, 2000);

        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = GridToWorldPosition(rx, ry, rz);
        //go.AddComponent<SpriteRenderer>(); 
        go.name = rx + ", " + ry + ", " + rz;
        // go.GetComponent<SpriteRenderer>().sprite = spri;
        // go.transform.SetParent(boardholder);
        //go.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, .5f);
        //go.AddComponent<BoxCollider2D>();

    }
        //for (int i = 0; i < Random.Range(3, 6); i++)
        //{
        //    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    go.transform.position = GridToWorldPosition(rx - i, ry - i, rz - i);
        //    //go.AddComponent<SpriteRenderer>(); 
        //    go.name = rx + i + ", " + ry + i + ", " + i + rz;
        //    // go.GetComponent<SpriteRenderer>().sprite = spri;
        //    // go.transform.SetParent(boardholder);
        //    //go.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, .5f);
        //    //go.AddComponent<BoxCollider2D>();
        //}
    

    private Vector3 GridToWorldPosition(int x, int y, int z)
    {
        return new Vector3(x - (width - 0.5f), y - (height - 0.5f), z - (depth - 0.5f));
    }
}
