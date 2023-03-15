using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Timer       timerComponent;
    Rigidbody2D rigid;
    Vector2     velocity;
    bool        isDeath;
    bool        isJumpAble = false;
    bool        isJumpTrigger = false;
    float       jumpPower = 300f;

    void Awake()
    {
        timerComponent = gameObject.GetComponent<Timer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal") * 10f;
        velocity.y = rigid.velocity.y;
        rigid.velocity = velocity;
        // transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * 15f);

        if (Input.GetKeyDown(KeyCode.Space) && isJumpAble == true)
        {
            isJumpTrigger = true;
            isJumpAble = false;
        }
    }

    void FixedUpdate()
    {
        if (isJumpTrigger == true)
        {
            rigid.AddForce(Vector2.up * jumpPower);
            isJumpTrigger = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (isDeath == true)
            return;
        
        if (collisionObject.transform.tag.Equals("Bug"))
        {
            StartCoroutine(Rotate());
            StartCoroutine(Die());

            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

            timerComponent.enabled = false;
            
            isDeath = true;
        }
        if (collisionObject.transform.tag.Equals("Ground"))
        {
            isJumpAble = true;
        }
    }

    IEnumerator Die()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150f);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    IEnumerator Rotate()
    {
        while(true)
        {
            transform.Rotate(Vector3.back * 20f);
            yield return null;
        }
    }
}
