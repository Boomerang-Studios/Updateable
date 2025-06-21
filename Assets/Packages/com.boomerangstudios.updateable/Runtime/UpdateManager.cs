using System.Collections.Generic;
using UnityEngine;

namespace Boomerang.Updateable
{
	public class UpdateManager : MonoBehaviour
	{
		private List<IUpdateable> m_Updateables;
		private int m_UpdateableCount = 0;

		private List<IFixedUpdateable> m_FixedUpdateables;
		private int m_FixedUpdateableCount = 0;

		private List<ILateUpdateable> m_LateUpdateables;
		private int m_LateUpdateableCount = 0;

		private static UpdateManager m_Instance;

		private float m_DeltaTime;

		#region Unity Callbacks
		private void Awake()
		{
			if (m_Instance != null && m_Instance != this)
			{
				Destroy(gameObject);
				return;
			}
			m_Instance = this;

			m_Updateables = new List<IUpdateable>();
			m_FixedUpdateables = new List<IFixedUpdateable>();
			m_LateUpdateables = new List<ILateUpdateable>();
		}

		private void OnDestroy()
		{
			m_Updateables.Clear();
			m_FixedUpdateables.Clear();
			m_LateUpdateables.Clear();
		}

		private void Update()
		{
			m_DeltaTime = Time.deltaTime;
			for (int i = 0; i < m_UpdateableCount; i++)
			{
				IUpdateable m_CurrentObject = m_Updateables[i];
				if (m_CurrentObject.CanUpdate)
					m_CurrentObject.OnUpdate(m_DeltaTime);
			}
		}

		private void LateUpdate()
		{
			for (int i = 0; i < m_LateUpdateableCount; i++)
			{
				ILateUpdateable m_CurrentObject = m_LateUpdateables[i];
				m_CurrentObject = m_LateUpdateables[i];
				if (m_CurrentObject.CanLateUpdate)
					m_CurrentObject.OnLateUpdate();
			}
		}

		private void FixedUpdate()
		{
			for (int i = 0; i < m_FixedUpdateableCount; i++)
			{
				IFixedUpdateable m_CurrentObject = m_FixedUpdateables[i];
				m_CurrentObject = m_FixedUpdateables[i];
				if (m_CurrentObject.CanFixedUpdate)
					m_CurrentObject.OnFixedUpdate();
			}
		}

		#endregion

		#region Static Functions
		public static void RegisterUpdateable(IUpdateable a_Object)
		{
			m_Instance.AddUpdateable(a_Object);
		}

		public static void UnregisterUpdateable(IUpdateable a_Object)
		{
			m_Instance.RemoveUpdateable(a_Object);
		}

		public static void RegisterFixedUpdateable(IFixedUpdateable a_Object)
		{
			m_Instance.AddFixedUpdateable(a_Object);
		}

		public static void UnregisterFixedUpdateable(IFixedUpdateable a_Object)
		{
			m_Instance.RemoveFixedUpdateable(a_Object);
		}

		public static void RegisterLateUpdateable(ILateUpdateable a_Object)
		{
			m_Instance.AddLateUpdateable(a_Object);
		}

		public static void UnregisterLateUpdateable(ILateUpdateable a_Object)
		{
			m_Instance.RemoveLateUpdateable(a_Object);
		}
		#endregion

		private void AddUpdateable(IUpdateable a_Updateable)
		{
			if (!m_Updateables.Contains(a_Updateable))
			{
				m_Updateables.Add(a_Updateable);
				m_UpdateableCount++;
			}
		}

		private void RemoveUpdateable(IUpdateable a_Updateable)
		{
			if (m_Updateables.Remove(a_Updateable))
				m_UpdateableCount--;
		}

		private void AddLateUpdateable(ILateUpdateable a_Updateable)
		{
			if (!m_LateUpdateables.Contains(a_Updateable))
			{
				m_LateUpdateables.Add(a_Updateable);
				m_LateUpdateableCount++; 
			}
		}

		private void RemoveLateUpdateable(ILateUpdateable a_Updateable)
		{
			if (m_LateUpdateables.Remove(a_Updateable))
				m_LateUpdateableCount--;
		}

		private void AddFixedUpdateable(IFixedUpdateable a_Updateable)
		{
			if (!m_FixedUpdateables.Contains(a_Updateable))
			{
				m_FixedUpdateables.Add(a_Updateable);
				m_FixedUpdateableCount++; 
			}
		}

		private void RemoveFixedUpdateable(IFixedUpdateable a_Updateable)
		{
			if (m_FixedUpdateables.Remove(a_Updateable))
				m_FixedUpdateableCount--;
		}
	}

}