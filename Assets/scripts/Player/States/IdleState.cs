
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {
        RunningState rs;
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.SetBool("run", false);
            //rs.speed = 0;
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
            player.CheckForRun();
            Debug.Log("checking for run");
            player.CheckForJump();
            Debug.Log("checking for jump");
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}