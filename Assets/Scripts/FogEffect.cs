using UnityEngine;

[ExecuteInEditMode]
public class FogEffect : MonoBehaviour {

    public Material fogMaterial; //The fog material.


    public Camera _camera; //Reference to the camera attached to this gameobject.

    //enable the fog or not.
    private bool _enabled;

    // key cooldown
    private bool _cooldown;

    private void Start() {
        _camera = GetComponent<Camera>();
        if (_camera == null) {
            Debug.LogWarning("Couldn't find a camera attached with this Fog component.");
        }

        // Enable generation of a depth texture
        _camera.depthTextureMode = DepthTextureMode.Depth;
    }

    private void Update() {
        //set keyboard input as Z already
        float fogInput = Input.GetAxis("FogInput"); 

        if (_cooldown) {
            if (fogInput > 0.1f) {
                return;
            } else {
                _cooldown = false;
            }
        }

        if (fogInput > 0.1f) {
            ToggleFog();
            _cooldown = true;
        }
    }

    /// Toggles the fog on or off.
    private void ToggleFog() {
        // Adjust sight radius
        if (_enabled) {
            _camera.farClipPlane = 100f;
        } else {
            _camera.farClipPlane = 5f;
        }
        
        _enabled = !_enabled; // Toggle enabled flag
    }

    // Called after all images are rendered.
    // Used for postprocessing.
    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (_enabled) {
            // Apply fog material onto destination texture
            Graphics.Blit(source, destination, fogMaterial);
        } else {
            Graphics.Blit(source, destination); // Default rendering
        }
    }
}
