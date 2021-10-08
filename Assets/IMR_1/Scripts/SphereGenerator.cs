using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    public float radius = 1f;
    public float numberOfSpheres = 10;
    public GameObject sphere;

    public List<GameObject> spheres;

    private void Start()
    {
        spheres = new List<GameObject>();
        for(int i=0; i < numberOfSpheres; i++)
        {
            GameObject go = Instantiate(sphere, transform);
            float randomX = Random.Range(-numberOfSpheres, numberOfSpheres);
            float randomZ = Random.Range(-numberOfSpheres, numberOfSpheres);
            go.transform.localPosition = new Vector3(randomX, 0, randomZ);
            go.transform.localScale = new Vector3(1, 1, 1) * Random.Range(0.5f, 1);

            go.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Random.Range(0, 2) == 0 ? Color.white : Color.black;
            spheres.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        foreach(GameObject sphere in spheres)
        {
            sphere.transform.Rotate(Vector3.up, 50f * time);
        }
    }
}
