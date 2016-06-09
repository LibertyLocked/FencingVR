using UnityEngine;
using System.Collections;
using Valve.VR;

public class GamePad : MonoBehaviour
{
    public EVRButtonId StartGameButton = EVRButtonId.k_EButton_ApplicationMenu;
    public bool MoveCameraRigWithTrackpad = true;
    public float MaxMoveSpeed = 1f;

    SteamVR_TrackedObject trackedObj;
    GameController gameController;
    GameObject cameraRig, cameraHead;

    void Start()
    {
        trackedObj = GetComponentInParent<SteamVR_TrackedObject>();
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        cameraRig = GameObject.Find("[CameraRig]");
        cameraHead = GameObject.Find("Camera (head)");
    }

    void Update()
    {
        var inputDevice = SteamVR_Controller.Input((int)trackedObj.index);
        if (inputDevice.GetPressDown(StartGameButton))
        {
            gameController.Play();
        }

        // Move the camera rig when player presses direction keys
        if (MoveCameraRigWithTrackpad && inputDevice.GetPress(EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            Vector2 touchAxis = inputDevice.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad).normalized;
            Vector3 moveForward = cameraHead.transform.forward * touchAxis.y * MaxMoveSpeed * Time.deltaTime;
            Vector3 sideNormal = -Vector3.Cross(cameraHead.transform.forward, new Vector3(cameraHead.transform.forward.x, 0, cameraHead.transform.forward.z)).normalized;
            Vector3 moveSideways = sideNormal * touchAxis.x * MaxMoveSpeed * Time.deltaTime;
            // Filter out vertical movements
            cameraRig.transform.position += new Vector3(moveForward.x + moveSideways.x, 0, moveForward.z + moveSideways.z);
        }
    }
}
