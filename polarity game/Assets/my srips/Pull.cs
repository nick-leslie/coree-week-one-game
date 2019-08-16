using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    public float pullspeed;
    public float raydis;
    public float DisTillChild;
    public string interactable;
    public RaycastHit hit;
    public Camera camera;
    public Material hilight;
    public Material defalt;
    public GameObject Tsulection;
    public GameObject childNewPos;
    // Start is called before the first frame update
    void Start()
    {
        camera=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
      raycastingHighlight();
      if(Input.GetMouseButton(0)) {
         pulling();
          
      }
    }

    public void pulling() {
         if(Tsulection != null) {
             Tsulection.GetComponent<Rigidbody>().velocity=Vector3.zero;
          Tsulection.transform.position=Vector3.MoveTowards(Tsulection.transform.position,transform.position,pullspeed * Time.deltaTime);
          if (Vector3.Distance(Tsulection.transform.position,transform.position) < DisTillChild) {
Tsulection.transform.parent=childNewPos.transform;
Tsulection.transform.position=childNewPos.transform.position;
          }
          }
    }
    void raycastingHighlight() {
          if(Tsulection !=null) {
            var sulectionRenderer= Tsulection.GetComponent<Renderer>();
            sulectionRenderer.material=defalt;
            Tsulection=null;
        }
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit)) {
            var sulection = hit.transform;
            if(sulection.CompareTag(interactable)) {
            var sulectionRenderer=sulection.GetComponent<Renderer>();
            if(sulectionRenderer != null) {
                sulectionRenderer.material=hilight;
            }
             Tsulection=sulection.gameObject;
        }
        }
    }
}
