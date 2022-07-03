using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDoor : MonoBehaviour
{
    public GameObject door;
    public DoorButton btn;



    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {

        door.SetActive(true);
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        btn.getobj(transform.GetChild(0).gameObject.transform.position.x);
        this.gameObject.GetComponent<Animator>().SetBool("Open", true);


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door.SetActive(false);
        this.gameObject.GetComponent<Animator>().SetBool("Open", false);
    }

   


}

