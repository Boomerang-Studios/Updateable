# 🔁 Boomerang Updateable System

A modular and centralized alternative to Unity’s default `MonoBehaviour` update flow — lightweight, performant, and easy to integrate.

> ✨ Use this to control **per-frame updates** (Update, FixedUpdate, LateUpdate) from a single manager with optional toggles and prioritization.

---

## 📦 Features

- ✅ Centralized update control via `UpdateManager`
- ✅ Interfaces: `IUpdateable`, `IFixedUpdateable`, `ILateUpdateable`
- ✅ Boolean-based `CanUpdate`, `CanFixedUpdate`, `CanLateUpdate`
- ✅ Safe static registration / deregistration
- ✅ Avoids duplicate registration or stale calls
- ✅ Lightweight and compatible with all Unity versions
- ✅ Ideal for gameplay, AI, systems, UI, and effects

---

## 🧩 Interfaces

```csharp
public interface IUpdateable
{
    bool CanUpdate { get; }
    void OnUpdate(float deltaTime);
}

public interface IFixedUpdateable
{
    bool CanFixedUpdate { get; }
    void OnFixedUpdate();
}

public interface ILateUpdateable
{
    bool CanLateUpdate { get; }
    void OnLateUpdate();
}
