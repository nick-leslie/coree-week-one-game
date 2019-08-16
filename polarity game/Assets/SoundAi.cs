using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAi : MonoBehaviour
{
    public  float TimeTillInvestagate;
    public float maxTimeTillInvestagate;
    public bool B_Investagate;
    public Vector3 suspisiospos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("interactable"))
        {
            if (other.GetComponent<interactableStats>().ismoving == true)
            {
                if (TimeTillInvestagate >= maxTimeTillInvestagate)
                {
                    B_Investagate = true;
                    suspisiospos = other.transform.position;
                    TimeTillInvestagate = 0;
                }
                else
                {
                    TimeTillInvestagate += Time.deltaTime;
                }
            }
            else
            {
                TimeTillInvestagate = 0;
            }
        }
    }
}
