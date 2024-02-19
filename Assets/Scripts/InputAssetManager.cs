using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssetManager : MonoBehaviour
{
  [SerializeField] InputActionAsset inputAsset;

    void Awake(){
        inputAsset.Enable();
    }

    void OnDestroy(){
        inputAsset.Disable();
    }
}
