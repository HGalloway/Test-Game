using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class Startup {
    static Startup()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
}