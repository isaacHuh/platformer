using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float spd = 1f;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        }

        bool keyRight = Input.GetKey(KeyCode.D);
        bool keyLeft = Input.GetKey(KeyCode.A);

        if (keyRight)
        {
            moveRight();
        }

        if (keyLeft)
        {
            moveLeft();
        }
    }

    private void moveRight()
    {
        gameObject.transform.position += new Vector3(spd,0,0);
    }

    private void moveLeft()
    {
        gameObject.transform.position -= new Vector3(spd, 0, 0);
    }
}
