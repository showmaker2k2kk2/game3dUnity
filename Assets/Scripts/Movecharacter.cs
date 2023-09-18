using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecharacter : MonoBehaviour
{
    public VariableJoystick joyStick;
    public Canvas inputCanvas;
    public bool isjoyStick;
    public CharacterController controler;
    public float moveSpeed;
    public float rotationSpeed;



    void Start()
    {
        EnableJoyStick();
    }

    // Update is called once per frame

    public void EnableJoyStick()
    {
        isjoyStick= true;
        inputCanvas.gameObject.SetActive(true);    
    }
    private void Update()   
    {
        if (isjoyStick) 
        {
            var movementDirection = new Vector3(joyStick.Direction.x, 0, joyStick.Direction.y);
            controler.SimpleMove(movementDirection*moveSpeed);
            if (movementDirection.sqrMagnitude <= 0)
            {
                return;
            }
            var targetDirection = Vector3.RotateTowards(controler.transform.forward, movementDirection, rotationSpeed * Time.deltaTime, 0f);
            controler.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}
