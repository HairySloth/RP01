using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject heldObj;
    public float pickUpRange = 5;
    public Transform holdParent;
    public float moveForce = 150;

    // Update is called once per frame



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                LayerMask mask = LayerMask.GetMask("PickUp", "Animal");

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, mask))
                {
                    if(hit.transform.gameObject.tag != "Finish")
                    {
                     PickUpObject(hit.transform.gameObject);

                    }
                }
            } 
            else
            {
                DropObject();
            }
        }

        if (heldObj != null)
        {
            MoveObject();
            //print(Vector3.Distance(heldObj.transform.position, holdParent.position));
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.05f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * (moveForce*Time.deltaTime));
            //print(Vector3.Distance(heldObj.transform.position, holdParent.position));
            heldObj.transform.rotation = new Quaternion(0, 0, 0, 0);
            
        }
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 3f)
        {
            DropObject();
        }
    }


    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            Collider collider = pickObj.GetComponent<MeshCollider>();
            collider.enabled = false;
            objRig.useGravity = false;
            objRig.drag = 10;
            objRig.transform.parent = holdParent;
            objRig.constraints = RigidbodyConstraints.FreezeRotation;
            heldObj = pickObj;

        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        Collider collider = heldObj.GetComponent<MeshCollider>();
        heldRig.useGravity = true;
        collider.enabled = true;
        heldRig.drag = 1;
        heldObj.transform.parent = null;
        heldObj = null;
        heldRig.constraints = RigidbodyConstraints.None;
    }
}
