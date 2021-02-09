using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsagiController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 780.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // Use this for initialization
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //walk
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * walkForce);
        }

        //動く方向反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //アニメーション速度
        this.animator.speed = speedx / 2.0f;

        //画面外
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    //フラッグ獲得
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mogura")
        {
            SceneManager.LoadScene("GameScene");
        }
        if (other.gameObject.tag == "Frag")
        {
            Debug.Log("Finish!!");
            SceneManager.LoadScene("ClearScene");
        }
    }
}
    

