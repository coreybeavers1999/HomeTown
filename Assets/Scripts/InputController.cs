using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    #region Movement
    public bool w_pressed;
    public bool a_pressed;
    public bool s_pressed;
    public bool d_pressed;

    public bool w_released;
    public bool a_released;
    public bool s_released;
    public bool d_released;

    public bool w;
    public bool a;
    public bool s;
    public bool d;
    #endregion

    void Update() {
        Movement();
    }

    void Movement() {
        //Held
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        s = Input.GetKey(KeyCode.S);
        d = Input.GetKey(KeyCode.D);

        //Pressed
        w_pressed = Input.GetKeyDown(KeyCode.W);
        a_pressed = Input.GetKeyDown(KeyCode.A);
        s_pressed = Input.GetKeyDown(KeyCode.S);
        d_pressed = Input.GetKeyDown(KeyCode.D);

        //Released
        w_released = Input.GetKeyUp(KeyCode.W);
        a_released = Input.GetKeyUp(KeyCode.A);
        s_released = Input.GetKeyUp(KeyCode.S);
        d_released = Input.GetKeyUp(KeyCode.D);
    }
}
