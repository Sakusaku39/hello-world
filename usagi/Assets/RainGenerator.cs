using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour {

    public GameObject rainPrefab;

    void Start()
    {
        InvokeRepeating("Rain", 1, 1);
    }

    void Rain()
    {
        Instantiate(rainPrefab, new Vector3(-2.5f + 10 * Random.value, 10, 0), Quaternion.identity);
    }
}
