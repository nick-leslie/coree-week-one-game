using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //------------------
    //camra
    public Camera playercam;
    private float mouseposX;
    private float Xclamp;
    private float mosueposY;
    public float sensitivity;
    //-------------------
    public CharacterController cc;
    public float movespeed;
    public float moveFB;
    public float moveLR;
    // Start is called before the first frame update
    void Start()
    {
        //---------------
        //camara
        playercam=Camera.main;
        Cursor.lockState=CursorLockMode.Locked;
        Xclamp=0.0f;
        //---------------
        //player stuff
        cc=gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       camraRotation();
       movement();
    }
     private void FixedUpdate() {
        
    }
    //---------------------------------------------------
    // movement stuff
     private void movement() {
     moveFB=Input.GetAxisRaw("Vertical") * movespeed;
     moveLR=Input.GetAxisRaw("Horizontal") * movespeed;
     Vector3 fmoveUD = moveFB * Vector3.forward;
     Vector3 fmoveLR= moveLR * Vector2.right;
     cc.SimpleMove(fmoveUD + fmoveLR);
     }
    //--------------------------------------------------
    //camra stuff
    private void camraRotation() {
       mouseposX=Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
       Xclamp+=mosueposY;
    if(Xclamp > 90.0f) {
        Xclamp=90.0f;
        mosueposY=0.0f;
     clampXRotToVal(270.0f);
    }  else if(Xclamp < -90.0f) {
        Xclamp=-90.0f;
        mosueposY=0.0f;
        clampXRotToVal(90.0f);
    } 
     playercam.transform.Rotate(Vector3.left * mosueposY);

       mosueposY=Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    
       
        transform.Rotate(Vector3.up * mouseposX);
    }
    private void clampXRotToVal(float value) {
        Vector3 eulerRotation =playercam.transform.eulerAngles;
        eulerRotation.x=value;
        playercam.transform.eulerAngles = eulerRotation;
    }
    //----------------------------
}
