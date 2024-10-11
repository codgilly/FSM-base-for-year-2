using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {
        private float _horizontalInput;
        public float speed = 4;


        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }





        public override void Enter()
        {
            base.Enter();

            speed = 4;
        }

        public override void Exit()
        {
            base.Exit();

        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            Walking();

            base.LogicUpdate();
            player.CheckForIdle();
            Debug.Log("checking for idle");
            player.CheckForJump();
            Debug.Log("checking for jump");
        }

        void Walking()
        {
            player.anim.SetBool("run", true);

            if (Input.GetKey("right") == true)
            {
                player.rb.velocity = new Vector2(speed, player.rb.velocity.y);
                player.sr.flipX = false;

            }
            if (Input.GetKey("left") == true)
            {
                player.rb.velocityX = -speed;
                player.sr.flipX = true;

            }
        }

        void DoneWalking()
        {
            if (Input.GetKey("right") == false || Input.GetKeyUp("right"))
            {
                player.anim.SetBool("run", false);
            }
            if (Input.GetKey("left") == false || Input.GetKeyUp("left"))
            {
                player.anim.SetBool("run", false);
            }
        }

        public override void PhysicsUpdate()
        {
            


            base.PhysicsUpdate();
        }

    }
}