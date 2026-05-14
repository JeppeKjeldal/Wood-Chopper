using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool swing;
        public bool slot1;
        public bool slot2;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        private void Start()
        {
            SetCursorState(true);
        }

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        public void OnSwing(InputValue value)
        {
            SwingInput(value.isPressed);
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void OnSlot1(InputValue value)
        {
            slot1 = value.isPressed;
        }

        public void OnSlot2(InputValue value)
        {
            slot2 = value.isPressed;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void SwingInput(bool newSwingState)
        {
            swing = newSwingState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        public void SetCursorState(bool newState)
        {
            // 1. Existing logic: Handle the OS cursor behavior
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;

            // 2. Add these: Sync the visual and the logic
            Cursor.visible = !newState;      // Show mouse if we aren't locked
            cursorInputForLook = newState;   // This is your boolean check for the camera

            // 3. The "Pro" Addition: Kill the drift
            if (!newState)
            {
                // If you are using the Starter Assets or a custom Look script, 
                // reset the X and Y movement values to zero immediately
                // so the camera doesn't keep rotating from buffered input.
                look = Vector2.zero;
            }
        }
    }

}