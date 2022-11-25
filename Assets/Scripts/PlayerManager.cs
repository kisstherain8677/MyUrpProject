using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace kass
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        CameraHandler cameraHandler;
        PlayerLocomation playerLocomation;
        Animator anim;

        public bool isInteracting;

        [Header("Player Flags")]
        public bool isSprinting;

     

        // Start is called before the first frame update
        void Start()
        {
            cameraHandler = CameraHandler.singleton;
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponent<Animator>();
            playerLocomation = GetComponent<PlayerLocomation>();
        }


        

        // Update is called once per frame
        void Update()
        {
            isInteracting = anim.GetBool("IsInteracting");
           

            float delta = Time.deltaTime;
      
            inputHandler.TickInput(delta);

            playerLocomation.HandleMovement(delta);
            playerLocomation.HandleRollingAndSrinting(delta);
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }
        }

        private void LateUpdate()
        {
            inputHandler.rollFlag = false;
            inputHandler.sprintFlag = false;
            isSprinting = inputHandler.b_Input;
        }



    }

}
