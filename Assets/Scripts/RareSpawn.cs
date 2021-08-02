using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareSpawn : MonoBehaviour
{
    public GameObject bonusObjClick;

    void Start()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(0, 2000), 3000);
        Vector3 newPosition = transform.position;
 
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1 * Time.deltaTime * 500, 0);
        if (transform.position.y <= -1000) { Destroy(gameObject); }
    }

    public void pressed()
    {
        Instantiate(bonusObjClick, new Vector3(0, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
