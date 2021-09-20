using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPortal : MonoBehaviour
{

    public GameObject leftPortal;
    public GameObject rightPortal;
    GameObject mainCamera;


    // Start is called before the first frame update
    void Start(){
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Left Click");
            throwPortal(leftPortal);
        }
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Right Click");
            throwPortal(rightPortal);
        }
    }

    void throwPortal(GameObject portal) {



        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {
            //if (hit.collider.tag == "NoPortal") return; 
            Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
            portal.transform.position = hit.point;
            portal.transform.rotation = hitObjectRotation;
            Debug.Log(hit.point);
            Debug.Log(hit.collider);
        }
    }

}
