using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableStats : MonoBehaviour
{
  public float velocity;
  public float stunTime;
  public int Damage;

   private void Update() {
      velocity=gameObject.GetComponent<Rigidbody>().velocity.magnitude;
  }
}
