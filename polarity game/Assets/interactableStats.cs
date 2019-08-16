using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableStats : MonoBehaviour
{
  public float velocity;
  public float stunTime;
  public int Damage;
  public bool ismoving;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update() {
      velocity=gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        if(velocity>0)
        {
            if (gameObject.transform.IsChildOf(player.transform) != true)
            {
                ismoving = true;
            }
        }
        else
        {
            ismoving = false;
        }
    }
}
