# 🎤 Stage Fright VR — Speaker

> A virtual reality experience designed to help users overcome the fear of public speaking.  
> Built with Unity + XR Interaction Toolkit using OpenXR.

---

## 📋 Overview

**Stage Fright VR** places the user on a virtual stage in front of an audience, providing a safe and controlled environment to practice public speaking.  
The project is developed as part of the **Immersive Computing** course (Semester 6 — TWU).

---

## 🛠️ Built With

| Technology | Version |
|---|---|
| Unity | 6 (URP) |
| XR Interaction Toolkit | 3.3.1 |
| OpenXR | 1.16.1 |
| Unity Input System | 1.18.0 |
| Shader Graph | 17.3.0 |
| Timeline | 1.8.10 |
| Visual Scripting | 1.9.9 |

---

## 📁 Project Structure

```
Assets/
├── Art/                          # Environment art, props, and visual assets
├── Audio/                        # Sound effects and ambient audio
├── Characters/                   # Player and NPC character assets
├── Materials/                    # Shared materials and shaders
├── Prefabs/                      # Reusable scene prefabs
├── Scenes/
│   ├── SampleScene.unity         # Development/sandbox scene
│   └── Phase3_Main.unity         # Main game scene (Phase 3)
├── Scripts/
│   └── Interaction/
│       ├── PodiumTriggerZone.cs  # Handles player entering podium zone
│       └── SecondTriggerZone.cs  # Handles second interaction trigger
├── XR/                           # XR rig and device configuration
├── XRI/                          # XR Interaction Toolkit settings
├── InputSystem_Actions.inputactions  # Input bindings (New Input System)
└── SpeakerCharacterController.controller  # Animator Controller
```

---

## 🚀 Getting Started

### Prerequisites

- **Unity 6** (LTS recommended) with **Android Build Support** or **Windows Build Support (IL2CPP)**
- A compatible **OpenXR headset** (Meta Quest, HTC Vive, Valve Index, etc.)
- **Git LFS** installed — large binary assets are tracked via LFS

```bash
git lfs install
```

### Setup

1. Clone the repository:

```bash
git clone https://github.com/Saketh567/stage-freight-vr.git
```

2. Open the project in **Unity Hub** — Unity will auto-import packages.
3. Open `Assets/Scenes/Phase3_Main.unity`.
4. Connect your VR headset (or enable **XR Device Simulator** for desktop testing).
5. Press **Play**.

---

## 🎮 Controls

| Action | Input |
|---|---|
| Move | Left Thumbstick |
| Look | Right Thumbstick / Head movement |
| Interact | Trigger (Right controller) |
| Grab | Grip button |

---

## 🗂️ Git & Asset Management

This project uses:

- **`.gitignore`** — excludes Unity-generated folders (`Library/`, `Temp/`, etc.)
- **`.gitattributes`** — configures **Git LFS** for large binary assets:
  - 3D models (`.fbx`, `.blend`, `.obj`)
  - Source textures (`.psd`, `.tga`, `.exr`, `.hdr`)
  - Audio (`.wav`, `.mp3`, `.ogg`)
  - Video (`.mp4`, `.mov`)
  - Unity Smart Merge for `.unity`, `.prefab`, `.mat`

> ⚠️ Always run `git lfs install` before your first commit/clone.

---

## 👤 Author

**Saketh** — TWU Semester 6, Immersive Computing

---

## 📄 License

This project is for academic use only.
