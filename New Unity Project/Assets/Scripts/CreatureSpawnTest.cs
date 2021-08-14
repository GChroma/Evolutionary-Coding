using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawnTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    void Start()
    {
        Instantiate(prefab, new Vector3(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
