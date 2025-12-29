# Sprint 0: Quick Reference Card

## 🎯 System Overview

```
Player walks near object → InteractionDetector finds IInteractable 
→ InteractionUI shows prompt → Player presses E → OnInteract() called
```

---

## 📦 Core Components

### IInteractable Interface
**Location:** `Core/Interfaces/IInteractable.cs`
**Purpose:** Contract for all interactive objects

**Methods:**
- `string GetPromptText()` - What to show player
- `void OnInteract(GameObject player)` - What happens when pressed E
- `bool CanInteract()` - Can player interact right now?
- `Transform GetTransform()` - Where is this object?

### InteractionDetector
**Location:** `Core/Systems/InteractionDetector.cs`
**Attach to:** Player GameObject
**Purpose:** Finds nearby interactables

**Settings:**
- Interaction Radius: 2.5 units
- Interactable Layer: "Interactable"
- Interaction UI: Reference to InteractionUI GameObject

### InteractionUI
**Location:** `Core/Systems/InteractionUI.cs`
**Attach to:** UI Document GameObject
**Purpose:** Shows/hides prompts

**Uses:**
- UI Toolkit (not TextMeshPro)
- UXML: InteractionPrompt.uxml
- USS: InteractionPrompt.uss

---

## 🔧 Creating New Interactable

### Quick Template:

```csharp
using UnityEngine;
using LandyAcademy.Core.Interfaces;

public class MyInteractable : MonoBehaviour, IInteractable
{
    public string GetPromptText() 
    {
        return "Press E to do something";
    }
    
    public void OnInteract(GameObject player)
    {
        Debug.Log("Player interacted!");
        // Your code here
    }
    
    public bool CanInteract() 
    {
        return true; // or check conditions
    }
    
    public Transform GetTransform() 
    {
        return transform;
    }
}
```

### Setup in Unity:
1. Create GameObject
2. Add BoxCollider (or other collider)
3. ✅ Check "Is Trigger"
4. Set Layer to "Interactable"
5. Add your script (implements IInteractable)

---

## ⌨️ Input System

### StarterAssetsInputs.cs Additions

**Field:**
```csharp
public bool interact;
```

**Methods:**
```csharp
#if ENABLE_INPUT_SYSTEM
public void OnInteract(InputValue value)
{
    InteractInput(value.isPressed);
}
#endif

public void InteractInput(bool newInteractState)
{
    interact = newInteractState;
}
```

### Input Actions
- Action Name: `Interact`
- Binding: `E` key
- Optional: Gamepad button

---

## 🎨 UI Toolkit

### UXML Structure
```xml
<VisualElement name="prompt-container">
    <Label name="prompt-text" text="Press E" />
</VisualElement>
```

### USS Styling
- Container: Black background, white border
- Position: Bottom center of screen
- Text: White, bold, 24px
- Hidden by default (display: none)

---

## 🐛 Common Issues

| Problem | Solution |
|---------|----------|
| Prompt not appearing | Check layer is "Interactable", trigger is enabled |
| E key not working | Save Input Actions, check StarterAssetsInputs modified |
| Can't find interface | Check file in correct folder for namespace |
| UI not showing | Assign UXML to UIDocument component |

---

## 📏 Design Principles

### Single Responsibility
- InteractionDetector: ONLY detection
- InteractionUI: ONLY UI display
- Interactables: ONLY their specific behavior

### Interface Segregation
- IInteractable: Minimal methods
- No bloated interfaces

### Open/Closed
- Add new interactables WITHOUT modifying core system
- Just implement IInteractable

### Dependency Inversion
- Detector depends on IInteractable (interface)
- Not on concrete TestCube, Dog, Canteen classes

---

## 🎯 File Locations Checklist

```
Assets/
└── _Project/
    ├── Scripts/
    │   ├── Core/
    │   │   ├── Interfaces/
    │   │   │   └── ✅ IInteractable.cs
    │   │   └── Systems/
    │   │       ├── ✅ InteractionDetector.cs
    │   │       └── ✅ InteractionUI.cs
    │   └── Interactables/
    │       └── TestCube/
    │           └── ✅ TestCubeInteractable.cs
    └── UI/
        └── Toolkit/
            ├── ✅ InteractionPrompt.uxml
            └── ✅ InteractionPrompt.uss
```

---

## ⚡ Quick Debug Commands

### Check Detection
```csharp
// In InteractionDetector
Debug.Log($"Current Interactable: {_currentInteractable}");
```

### Check Input
```csharp
// In Update() of any script
if (_input.interact) Debug.Log("Interact pressed!");
```

### Visualize Range
- Select Player in Hierarchy
- Scene view shows yellow sphere (interaction radius)
- Gizmo drawn by InteractionDetector.OnDrawGizmosSelected()

---

## 🎮 Testing Workflow

1. ✅ Press Play
2. ✅ Walk to object
3. ✅ See prompt appear
4. ✅ Press E
5. ✅ See interaction happen
6. ✅ Walk away
7. ✅ Prompt disappears

---

**Keep this handy while developing! 📌**

