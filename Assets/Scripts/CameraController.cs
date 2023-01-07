using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Player References
    PlayerController player_controller;
    Transform player_transform;

    // Locals
    Vector3 target_position;

    // Getter Setters
    public float distance_from_player { get; set; }
    float move_speed { get; set; }

    private void Awake() {
        // Check if already exists, delete if it does
        if(Public.CameraControls != null) {
            Destroy(gameObject);
            return;
        }

        // Save to Public
        Public.CameraControls = this;

        // Grab player reference
        GetPlayerReference();
    }

    private void Update() {
        // Return Early If Player Is Null
        if(player_controller == null) return;

        // Set target position
        SetPositionToPlayer();
    }

    void SetPositionToPlayer() {
        // Set target position
        Vector3 _player_position = player_transform.position;
        Vector3 _target = new Vector3();
    }

    void GetPlayerReference() {
        // This loops in case the player reference hasn't been created yet

        // Check if player reference exists
        if(Public.Player == null) {
            Invoke("GetPlayerReference", Time.deltaTime);
            return;
        } else {
            player_controller = Public.Player;
            player_transform = player_controller.transform;
        }
    }
}
