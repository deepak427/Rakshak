using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public GameObject start_dialog;
    public GameObject dialogBox;
    public float speed=4.5f;
    private Rigidbody2D body;
    private Animator anim;
    Vector2 movement;
    private bool moving;
    float deltaX;
    float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        body=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaX=Input.GetAxis("Horizontal");
        deltaY=Input.GetAxis("Vertical");
        movement=new Vector2(deltaX,deltaY);
        movement.Normalize();
        body.velocity=movement*speed;
        Animate();
        
    }
    void Animate(){
        if(movement.magnitude>0.1f||movement.magnitude<-0.1f){
            moving=true;
        }
        else{
            moving=false;
        }
        if(moving){
        anim.SetFloat("speed(vertical)",deltaY);
        anim.SetFloat("speed(horizontal)",deltaX);
        }
        anim.SetBool("Moving",moving);
    }
    void OnTriggerEnter2D(){
        start_dialog.SetActive(true);
        dialogBox.SetActive(true);
    }
    void OnTriggerExit2D(){
        start_dialog.SetActive(false);
        dialogBox.SetActive(false);
    }

}
