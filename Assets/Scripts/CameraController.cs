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
    float distance_from_player = 6f;
    float distance_from_player_min = 2f;
    float distance_from_player_max = 20f;
    float distance_from_player_change = 1f;
    float distance_from_player_deadzone = 0.05f;

    // Getter Setters
    public float move_speed { get; set; }

    private void Awake() {
        // Check if already exists, delete if it does
        if(Public.CameraControls != null) {
            Destroy(gameObject);
            return;
        }

        // Save to Public
        Public.CameraControls = this;

        Console.Log("Set Camera");

        // Grab player reference
        GetPlayerReference();

        // TODO: Delete later
        move_speed = 1.5f;
    }

    private void Update() {
        // Return Early If Player Is Null
        if(player_controller == null) return;

        // Clamp values before updating position
        ClampValues();

        // Set target position
        SetPositionToPlayer();
    }

    void ClampValues() {
        // Clamp Camera
        distance_from_player = Mathf.Clamp(distance_from_player, distance_from_player_min, distance_from_player_max);
    }

    void SetPositionToPlayer() {
        // Set target position
        Vector3 _player_position = player_transform.position;
        Vector3 _target = _player_position;
        _target.z -= distance_from_player;
        _target.y += distance_from_player / 2f;

        // Set speed (distance from player multiplied by zoom level)
        float _distance = Vector3.Distance(transform.position, _target);
        float _zoom_multiplier = 1f + ((distance_from_player_max - distance_from_player) * 0.5f);
        float _speed = _distance * move_speed * _zoom_multiplier;

        // Return if distance is less that deadzone
        if(_distance < distance_from_player_deadzone) return;

        // Interpolate Position
        transform.position = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
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
            Console.Log("Got Player For Camera");
        }
    }

    // Public
    public void ZoomIn()  => distance_from_player += distance_from_player_change;
    public void ZoomOut() => distance_from_player -= distance_from_player_change;

}
