using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YouWin : MonoBehaviour
{
    public Text Youwin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player")) {
            Youwin.enabled=true;
        }
    }
}
