using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerController : MonoBehaviour {
    
    [SerializeField] float walk_speed;

    //Private Variables
    GameObject self;
    Transform self_transform;
    Animator self_animator;

    private void Awake() {
        //Grab Local References
        self = gameObject;
        self_transform = transform;
        self_animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        //Process Inputs
        Movement();
    }

    void Movement() {
        //Get Base Values
        int _upSpeed = Public.Controls.w ? 1 : 0;
        int _downSpeed = Public.Controls.s ? 1 : 0;
        int _leftSpeed = Public.Controls.a ? 1 : 0;
        int _rightSpeed = Public.Controls.d ? 1 : 0;

        //Calculate Speeds
        float _xSpeed = System.Convert.ToSingle(_rightSpeed - _leftSpeed) * walk_speed;
        float _zSpeed = System.Convert.ToSingle(_upSpeed - _downSpeed) * walk_speed;

        //Animator
        bool _walking = false;
        if(_xSpeed != 0 || _zSpeed != 0) _walking = true;
        self_animator.SetBool("walking", _walking);

        //Physically Moving
        Vector3 position = self_transform.position;
        position.x += _xSpeed * Time.deltaTime;
        position.z += _zSpeed * Time.deltaTime;
        self_transform.position = position;
    }


}