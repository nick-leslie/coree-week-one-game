using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedScale : MonoBehaviour
{
   
  public Vector3 FixeScale;
     public GameObject parent;
private void Start() {
         FixeScale=transform.localScale;
     }
     // Update is called once per frame
     void Update () {
         transform.localScale = new Vector3 (FixeScale.x/parent.transform.localScale.x,FixeScale.y*2/parent.transform.localScale.y,FixeScale.z/parent.transform.localScale.z);
 
             }
}
