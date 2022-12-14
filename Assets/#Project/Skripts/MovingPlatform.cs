using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Vector 0,1
    public Vector2 translation = Vector2.up; 
    [Range(0f,10f)]
    public float timeToMove = 1f;
    private bool reverse = false;
    private Vector3 start;
    private Vector3 end;

    
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = transform.position + (Vector3)translation;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    private IEnumerator Move(){
        float time = 0f;
        float ratio = 0f;
        while(true){

            while (ratio < 1){
                time += Time.deltaTime;
                ratio = time/timeToMove;
                
                if(reverse) transform.position = Vector3.Lerp(end, start, ratio);
                else transform.position = Vector3.Lerp(start, end, ratio);
                yield return null;
            }
            time = 0;
            ratio = 0;
            reverse =! reverse; 
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.parent = null;
        }
    }
    private void OnDrawGizmos(){
        Collider2D collider = GetComponent<BoxCollider2D>();
        Gizmos.color = Color.red;
        Gizmos.DrawCube(collider.bounds.center + (Vector3) translation, collider.bounds.size);
    }    
}   

