using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    public int speed = 10;
    [SerializeField] float maxScreenX;
    [SerializeField] float maxScreenY;
    [SerializeField] float pitchFactor;
    [SerializeField] float YawPositionFactor;
    [SerializeField] float pitchPositionFactor;
    [SerializeField] float rollPositionFactor;
    [SerializeField] GameObject[] laser;

    float inputX, inputY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement();
        ProgressFiring();
    }

    private void FixedUpdate()
    {
        ProgressMovement();
        ProgressRotation();
    }

    void ProgressMovement()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        float offSetX = inputX * Time.deltaTime * speed;
        float offSetY = inputY * Time.deltaTime * speed;
        float newInputX = transform.localPosition.x + offSetX;
        float newInputY = transform.localPosition.y + offSetY;

        newInputX = Mathf.Clamp(newInputX, -maxScreenX, maxScreenX);
        newInputY = Mathf.Clamp(newInputY, -maxScreenY, maxScreenY);

        transform.localPosition = new Vector3(newInputX, newInputY, transform.localPosition.z);
       
    }

    void ProgressRotation()
    {
        float pitch = (transform.localRotation.y * pitchFactor) + (inputY * pitchPositionFactor);
        float yaw = transform.localRotation.y + YawPositionFactor;
        float roll = (inputX * rollPositionFactor);

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProgressFiring()
    {
            if (Input.GetButton("Fire1"))
            {
                ActiveShotting();
                print("Shooting");
            }
            else
            {
            DeactiveShotting();
                print("Stop Shooting");
            }
    }

    void ActiveShotting() {
        foreach (var item in laser)
        {
            item.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }

    void DeactiveShotting()
    {
        foreach (var item in laser)
        {
            item.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}
