# Sprint 0: Complete Setup Guide
## Foundation & Core Interaction System

---

## 📋 Prerequisites Checklist

Before starting, ensure you have:
- ✅ Unity 6.3 LTS project open
- ✅ Starter Assets Third Person Controller working
- ✅ Player can walk around the environment
- ✅ PolygonDog assets imported
- ✅ PolygonAncientEmpire environment set up

---

## 🎯 Sprint 0 Goal
**Create a working interaction system where the player can walk up to a test cube, see "Press E to interact" prompt, and trigger an interaction.**

---

## Part 1: Folder Structure Setup (5 minutes)

### 1.1 Create Main Folders
In Unity's Project window:

1. Right-click in Assets → Create → Folder
2. Create folder: `_Project` (underscore keeps it at top)
3. Inside `_Project`, create these folders:
   - `Scripts`
   - `Prefabs`
   - `UI`
   - `Scenes`
   - `Settings`

### 1.2 Create Scripts Subfolders
Inside `Assets/_Project/Scripts/`, create:
- `Core`
  - Inside Core: `Interfaces`
  - Inside Core: `Systems`
- `Interactables`
  - Inside Interactables: `TestCube`
- `Player`
  - Inside Player: `Extensions`

### 1.3 Create Other Subfolders
- `Assets/_Project/Prefabs/Interactables/`
- `Assets/_Project/Prefabs/UI/`
- `Assets/_Project/UI/Toolkit/`
- `Assets/_Project/Scenes/TestScenes/`

**✅ Checkpoint:** Your folder structure should match the diagram in Sprint0_FolderStructure.md

---

## Part 2: Import Scripts (10 minutes)

### 2.1 Copy C# Scripts to Unity

Copy these files from your outputs folder to Unity:

1. **IInteractable.cs** → `Assets/_Project/Scripts/Core/Interfaces/`
2. **InteractionDetector.cs** → `Assets/_Project/Scripts/Core/Systems/`
3. **InteractionUI.cs** → `Assets/_Project/Scripts/Core/Systems/`
4. **TestCubeInteractable.cs** → `Assets/_Project/Scripts/Interactables/TestCube/`

### 2.2 Import UI Toolkit Assets

Copy these files to Unity:

1. **InteractionPrompt.uxml** → `Assets/_Project/UI/Toolkit/`
2. **InteractionPrompt.uss** → `Assets/_Project/UI/Toolkit/`

### 2.3 Wait for Compilation

Unity will automatically compile. Watch the bottom-right corner:
- "Compiling..." → Wait
- Clear → Good to go!

**❌ If you see errors:** Check that all files are in the correct folders matching the namespaces.

**✅ Checkpoint:** No compilation errors in Console window

---

## Part 3: Modify StarterAssetsInputs (15 minutes)

This is the MOST IMPORTANT step - we need to add interaction input to the existing Starter Assets.

### 3.1 Find StarterAssetsInputs.cs

1. In Project window, search: `StarterAssetsInputs`
2. Location should be: `Assets/StarterAssets/InputSystem/StarterAssetsInputs.cs`
3. Double-click to open in your code editor

### 3.2 Add Interact Input Field

Find the section that looks like:
```csharp
// Character Input Values
public Vector2 move;
public Vector2 look;
public bool jump;
public bool sprint;
```

**Add this line below `sprint`:**
```csharp
public bool interact;
```

### 3.3 Add Input Methods

Scroll to the bottom of the class, before the closing `}`.

**Add these two methods:**

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

### 3.4 Save File

**IMPORTANT:** Save the file (Ctrl+S / Cmd+S)

**✅ Checkpoint:** Unity recompiles successfully, no errors

---

## Part 4: Add Interact Input Action (20 minutes)

Now we need to add "Interact" to Unity's Input System.

### 4.1 Open Input Actions Asset

1. In Project window, navigate to: `Assets/StarterAssets/InputSystem/`
2. Find: `StarterAssets.inputactions`
3. Double-click to open Input Actions window

### 4.2 Add Interact Action

In the Input Actions window:

1. Select "Player" action map (left panel)
2. Click the "+" button in the Actions section (middle panel)
3. Name the new action: `Interact`
4. Select the new Interact action
5. In the right panel, click "+" under Bindings
6. Click `<No Binding>` and press the **E** key on your keyboard
7. It should now show: `Interact [Keyboard]/e`

### 4.3 Add Gamepad Binding (Optional)

For gamepad support:
1. With "Interact" action selected, click "+" under Bindings again
2. Select "Add Binding"
3. Click `<No Binding>` and press **X** button on gamepad (or set your preference)

### 4.4 Save Input Actions

