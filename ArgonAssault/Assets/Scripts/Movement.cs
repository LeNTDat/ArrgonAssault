using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [Header("General settings")]
    [Tooltip("Speed of the ship")]public int speed = 10;
    [Tooltip("Max X range the ship can fly")][SerializeField] float maxScreenX;
    [Tooltip("Max Y range the ship can fly")][SerializeField] float maxScreenY;
    [Tooltip("How high ship reach")][SerializeField] float pitchFactor;
    [Tooltip("Speed of the ship")][SerializeField] float YawPositionFactor;
    [Tooltip("Speed of the ship")][SerializeField] float pitchPositionFactor;
    [Tooltip("Speed of the ship")][SerializeField] float rollPositionFactor;
    [Tooltip("The arrays of lasers appear on ship")][SerializeField] GameObject[] laser;

    float inputX, inputY;
  
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isgameOver)
        {
            ProgressFiring();
            ProgressMovement();
            ProgressRotation();
        }
    }

    private void FixedUpdate()
    {
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
                ActiveShotting(true);
            }
            else
            {
                ActiveShotting(false);
            }
    }

    void ActiveShotting(bool isActive) {
        foreach (var item in laser)
        {
           var emission = item.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;
        }
    }
}
