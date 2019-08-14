using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public GameObject child;
    public float bacePushForce;
    public float PushForce;
    public float maxPushForce;
    public RaycastHit hit;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        PushForce=bacePushForce;
        camera=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       pusing();
    }
    private void pusing() {
        if(child != null) {
         if(Input.GetMouseButton(1)) {
             if (PushForce < maxPushForce) {
            PushForce++;
             }
        }
        if(Input.GetMouseButtonUp(1)) {
                child.transform.parent=null;
                child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                 var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit)) {
                child.GetComponent<Rigidbody>().velocity=(hit.point-transform.position).normalized * PushForce;
                PushForce=bacePushForce;
                child=null;
        }
            }
        }
    }
     private void OnTriggerEnter(Collider other) {
         if(other.CompareTag("interactable")) {
        child=other.gameObject;
        child.GetComponent<Rigidbody>().velocity=Vector3.zero;
        child.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionY;
         }
    }
        
}
