using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player 
{
    public class JumpState : State
    {
        public float jumpPower = 10f;
        int jumpCount = 0;
        public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.SetBool("run", false);
            player.anim.SetBool("jump_up", true);
        }

        public override void Exit()
        {
            player.anim.SetBool("jump_up", false);

            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.CheckForIdle();
            Debug.Log("checking for idle");
            player.CheckForRun();
            Debug.Log("checking for run");

            DoJump();
        }

        void DoJump()
        {
            if (jumpCount == 0)
            {
                player.rb.velocity = new Vector2(player.rb.velocity.x, jumpPower);
                jumpCount++;
            }

            if (player.grounded == true)
            {
                jumpCount = 0;

            }

            
        }

       
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}



