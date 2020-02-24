using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float spd = 1f;
    public GameObject manager;
    Animator animator;

    Vector3 currentEulerAngles;
    Quaternion currentRotation;

    public float jumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,100.0f)) {
                GameObject box = hit.collider.gameObject;
                if (box.tag == "breakable") {
                    Debug.Log("break");
                    Destroy(box);
                }

                if (box.tag == "coin") {
                    manager.GetComponent<Manager>().increaseCoins();
                }
            }
        }*/

        if (Input.GetKey(KeyCode.Space) && Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.y) < 0.05f) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        float moveValue = Input.GetAxis("Horizontal");

        //Vector3 newPos = gameObject.transform.position;
        //newPos += new Vector3(moveValue * moveMultiply,0,0);

        //gameObject.transform.position = newPos;
        //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right);

        currentEulerAngles = new Vector3(0,0,0);

        if (moveValue > 0f){
            currentEulerAngles[1] = 90;
            currentRotation.eulerAngles = currentEulerAngles;
            gameObject.transform.rotation = currentRotation;

            moveRight();
        }else if (moveValue < 0f) {
            currentEulerAngles[1] = -90;
            currentRotation.eulerAngles = currentEulerAngles;
            gameObject.transform.rotation = currentRotation;

            moveLeft();
        }
           
        animator.SetFloat("Blend", Mathf.Abs(moveValue));
    }

    private void moveRight()
    {
        gameObject.transform.position += new Vector3(spd,0,0);
    }

    private void moveLeft()
    {
        gameObject.transform.position -= new Vector3(spd, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "breakable") {
            manager.GetComponent<Manager>().addScore(100);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "coin") {
            manager.GetComponent<Manager>().addScore(100);
            manager.GetComponent<Manager>().increaseCoins();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "avoid")
        {
            manager.GetComponent<Manager>().addScore(-10);
        }

        if (collision.gameObject.tag == "goal")
        {
            manager.GetComponent<Manager>().addScore(100);
            Debug.Log("You Win!");
        }
    }
}
