using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.InputSystem;


public class ManuelTeleport : MonoBehaviour
{
   
   public InputActionReference teleportActionReference; // Teleport eylemi için referans
    public float duration = 1f; // Hareket süresi
    public  XRRayInteractor rayInteractor;

    private void Start()
    {
        // XRRayInteractor bileşenini al
       

        // Input Action dinleyicisini bağla
        teleportActionReference.action.performed += OnTeleportAction;
    }

    private void OnTeleportAction(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        bool hitSomething = rayInteractor.TryGetCurrent3DRaycastHit(out hit);

        if (hitSomething && hit.collider.CompareTag("Floor"))
        {
            // Tıklanan noktanın dünya pozisyonunu al
            Vector3 hitPosition = hit.point;

            // DOTween kullanarak objeyi hareket ettirme işlemi
            transform.DOMove(hitPosition, duration);
        }
    }

    private void OnDisable()
    {
        // Input Action dinleyicisini kaldır
        teleportActionReference.action.performed -= OnTeleportAction;
    }
}
