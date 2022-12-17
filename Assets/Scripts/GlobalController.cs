using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour
{
    //References
    [SerializeField] InputController InputControllerReference;
    
    //Public Variables
    [HideInInspector] public InputController Controls;

    void Awake() {
        //If global controller already exists, delete this instance
        if(Object.FindObjectsOfType<GlobalController>().Length > 1) {
            Destroy(gameObject);
            return;
        }

        //Set Self In Public
        Public.Globals = this;

        //Make Permanent
        DontDestroyOnLoad(this);
    }

    void OnEnable() {
        //Set listener for OnSceneLoad
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void Update() {
        DebugUpdate();
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        //Debug message
        DebugMessage.Print("Scene Updated", DebugMessage.green);

        //Create Input Controller
        Public.Controls = Instantiate(InputControllerReference, Vector3.zero, transform.rotation);
    }

    void DebugUpdate() {
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Testing Scene");
        }
    }
}
