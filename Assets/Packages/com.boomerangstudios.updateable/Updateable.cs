using System.Collections.Generic;
using UnityEngine;

namespace Boomerang.Updateable
{
    public class Updateable : MonoBehaviour
    {
        private List<IUpdateable> m_Updateables;
        private int m_UpdateableCount = 0;
        [SerializeField] private int m_ListSize = 0;

        private static Updateable m_Instance;

        private IUpdateable m_CurrentObject;
        private float m_DeltaTime;

        #region Unity Callbacks
        private void Awake()
        {
            m_Instance = this;
            m_Updateables = new List<IUpdateable>(m_ListSize);
        }

        private void Start()
        {

        }

        private void OnDestroy()
        {
            m_Updateables.Clear();
        }

        private void Update()
        {
            m_DeltaTime = Time.deltaTime;
            for (int i = 0; i < m_UpdateableCount; i++)
            {
                m_CurrentObject = m_Updateables[i];
                if (m_CurrentObject.CanUpdate)
                    m_CurrentObject.OnUpdate(m_DeltaTime);
            }
        }
        #endregion

        #region Static Functions
        public static void RegisterUpdateable(System.Object a_Object)
        {
            if (a_Object is IUpdateable)
            {
                m_Instance.AddUpdateable(a_Object as IUpdateable);
            }
        }

        public static void UnregisterUpdateable(System.Object a_Object)
        {
            if (a_Object is IUpdateable)
            {
                m_Instance.RemoveUpdateable(a_Object as IUpdateable);
            }
        }
        #endregion

        #region Public Functions
        public void AddUpdateable(IUpdateable a_Updateable)
        {
            m_Updateables.Add(a_Updateable);
            m_UpdateableCount++;
        }

        public void RemoveUpdateable(IUpdateable a_Updateable)
        {
            m_Updateables.Remove(a_Updateable);
            m_UpdateableCount--;
        }
        #endregion
    }

}