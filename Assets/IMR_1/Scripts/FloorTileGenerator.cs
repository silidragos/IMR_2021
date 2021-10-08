using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTileGenerator : MonoBehaviour
{
    public GameObject tile;
    public int numberOfTiles = 10;
    public float magnitude = 0.2f;
    public float offset = 0.05f;

    List<GameObject> tiles;


    void Start()
    {
        tiles = new List<GameObject>();
        for(int i = 0; i < numberOfTiles; i++)
        {
            for(int j = 0; j < numberOfTiles; j++)
            {
                GameObject go = Instantiate(tile, transform);
                go.transform.position = new Vector3(i - numberOfTiles/2.0f, 0, j - numberOfTiles/2.0f);
                go.transform.Find("square").GetComponent<MeshRenderer>().material.color = (i+j) % 2 == 0 ? Color.black : Color.white;
                tiles.Add(go);
            }
        }
    }

    void Update()
    {
        float time = Time.time;
        int idx = 0;
        foreach (GameObject tile in tiles) 
        {
            Vector3 pos = tile.transform.position;
            tile.transform.position = new Vector3(pos.x, Mathf.Sin(Mathf.Rad2Deg * (time*0.01f + idx * offset)) * magnitude, pos.z);
            idx++;
        }
    }
}
