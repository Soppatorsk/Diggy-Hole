using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareSpawn : MonoBehaviour
{
    public GameObject buffClicking;

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
        FindObjectOfType<AudioManager>().Play("powerUp");
        System.Random rnd = new System.Random();

        switch (rnd.Next(3))
        {
            case 0:
                Instantiate(ObjectManager.Get().buffClicking, new Vector3(0, 0), Quaternion.identity, ObjectManager.Get().buffDisplay);
                break;
            case 1:
                Instantiate(ObjectManager.Get().buffAutoInc, new Vector3(0, 0), Quaternion.identity, ObjectManager.Get().buffDisplay);
                break;
            case 2:
                Instantiate(ObjectManager.Get().buffGoldReward, new Vector3(0, 0), Quaternion.identity, ObjectManager.Get().buffDisplay);
                break;
            default:
                Instantiate(ObjectManager.Get().buffGoldReward, new Vector3(0, 0), Quaternion.identity, ObjectManager.Get().buffDisplay);
                break;
        }
        Destroy(gameObject);
    }
}
