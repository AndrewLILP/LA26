using UnityEngine;
using LandyAcademy.Core.Interfaces;
using StarterAssets;

namespace LandyAcademy.Core.Systems
{
    /// <summary>
    /// Detects nearby interactable objects and handles interaction input.
    /// Single Responsibility: Only handles detection and triggering interactions.
    /// Attach this to the Player GameObject.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class InteractionDetector : MonoBehaviour
    {
        [Header("Detection Settings")]
        [Tooltip("How far the player can interact with objects")]
        [SerializeField] private float interactionRadius = 2.5f;
        
        [Tooltip("Layer mask for interactable objects")]
        [SerializeField] private LayerMask interactableLayer;
        
        [Header("References")]
        [Tooltip("Reference to the UI system that displays prompts")]
        [SerializeField] private InteractionUI interactionUI;
        
        // Current interactable the player is near
        private IInteractable _currentInteractable;
        private GameObject _currentInteractableObject;
        
        // Reference to input system
        private StarterAssetsInputs _input;
        
        // Cooldown to prevent spam
        private float _interactionCooldown = 0f;
        private const float COOLDOWN_TIME = 0.3f;

        private void Awake()
        {
            _input = GetComponent<StarterAssetsInputs>();
            
            if (interactionUI == null)
            {
                Debug.LogError("InteractionDetector: InteractionUI reference is missing! Please assign it in the Inspector.");
            }
        }

        private void Update()
        {
            DetectNearbyInteractables();
            HandleInteractionInput();
            UpdateCooldown();
        }

        /// <summary>
        /// Continuously checks for interactable objects within range.
        /// Uses Physics.OverlapSphere for efficient detection.
        /// </summary>
        private void DetectNearbyInteractables()
        {
            // Find all colliders in range
            Collider[] hitColliders = Physics.OverlapSphere(
                transform.position, 
                interactionRadius, 
                interactableLayer
            );

            IInteractable closestInteractable = null;
            GameObject closestObject = null;
            float closestDistance = float.MaxValue;

            // Find the closest interactable
            foreach (Collider collider in hitColliders)
            {
                if (collider.TryGetComponent<IInteractable>(out var interactable))
                {
                    if (interactable.CanInteract())
                    {
                        float distance = Vector3.Distance(transform.position, collider.transform.position);
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestInteractable = interactable;
                            closestObject = collider.gameObject;
                        }
                    }
                }
            }

            // Update current interactable
            if (closestInteractable != _currentInteractable)
            {
                OnInteractableChanged(closestInteractable, closestObject);
            }
        }

        /// <summary>
        /// Called when the player enters/exits range of an interactable.
        /// </summary>
        private void OnInteractableChanged(IInteractable newInteractable, GameObject newObject)
        {
            // Exit old interactable
            if (_currentInteractable != null)
            {
                interactionUI?.HidePrompt();
            }

            // Enter new interactable
            _currentInteractable = newInteractable;
            _currentInteractableObject = newObject;

            if (_currentInteractable != null)
            {
                string promptText = _currentInteractable.GetPromptText();
                interactionUI?.ShowPrompt(promptText);
            }
        }

        /// <summary>
        /// Checks for interact button press and triggers interaction.
        /// </summary>
        private void HandleInteractionInput()
        {
            if (_currentInteractable == null) return;
            if (_interactionCooldown > 0f) return;

            // Check for interact input (we'll add this to StarterAssetsInputs)
            if (_input.interact)
            {
                if (_currentInteractable.CanInteract())
                {
                    _currentInteractable.OnInteract(gameObject);
                    _interactionCooldown = COOLDOWN_TIME;
                    
                    // Reset input
                    _input.interact = false;
                }
            }
        }

        /// <summary>
        /// Updates the interaction cooldown timer.
        /// </summary>
        private void UpdateCooldown()
        {
            if (_interactionCooldown > 0f)
            {
                _interactionCooldown -= Time.deltaTime;
            }
        }

        /// <summary>
        /// Visualize interaction radius in Scene view (helpful for debugging).
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _currentInteractable != null ? Color.green : Color.yellow;
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }
}
