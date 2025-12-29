using UnityEngine;

namespace LandyAcademy.Core.Interfaces
{
    /// <summary>
    /// Core interface for all interactable objects in the game.
    /// Implements Interface Segregation Principle - only essential methods.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Returns the text to display in the interaction prompt.
        /// Example: "Press E to pat dog" or "Press E to order food"
        /// </summary>
        string GetPromptText();
        
        /// <summary>
        /// Called when the player presses the interact button while near this object.
        /// </summary>
        /// <param name="player">Reference to the player GameObject</param>
        void OnInteract(GameObject player);
        
        /// <summary>
        /// Checks if the player can currently interact with this object.
        /// Useful for state-based interactions (e.g., dog is busy playing).
        /// </summary>
        bool CanInteract();
        
        /// <summary>
        /// Returns the transform of this interactable for positioning/distance calculations.
        /// </summary>
        Transform GetTransform();
    }
}