**CRITICAL:** Click "Save Asset" button at the top of the Input Actions window!

**✅ Checkpoint:** Input Actions window shows "Interact" action with E key binding

---

## Part 5: Create UI Document (10 minutes)

### 5.1 Create UIDocument GameObject

In your main scene (LandyAcademy101):

1. Right-click in Hierarchy → UI Toolkit → UI Document
2. Rename to: `InteractionUI`
3. **Important:** Set the GameObject to remain in the scene root (not inside Canvas)

### 5.2 Configure UIDocument Component

Select the `InteractionUI` GameObject:

1. In Inspector, find the **UIDocument** component
2. Under "Source Asset":
   - Click the circle icon
   - Select `InteractionPrompt` (the UXML file)
3. The UIDocument should now show your prompt structure

### 5.3 Add InteractionUI Script

With `InteractionUI` still selected:

1. Click "Add Component"
2. Search: `InteractionUI`
3. Select it (should be under LandyAcademy.Core.Systems)

### 5.4 Configure InteractionUI Component

The script should auto-configure, but verify:
- **Ui Document:** Should auto-reference the UIDocument component
- **Prompt Container Name:** `prompt-container`
- **Prompt Text Name:** `prompt-text`

**✅ Checkpoint:** InteractionUI GameObject exists with both UIDocument and InteractionUI components

---

## Part 6: Setup Player for Interaction (15 minutes)

### 6.1 Find Your Player

In Hierarchy, find your player. It's likely named:
- `PlayerArmature`
- `NestedParentArmature_Unpack`
- Look for object with ThirdPersonController script

### 6.2 Add InteractionDetector Component

Select your Player GameObject:

1. Click "Add Component"
2. Search: `InteractionDetector`
3. Add it

### 6.3 Create Interactable Layer

We need a dedicated layer for interactables:

1. Top-right of Inspector → Layers → Edit Layers
2. Find first empty User Layer (probably Layer 6)
3. Name it: `Interactable`

### 6.4 Configure InteractionDetector

Select your Player again, find InteractionDetector component:

1. **Interaction Radius:** `2.5` (how far player can interact)
2. **Interactable Layer:** 
   - Click dropdown
   - Select "Interactable" layer ONLY
   - Should show "Mixed..." or "Interactable"
3. **Interaction UI:**
   - Click circle icon
   - Select the `InteractionUI` GameObject from scene

**✅ Checkpoint:** Player has InteractionDetector component fully configured

---

## Part 7: Create Test Cube (15 minutes)

Time to create something to interact with!

### 7.1 Create Cube GameObject

1. Hierarchy → Right-click → 3D Object → Cube
2. Rename to: `TestCube_Interactable`
3. Position it near your player (somewhere visible)
   - Example: X: 0, Y: 0.5, Z: 5

### 7.2 Add Collider as Trigger

Select `TestCube_Interactable`:

1. It already has a Box Collider
2. **CHECK:** "Is Trigger" checkbox
3. This allows detection without physical collision

### 7.3 Set Layer

With TestCube still selected:

1. Top of Inspector → Layer dropdown
2. Select "Interactable"
3. Unity may ask "Change all child objects?" → Choose "Yes, change children" (if asked)

### 7.4 Add TestCubeInteractable Script

Still on TestCube:

1. Click "Add Component"
2. Search: `TestCubeInteractable`
3. Add it

### 7.5 Configure TestCubeInteractable

Should auto-configure, but verify:
- **Prompt Text:** "Press E to interact with cube"
- **Can Interact:** ✅ Checked
- **Default Color:** White
- **Interacted Color:** Green

### 7.6 Make It Visible (Optional Styling)

Make the cube more interesting:

1. Create a Material: Assets → Create → Material
2. Name it: `TestCubeMaterial`
3. Set color to something bright (blue, red, yellow)
4. Drag material onto the TestCube in scene

**✅ Checkpoint:** TestCube exists with trigger collider, Interactable layer, and TestCubeInteractable script

---

## Part 8: Test the System! 🎮 (10 minutes)

### 8.1 Save Everything

1. File → Save (Ctrl+S / Cmd+S)
2. Save scene if prompted

### 8.2 Press Play

Hit the Play button!

### 8.3 Test Interaction

1. **Walk toward the test cube** using WASD
2. **When you get close** (within 2.5 units):
   - You should see "Press E to interact with cube" appear at bottom of screen
3. **Press E:**
   - Cube should pulse (scale animation)
   - Cube should change color (white → green)
   - Console should show: "TestCube interacted with! Count: 1"
4. **Press E again:**
   - Count increases
   - Color toggles
5. **Walk away:**
   - Prompt should disappear

