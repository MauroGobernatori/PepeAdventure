using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaMovible : MonoBehaviour
{

    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    void Start()
    {
        
    }

    public void grabed()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }

    public void ungrabbed()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }
}
