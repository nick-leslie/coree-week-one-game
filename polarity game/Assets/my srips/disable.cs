using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable : MonoBehaviour
{
    public float timing;
    public bool onetime=true;
     public float time;
 private void Update() {
     disableing();
   }
    private void disableing() {
        if(onetime==true) {
       time+=Time.deltaTime;
       if (time>timing) {
           gameObject.SetActive(false);
            onetime=true;
            time=0;
       }
      
     }
        
    }
    
}
