# Sprint 0: Progress Tracking Checklist

Use this to track your progress through Sprint 0.

---

## 📁 Part 1: Folder Structure

- [ ] Created `Assets/_Project/` folder
- [ ] Created `Scripts/` subfolder
- [ ] Created `Scripts/Core/Interfaces/` folder
- [ ] Created `Scripts/Core/Systems/` folder
- [ ] Created `Scripts/Interactables/TestCube/` folder
- [ ] Created `Scripts/Player/Extensions/` folder
- [ ] Created `Prefabs/Interactables/` folder
- [ ] Created `Prefabs/UI/` folder
- [ ] Created `UI/Toolkit/` folder
- [ ] Created `Scenes/TestScenes/` folder
- [ ] Created `Settings/` folder

**Status:** _____ / 11 folders created

---

## 📝 Part 2: Import Scripts

- [ ] Copied `IInteractable.cs` to `Scripts/Core/Interfaces/`
- [ ] Copied `InteractionDetector.cs` to `Scripts/Core/Systems/`
- [ ] Copied `InteractionUI.cs` to `Scripts/Core/Systems/`
- [ ] Copied `TestCubeInteractable.cs` to `Scripts/Interactables/TestCube/`
- [ ] Copied `InteractionPrompt.uxml` to `UI/Toolkit/`
- [ ] Copied `InteractionPrompt.uss` to `UI/Toolkit/`
- [ ] Unity compiled successfully (no errors)

**Status:** _____ / 7 files imported

---

## 🎮 Part 3: Modify Input System

- [ ] Found `StarterAssetsInputs.cs` in project
- [ ] Opened file in code editor
- [ ] Added `public bool interact;` field
- [ ] Added `OnInteract(InputValue value)` method
- [ ] Added `InteractInput(bool newInteractState)` method
- [ ] Saved file
- [ ] Unity recompiled successfully

**Status:** _____ / 7 steps completed

---

## ⌨️ Part 4: Configure Input Actions

- [ ] Opened `StarterAssets.inputactions` file
- [ ] Selected "Player" action map
- [ ] Added new "Interact" action
- [ ] Set binding to E key
- [ ] (Optional) Added gamepad binding
- [ ] Clicked "Save Asset" button
- [ ] Verified Interact action appears in list

**Status:** _____ / 7 steps completed

---

## 🎨 Part 5: Create UI Document

- [ ] Created UIDocument GameObject in scene
- [ ] Renamed to `InteractionUI`
- [ ] Assigned `InteractionPrompt.uxml` to Source Asset
- [ ] Added `InteractionUI` component script
- [ ] Verified auto-configuration of script settings
- [ ] UI shows prompt structure in Inspector

**Status:** _____ / 6 steps completed

---

## 🎭 Part 6: Setup Player

- [ ] Found Player GameObject in Hierarchy
- [ ] Added `InteractionDetector` component
- [ ] Created "Interactable" layer in project
- [ ] Set Interaction Radius to 2.5
- [ ] Set Interactable Layer to "Interactable"
- [ ] Assigned InteractionUI GameObject reference
- [ ] Verified all fields are configured

**Status:** _____ / 7 steps completed

---

## 🎲 Part 7: Create Test Cube

- [ ] Created Cube GameObject
- [ ] Renamed to `TestCube_Interactable`
- [ ] Positioned cube near player (visible)
- [ ] Enabled "Is Trigger" on Box Collider
- [ ] Set cube Layer to "Interactable"
- [ ] Added `TestCubeInteractable` component
- [ ] (Optional) Created and assigned material
- [ ] Verified all component settings

**Status:** _____ / 8 steps completed

---

## 🎮 Part 8: Testing

- [ ] Saved scene
- [ ] Pressed Play
- [ ] Walked toward test cube
- [ ] Prompt appeared when near cube
- [ ] Pressed E key
- [ ] Cube changed color
- [ ] Cube pulsed (scale animation)
- [ ] Console showed interaction message
- [ ] Walked away from cube
- [ ] Prompt disappeared
- [ ] Tested multiple interactions (E repeatedly)

**Status:** _____ / 11 tests passed

---

## 📦 Part 9: Organization

- [ ] Created TestCube prefab in `Prefabs/Interactables/`
- [ ] Saved test scene to `Scenes/TestScenes/Sprint0_InteractionTest`
- [ ] Ran `git status` to see changes
- [ ] Ran `git add .`
- [ ] Ran `git commit` with descriptive message
- [ ] Ran `git push`
- [ ] Verified commit on GitHub

**Status:** _____ / 7 steps completed

---

## 🎯 Final Validation

### Architecture Check
- [ ] System uses IInteractable interface
- [ ] InteractionDetector has single responsibility
- [ ] InteractionUI has single responsibility
- [ ] Can add new interactables without modifying core
- [ ] Following SOLID principles

### Functional Check
- [ ] Player can move around environment
- [ ] Interaction range visualization works (yellow sphere gizmo)
- [ ] Prompt appears/disappears correctly
- [ ] E key triggers interaction
- [ ] Multiple interactions work
- [ ] No console errors

### Documentation Check
- [ ] Read Sprint0_CompleteSetupGuide.md
- [ ] Read Sprint0_QuickReference.md
- [ ] Understand how to create new interactables
- [ ] Know where each file should be located

**Status:** _____ / 14 checks passed

---

## 📊 Overall Progress

**Total Completed:** _____ / 84 tasks

**Completion Percentage:** _____%

---

## 🎉 Sprint 0 Status

- [ ] ❌ Not Started
- [ ] 🟡 In Progress (0-50%)
- [ ] 🟠 In Progress (51-99%)
- [ ] ✅ COMPLETE (100%)

---

## 📸 Evidence (Optional)

**Screenshot Checklist:**
- [ ] Folder structure in Unity
- [ ] Player with InteractionDetector component
- [ ] TestCube with components configured
- [ ] Game running with prompt showing
- [ ] Console showing interaction message

---

## 🚀 Ready for Sprint 1?

Before moving to Sprint 1 (Dog Interaction), ensure:

- [ ] Sprint 0 is 100% complete
- [ ] All tests pass
- [ ] Code is committed to Git
- [ ] You understand the architecture
- [ ] You can create new interactables
- [ ] No outstanding bugs or issues

---

**Date Started:** __________

**Date Completed:** __________

**Time Invested:** __________ hours

**Notes:**
_______________________________________________________
_______________________________________________________
_______________________________________________________

