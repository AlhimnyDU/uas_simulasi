using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculMusuh : MonoBehaviour
{
    public GameObject musuhnya;
    public float spawnRate;
    public float nextSpawn=1f;
    int lkRandom;
    Vector3 lkMusuhMuncul;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lokasi_Musuh();
    }

    public void Lokasi_Musuh()
    {
        Vector3[] lkMusuh = new Vector3[transform.childCount];
        for (int i = 0; i < lkMusuh.Length; i++)
        {
            lkMusuh[i] = transform.GetChild(i).position;
        }
        for (int i = 0; i < lkMusuh.Length; i++)
        {
            lkRandom = Random.Range(0, transform.childCount);
            //transform.GetChild(i).position = lkMusuh[lkRandom];
        }
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;
            lkMusuhMuncul = lkMusuh[lkRandom];
            Instantiate(musuhnya, lkMusuhMuncul, Quaternion.identity);
        }
    }
}
