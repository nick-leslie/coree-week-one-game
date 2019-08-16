using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Push : MonoBehaviour
{
    public GameObject child;
    public float bacePushForce;
    public float PushForce;
    public float maxPushForce;
    public RaycastHit hit;
    public Camera camera;
    //----------------------
    //UI stuff
    public Image forceBarBack;
    public Image forcebar;
    //---------------------
    //descaling pervention
    public Vector3 scale;
    public Vector3 dif;
    // Start is called before the first frame update
    void Start()
    {
        PushForce=bacePushForce;
        camera=Camera.main;
        UIHandler(false,0);
        scale=transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
      //  if(transform.localScale != scale) { 
        //    dif= transform.localScale-scale;
          //  transform.localScale+=dif;
        //}
       pusing();
    }
    private void pusing() {
        if(child != null) {
         if(Input.GetMouseButton(1)) {
             if (PushForce < maxPushForce) {
            PushForce++;
            UIHandler(true,PushForce);
             }
        }
        if(Input.GetMouseButtonUp(1)) {
            UIHandler(false,0);
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
    private void UIHandler(bool state,float fillamount) {
         forceBarBack.enabled=state;
         forcebar.enabled=state;
         forcebar.fillAmount=fillamount/maxPushForce;

    }
     private void OnTriggerEnter(Collider other) {
         if(other.CompareTag("interactable")) {
        child=other.gameObject;
        child.GetComponent<Rigidbody>().velocity=Vector3.zero;
        child.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionY;
         }
    }
        
}
