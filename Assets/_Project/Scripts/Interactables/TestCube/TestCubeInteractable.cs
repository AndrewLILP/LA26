using UnityEngine;
using LandyAcademy.Core.Interfaces;

namespace LandyAcademy.Interactables.TestCube
{
    /// <summary>
    /// Simple test interactable to validate the interaction system.
    /// Implements IInteractable interface.
    /// 
    /// When interacted with, it changes color and prints a message.
    /// This demonstrates the interaction system working correctly.
    /// </summary>
    public class TestCubeInteractable : MonoBehaviour, IInteractable
    {
        [Header("Interaction Settings")]
        [Tooltip("Text to show in the interaction prompt")]
        [SerializeField] private string promptText = "Press E to interact with cube";
        
        [Tooltip("Can this cube be interacted with?")]
        [SerializeField] private bool canInteract = true;
        
        [Header("Visual Feedback")]
        [Tooltip("Color when not interacted")]
        [SerializeField] private Color defaultColor = Color.white;
        
        [Tooltip("Color after interaction")]
        [SerializeField] private Color interactedColor = Color.green;
        
        // Internal state
        private Renderer _renderer;
        private bool _hasBeenInteracted = false;
        private int _interactionCount = 0;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            
            if (_renderer == null)
            {
                Debug.LogError("TestCubeInteractable: No Renderer component found! Add a Renderer to this GameObject.");
            }
            else
            {
                _renderer.material.color = defaultColor;
            }
        }

        #region IInteractable Implementation

        public string GetPromptText()
        {
            if (_hasBeenInteracted)
            {
                return $"Press E to interact again ({_interactionCount} times)";
            }
            return promptText;
        }

        public void OnInteract(GameObject player)
        {
            _interactionCount++;
            _hasBeenInteracted = true;
            
            // Change color
            if (_renderer != null)
            {
                _renderer.material.color = _interactionCount % 2 == 0 ? defaultColor : interactedColor;
            }
            
            // Print debug message
            Debug.Log($"TestCube interacted with! Count: {_interactionCount}, Player: {player.name}");
            
            // Optional: Add visual feedback (scale pulse)
            StartCoroutine(PulseScale());
        }

        public bool CanInteract()
        {
            return canInteract;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        #endregion

        /// <summary>
        /// Simple scale pulse effect when interacted with.
        /// </summary>
        private System.Collections.IEnumerator PulseScale()
        {
            Vector3 originalScale = transform.localScale;
            Vector3 targetScale = originalScale * 1.2f;
            float duration = 0.2f;
            
            // Scale up
            float elapsed = 0f;
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            // Scale down
            elapsed = 0f;
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            transform.localScale = originalScale;
        }

        /// <summary>
        /// Draw a wire cube in Scene view to show interactable bounds.
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = canInteract ? Color.green : Color.red;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}
