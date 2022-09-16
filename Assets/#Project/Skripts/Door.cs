using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    
    [HideInInspector] public LevelManager manager;
    [HideInInspector] public bool isOpen = false;
    private Animator animator;
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            manager.DoorIsReached();
        }
    }
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void Opening() {
        isOpen = true;
        animator.SetBool( "doorIsOpen", true); 
    }
    void Update()
    {
        
    }
}
    


