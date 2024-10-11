using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;

        public bool grounded = false;

        public SpriteRenderer sr;

        public Animator anim;

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpState jumpState;
        public FallingState fallingState;

        [HideInInspector]
        public StateMachine sm;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            jumpState = new JumpState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();


        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press I for idle / R for run / J for jump");

            //Debug.Log(grounded);

        }


       

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag ("Ground"))
            {
                grounded = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Ground"))
            {
                grounded = false;
            }
        }
       




        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public void CheckForRun()
        {
            if (Input.GetKey("left") && grounded == true || Input.GetKey("right") && grounded == true) // key held down
            {
                sm.ChangeState(runningState);
                anim.Play("run_anim");
                return;
            }

        }


        public void CheckForIdle()
        {
            if (Input.GetKey("right") == false && Input.GetKey("left") == false)
            {
                sm.ChangeState(idleState);
            }
            
            if (Input.GetKey("i") ) // key held down
            {
                sm.ChangeState(idleState);
            }

            

        }

        public void CheckForJump()
        {
            if(Input.GetKey("space") && grounded == true)
            {
                sm.ChangeState(jumpState);
            }
        }

       public void CheckForFalling()
        {
            if(rb.velocity.y < Mathf.Epsilon)
            {
                print("falling");
            }
        }

    }

}