# Sprint 0: Folder Structure Setup

## Instructions
Create this folder structure in your Unity project's Assets folder:

```
Assets/
├── _Project/
│   ├── Scripts/
│   │   ├── Core/
│   │   │   ├── Interfaces/
│   │   │   └── Systems/
│   │   ├── Interactables/
│   │   │   └── TestCube/
│   │   └── Player/
│   │       └── Extensions/
│   ├── Prefabs/
│   │   ├── Interactables/
│   │   └── UI/
│   ├── UI/
│   │   └── Toolkit/
│   ├── Scenes/
│   │   └── TestScenes/
│   └── Settings/
```

## How to Create in Unity:
1. Right-click in Project window → Create → Folder
2. Name it exactly as shown (e.g., "_Project")
3. Repeat for all subfolders
4. Use underscore prefix for custom folders to keep them at the top

## Why This Structure?
- **_Project/**: Your custom game code (separate from assets/packages)
- **Core/**: Reusable systems that any game could use
- **Interactables/**: Game-specific interaction implementations
- **Player/Extensions/**: Extensions to Starter Assets without modifying originals
- **TestScenes/**: Isolated testing environments

✅ Once complete, proceed to Step 2
