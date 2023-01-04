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
    public bool e_pressed;

    public bool w_released;
    public bool a_released;
    public bool s_released;
    public bool d_released;
    public bool e_released;

    public bool w;
    public bool a;
    public bool s;
    public bool d;
    public bool e;
    #endregion

    #region Misc
    public bool left_shift_pressed;
    public bool right_shift_pressed;
    public bool enter_pressed;
    public bool tab_pressed;
    public bool left_control_pressed;
    public bool right_control_pressed;

    public bool left_shift_released;
    public bool right_shift_released;
    public bool enter_released;
    public bool tab_released;
    public bool left_control_released;
    public bool right_control_released;

    public bool left_shift;
    public bool right_shift;
    public bool enter;
    public bool tab;
    public bool left_control;
    public bool right_control;
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
        e = Input.GetKey(KeyCode.E);

        left_shift = Input.GetKey(KeyCode.LeftShift);
        right_shift = Input.GetKey(KeyCode.RightShift);
        enter = Input.GetKey(KeyCode.Return);
        tab = Input.GetKey(KeyCode.Tab);
        left_control = Input.GetKey(KeyCode.LeftControl);
        right_control = Input.GetKey(KeyCode.RightControl);


        //Pressed
        w_pressed = Input.GetKeyDown(KeyCode.W);
        a_pressed = Input.GetKeyDown(KeyCode.A);
        s_pressed = Input.GetKeyDown(KeyCode.S);
        d_pressed = Input.GetKeyDown(KeyCode.D);
        e_pressed = Input.GetKeyDown(KeyCode.E);

        left_shift_pressed = Input.GetKeyDown(KeyCode.LeftShift);
        right_shift_pressed = Input.GetKeyDown(KeyCode.RightShift);
        enter_pressed = Input.GetKeyDown(KeyCode.Return);
        left_control_pressed = Input.GetKeyDown(KeyCode.LeftControl);
        right_control_pressed = Input.GetKeyDown(KeyCode.RightControl);

        //Released
        w_released = Input.GetKeyUp(KeyCode.W);
        a_released = Input.GetKeyUp(KeyCode.A);
        s_released = Input.GetKeyUp(KeyCode.S);
        d_released = Input.GetKeyUp(KeyCode.D);
        e_released = Input.GetKeyUp(KeyCode.E);

        left_shift_released = Input.GetKeyUp(KeyCode.LeftShift);
        right_shift_released = Input.GetKeyUp(KeyCode.RightShift);
        enter_released = Input.GetKeyUp(KeyCode.Return);
        left_control_released = Input.GetKeyUp(KeyCode.LeftControl);
        right_control_released = Input.GetKeyUp(KeyCode.RightControl);
    }
}
