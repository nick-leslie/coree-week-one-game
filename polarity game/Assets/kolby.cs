using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolby : MonoBehaviour
{
    public GameObject swish;
    // Start is called before the first frame update
    void Start()
    {
        swish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
 private void OnTriggerEnter(Collider other) {
        swish.SetActive(true);
    }
}