### 8.4 Debug if Not Working

**Prompt doesn't appear?**
- Check InteractionDetector has InteractionUI reference
- Check TestCube layer is "Interactable"
- Check InteractionDetector's Interactable Layer includes "Interactable"
- Check TestCube has "Is Trigger" enabled
- Use Scene view gizmos: Select player → you should see yellow wire sphere (interaction radius)

**Prompt appears but E doesn't work?**
- Check StarterAssetsInputs.cs was modified correctly
- Check Input Actions has "Interact" action
- Check Input Actions was saved
- Try pressing other keys to verify input system is working

**Console errors?**
- Read the error message
- Check all script references are assigned
- Check namespaces match folder structure

**✅ Checkpoint:** You can walk to cube, see prompt, press E, and interact!

---

## Part 9: Organize & Document (10 minutes)

### 9.1 Create Prefab

Let's make this cube reusable:

1. Drag `TestCube_Interactable` from Hierarchy → `Assets/_Project/Prefabs/Interactables/`
2. This creates a prefab
3. Now you can duplicate it or place it in other scenes

### 9.2 Save a Test Scene

1. File → Save As
2. Navigate to: `Assets/_Project/Scenes/TestScenes/`
3. Name: `Sprint0_InteractionTest`
4. Click Save

### 9.3 Git Commit

Time to save your progress! Open command prompt:

```bash
cd C:\Dev\LA26  # Or your project name

# Check what changed
git status

# Add all changes
git add .

# Commit
git commit -m "feat: Implement Sprint 0 interaction system

- Added IInteractable interface
- Created InteractionDetector system
- Implemented InteractionUI with UI Toolkit
- Extended StarterAssetsInputs for interact button
- Created TestCubeInteractable for testing
- Set up proper folder structure"

# Push to GitHub
git push
```

**✅ Checkpoint:** Changes committed and pushed to GitHub!

---

## 🎉 Sprint 0 Complete!

You now have:
- ✅ Professional folder structure
- ✅ Working interaction system
- ✅ SOLID-compliant architecture (Interface Segregation, Single Responsibility)
- ✅ Extensible system ready for Dog and Canteen interactions
- ✅ UI Toolkit-based prompts
- ✅ Test environment validated
- ✅ Proper Git workflow

---

## 📊 Architecture Validation

Let's verify SOLID principles:

1. **Single Responsibility:**
   - ✅ InteractionDetector: Only detects and triggers
   - ✅ InteractionUI: Only manages UI display
   - ✅ TestCubeInteractable: Only handles cube behavior

2. **Open/Closed:**
   - ✅ Can add DogInteractor without modifying core system
   - ✅ Just implement IInteractable interface

3. **Interface Segregation:**
   - ✅ IInteractable has only essential methods
   - ✅ No forced implementation of unused features

4. **Dependency Inversion:**
   - ✅ InteractionDetector depends on IInteractable (interface)
   - ✅ Not dependent on concrete implementations

---

## 🎯 Next Steps

Your system is now ready for Sprint 1: Dog Interaction!

The next sprint will:
1. Create `DogInteractor : MonoBehaviour, IInteractable`
2. Implement dog animations and state machine
3. Add "Pat Dog" and "Throw Ball" interactions
4. Track interaction data

**Before starting Sprint 1:**
- Test the current system thoroughly
- Make sure you understand how IInteractable works
- Play with the test cube to get familiar with the flow

---

## 📞 Troubleshooting

**Issue: "Type or namespace name 'LandyAcademy' could not be found"**
- Solution: Make sure files are in correct folders matching namespaces
- Check folder structure matches exactly

**Issue: "UIDocument not showing prompt"**
- Solution: Check UXML file is assigned to UIDocument component
- Verify USS stylesheet is linked (should happen automatically)

**Issue: "Player doesn't detect cube"**
- Solution: 
  - Ensure cube has "Is Trigger" checked
  - Verify cube layer is "Interactable"
  - Check InteractionDetector's layer mask includes "Interactable"
  - Increase interaction radius to 5.0 for testing

**Issue: "E key doesn't respond"**
- Solution:
  - Verify StarterAssetsInputs.cs has `public bool interact;` field
  - Check Input Actions asset has "Interact" action with E key
  - Ensure Input Actions was SAVED (easy to forget!)

---

## 📝 Optional Enhancements

Want to level up before Sprint 1?

1. **Add sound effect** when interacting with cube
2. **Add particle effect** when cube is clicked
3. **Make prompt fade in/out** with USS animations
4. **Add multiple test cubes** with different interactions
5. **Customize prompt styling** in USS file

---

**🎮 Happy Coding! You're ready for Sprint 1! 🎮**

