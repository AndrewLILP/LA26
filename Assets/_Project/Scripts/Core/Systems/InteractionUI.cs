using UnityEngine;
using UnityEngine.UIElements;

namespace LandyAcademy.Core.Systems
{
    /// <summary>
    /// Manages the interaction prompt UI using UI Toolkit.
    /// Single Responsibility: Only handles showing/hiding interaction prompts.
    /// </summary>
    public class InteractionUI : MonoBehaviour
    {
        [Header("UI Document")]
        [Tooltip("Reference to the UIDocument component")]
        [SerializeField] private UIDocument uiDocument;
        
        [Header("UI Element Names")]
        [Tooltip("Name of the prompt container in UXML")]
        [SerializeField] private string promptContainerName = "prompt-container";
        
        [Tooltip("Name of the prompt text label in UXML")]
        [SerializeField] private string promptTextName = "prompt-text";
        
        // UI Elements
        private VisualElement _promptContainer;
        private Label _promptText;
        
        // State
        private bool _isVisible = false;

        private void Awake()
        {
            InitializeUI();
        }

        /// <summary>
        /// Initialize UI Toolkit elements.
        /// </summary>
        private void InitializeUI()
        {
            if (uiDocument == null)
            {
                uiDocument = GetComponent<UIDocument>();
                if (uiDocument == null)
                {
                    Debug.LogError("InteractionUI: UIDocument component is missing!");
                    return;
                }
            }

            VisualElement root = uiDocument.rootVisualElement;
            
            _promptContainer = root.Q<VisualElement>(promptContainerName);
            _promptText = root.Q<Label>(promptTextName);

            if (_promptContainer == null)
            {
                Debug.LogError($"InteractionUI: Could not find VisualElement named '{promptContainerName}' in UXML!");
            }

            if (_promptText == null)
            {
                Debug.LogError($"InteractionUI: Could not find Label named '{promptTextName}' in UXML!");
            }

            // Hide prompt by default
            HidePrompt();
        }

        /// <summary>
        /// Show the interaction prompt with the specified text.
        /// </summary>
        /// <param name="text">Text to display (e.g., "Press E to pat dog")</param>
        public void ShowPrompt(string text)
        {
            if (_promptContainer == null || _promptText == null) return;

            _promptText.text = text;
            _promptContainer.style.display = DisplayStyle.Flex;
            _isVisible = true;
        }

        /// <summary>
        /// Hide the interaction prompt.
        /// </summary>
        public void HidePrompt()
        {
            if (_promptContainer == null) return;

            _promptContainer.style.display = DisplayStyle.None;
            _isVisible = false;
        }

        /// <summary>
        /// Check if the prompt is currently visible.
        /// </summary>
        public bool IsVisible => _isVisible;
    }
}
