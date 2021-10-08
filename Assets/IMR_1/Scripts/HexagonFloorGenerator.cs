using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonFloorGenerator : MonoBehaviour
{
    public float speed = 0.5f;
    public float offset = 0.5f;
    public int floorSize = 10;
    public GameObject floorTilePrefab;

    private List<GameObject> floorTiles;
    void Start()
    {
        floorTiles = new List<GameObject>();
        for (int i = 0; i < floorSize; i++)
        {
            for (int j = 0; j < floorSize; j++)
            {
                GameObject go = Instantiate(floorTilePrefab, transform);
                float x = i - 0.25f * i;
                float z = i % 2 == 0 ? j + 0.5f : j;

                x -= floorSize / 2.0f;
                z -= floorSize / 2.0f;

                go.transform.position = new Vector3(x, 0, z);

                go.transform.Find("hexagon").GetComponent<MeshRenderer>().material.color = (i + j) % 2 == 0 ? Color.white : Color.black;
                floorTiles.Add(go);
            }
        }

    }

    void Update()
    {
        int idx = 0;
        foreach(GameObject go in floorTiles)
        {
            go.transform.rotation = Quaternion.Euler(Time.time * speed + idx*offset, 0, 0);
            idx++;
        }
    }
}
