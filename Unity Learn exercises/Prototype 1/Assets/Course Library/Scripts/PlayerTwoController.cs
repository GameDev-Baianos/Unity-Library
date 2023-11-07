using Cinemachine;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public CinemachineVirtualCamera firstPerson;
    public CinemachineVirtualCamera thirdPerson;

    float moveSpeed = 20.0f;
    float turnSpeed = 15.0f;

    private void OnEnable()
    {
        CameraSwitcher.Register(firstPerson);
        CameraSwitcher.Register(thirdPerson);
        CameraSwitcher.SwitchCamera(thirdPerson);
    }

    private void onDisable()
    {
        CameraSwitcher.Unregister(firstPerson);
        CameraSwitcher.Unregister(thirdPerson);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.down, Time.deltaTime * turnSpeed);
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);

        cameraSwitch();
    }

    void cameraSwitch()
    {
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            if(CameraSwitcher.IsActiveCamera(thirdPerson))
            {
                CameraSwitcher.SwitchCamera(firstPerson);
            }
            else
            {
                CameraSwitcher.SwitchCamera(thirdPerson);
            }
        }
    }
}
