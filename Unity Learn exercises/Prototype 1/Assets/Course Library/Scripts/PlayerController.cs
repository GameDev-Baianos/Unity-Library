using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down, Time.deltaTime * turnSpeed);
        if(Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);

        cameraSwitch();
    }

    void cameraSwitch()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
