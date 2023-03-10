using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bugPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AutoSpawn()
    {
        while(true)
        {
            GameObject spawnObject = Instantiate<GameObject>(bugPrefab,
                                                             new Vector3(Random.Range(-9.5f, 9.5f),
                                                             transform.position.y, 0f),
                                                             Quaternion.identity,
                                                             transform);

            Shoot(spawnObject);
            RandomScale(spawnObject);

            yield return new WaitForSeconds(0.5f);
        }
    }

    void Shoot(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-200, 200f), 0));
    }

    void RandomScale(GameObject obj)
    {
        float scale = Random.Range(0.35f, 1.3f);
        obj.transform.localScale = new Vector3(scale, scale, 1f);
    }
}
