using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public enum JumpState
    {
        Grounded,
        Jumping,
        Falling,
    }

    public class CatJump : CharacterJump2D
    {
        [SerializeField]
        Vector2 jumpForce = new Vector2(1000f, 1000f);

        private bool isFacingRight = true;
        private JumpState jumpstate;
        private CharacterOrientation2D _characterOrientation2D;

        protected override void Start()
        {
            _characterOrientation2D = GetComponent<CharacterOrientation2D>();

            base.Start();
        }

        public override void JumpStart()
        {
            jumpstate = JumpState.Jumping;

            isFacingRight = _characterOrientation2D.IsFacingRight;

            float directionalXForce = jumpForce.x * (isFacingRight ? 1 : -1);

            _controller.AddForce(new Vector3(directionalXForce, jumpForce.y, 0f));

            base.JumpStart();
        }
    }
}
