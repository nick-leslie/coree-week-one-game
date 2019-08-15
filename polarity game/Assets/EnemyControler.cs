using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyControler : MonoBehaviour
{
    //------------------
    //detection
 public Collider sight;
 public bool PlayerInSight;
 public GameObject player;
public bool playerSeen;
public float maxWaitTime;
public float waitTime;
//---------------------
//UI
public Image inZone;
public Image alerted;
//---------------------
//AI 
public NavMeshAgent agent;
public Transform[] wayPoints;
int m_curentwaypointIndex;
public float AIwaitTime;
public float AImaxWaitTime;
//---------------------
// enemy health and dying
public int health;
    // Start is called before the first frame update
    void Start()
    {
       player=GameObject.FindGameObjectWithTag("Player");
       sight=gameObject.GetComponent<SphereCollider>();
       inZone.enabled=false;
       agent.SetDestination(wayPoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        DetectionManinger();
        if(playerSeen==true) {
            agent.isStopped=true;
            gameObject.transform.LookAt(player.transform.position,Vector3.up);
        } else {
            agent.isStopped=false;
        }
           patroling();
    }

private void DetectionManinger() {
    if(PlayerInSight==true) {
          RaycastHit hit;
           Vector3 dire =player.transform.position -transform.position +Vector3.up;
           Ray ray= new Ray(transform.position,dire);
          if(Physics.Raycast(ray,out hit)) {
              if(hit.collider.CompareTag("Player")) {
              if(waitTime>maxWaitTime) {
                  playerSeen=true;
              } else {
                  waitTime+=Time.deltaTime;
                  alerted.fillAmount= waitTime/maxWaitTime;
              }
              } else {
                  waitTime=0;
                  playerSeen=false;
              }
          }
      }
    }
 private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")) {
        inZone.enabled=true;
        PlayerInSight=true;
    }
}
 private void OnTriggerExit(Collider other) {
     if(other.CompareTag("Player")) {
        PlayerInSight=false;
        playerSeen=false;
        inZone.enabled=false;
        alerted.fillAmount=0;
        waitTime=0;
    }
}
public void patroling() {
if(agent.remainingDistance <= agent.stoppingDistance) {
if (AIwaitTime>=AImaxWaitTime) {
    m_curentwaypointIndex= (m_curentwaypointIndex + 1) % wayPoints.Length;
    agent.SetDestination(wayPoints[m_curentwaypointIndex].position);
    AIwaitTime=0;
} else {
    AIwaitTime+=Time.deltaTime;
}
}
}
public void Damage(int damage) {
    
}
}
