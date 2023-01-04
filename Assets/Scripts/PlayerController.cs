using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] Item updated_shirt; // This was added to test updating clothes
    [SerializeField] float walk_speed;

    //Private Variables
    GameObject self;
    Transform self_transform;
    Animator self_animator;

    #region Body
    [SerializeField] MeshRenderer render_skin;
    [SerializeField] MeshRenderer render_eyes;
    #endregion

    #region Clothes
    [SerializeField] MeshRenderer render_accessory;
    [SerializeField] MeshRenderer render_hat;
    [SerializeField] MeshRenderer render_pants;
    [SerializeField] MeshRenderer render_shirt;
    [SerializeField] MeshRenderer render_hair;
    #endregion

    void Awake() {
        //Grab Local References
        self = gameObject;
        self_transform = transform;
        self_animator = GetComponentInChildren<Animator>();

        //Store In Public
        Public.Player = this;
        Public.PlayerObject = self;
    }

    void Update() {
        //Process Inputs
        Movement();

        //Debugging
        Debug();
    }

    void Start() {
        UpdateClothes();
    }

    void Debug() {
        if(Public.Controls.e_pressed) {
            Public.State.EquippedShirt = updated_shirt;
        }
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

    public void UpdateClothes() {
        Console.Log("Updating clothes", Console.green);

        //Update Renderer Materials
        render_shirt.material.mainTexture = Public.State.EquippedShirt.sprite;
        render_accessory.material.mainTexture = Public.State.EquippedAccessory.sprite;
        render_pants.material.mainTexture = Public.State.EquippedPants.sprite;

    }

}