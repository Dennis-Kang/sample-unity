using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (collisionObject.transform.tag.Equals("Ground"))
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
