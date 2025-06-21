# 🔁 Boomerang Updateable System

A modular, performant, and flexible update system for Unity, designed to replace the overhead of `MonoBehaviour.Update()` with centralized, safe, and priority-based update management.

> Lightweight. Safe. ECS-inspired.

---

## 🚀 Features

- Supports `Update`, `FixedUpdate`, and `LateUpdate`
- Priority-based execution
- Safe registration & unregistration
- Conditional updates for performance
- Profiler/debug integration
- Clean UPM structure for reuse
- Auto-registration in editor (optional)

---

## 📦 Installation

### Option 1: Unity Package Manager via Git
Add this to your project's `manifest.json`:
```json
"com.boomerangstudios.updateable": "https://github.com/Boomerang-Studios/Updateable.git?path=Packages/com.boomerangstudios.updateable"
```

### Option 2: Local Import
1. Clone/download this repo.
2. Move the `Packages/com.boomerangstudios.updateable/` folder into your Unity project's `Packages/`.

---

## 🛠 Usage

### 1. Create an updateable class:
```csharp
public class EnemyAI : MonoBehaviour, IUpdateable
{
    public void OnUpdate()
    {
        Debug.Log("Enemy updated!");
    }

    void OnEnable() => UpdateManager.Instance.Register(this);
    void OnDisable() => UpdateManager.Instance.Unregister(this);
}
```

### 2. Optional Priority:
```csharp
public class InputHandler : MonoBehaviour, IUpdateable, IPrioritized
{
    public int Priority => -100; // Runs before everything else
    public void OnUpdate() { /* handle input */ }
}
```

### 3. Conditional Updating:
```csharp
public class UIUpdater : MonoBehaviour, IConditionalUpdateable
{
    public bool ShouldUpdate => isVisible;
    public void OnUpdate() { /* update UI */ }
}
```

---

## 📚 API Overview

| Interface                  | Purpose                             |
|----------------------------|-------------------------------------|
| `IUpdateable`              | Called every `Update()`             |
| `IFixedUpdateable`         | Called every `FixedUpdate()`        |
| `ILateUpdateable`          | Called every `LateUpdate()`         |
| `IPrioritized`             | Adds priority order to execution    |
| `IConditionalUpdateable`   | Skip update if condition false      |

---

## 🧪 Sample Included

See `Demo/` folder for a plug-and-play example.

---

## 📄 License

This package is open-sourced under the [MIT License](./LICENSE).

---

## ✨ Created by

**[Satvik Nagpal](https://github.com/satviknagpal01)**  
Boomerang Studios
