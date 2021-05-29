using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Apparatys.Navigator
{
    public class UIManager : MonoBehaviour
    {
        private Dictionary<UIHandle, BaseUIView> m_ViewLookup = new Dictionary<UIHandle, BaseUIView>();

        private Stack<BaseUIView> m_NavigationStack = new Stack<BaseUIView>();

        private BaseUIView CurrentDialog
        {
            get
            {
                if (m_NavigationStack.Count > 0)
                {
                    return m_NavigationStack.Peek();
                }

                return null;
            }
        }

        public void ClearViews()
        {
            Debug.Log("UIManager::ClearViews()");
            // Hide all the view
            foreach (BaseUIView view in m_ViewLookup.Values)
            {
                view?.Hide();
            }

            // Clear the nav stack
            m_NavigationStack.Clear();
        }

        public void NavigateBack()
        {
            if (!PopInvalidViews())
            {
                // Pop the current view
                CurrentDialog?.Hide();
                m_NavigationStack.Pop();
            }

            PopInvalidViews();
            CurrentDialog?.Show();
        }

        public void Register(IEnumerable<BaseUIView> views)
        {
            foreach (BaseUIView view in views)
            {
                if (view != null)
                {
                    Debug.Log("UIManager::Register(view): " + view.ToString());
                    m_ViewLookup.Add(view.Handle, view);
                }
            }
        }

        public void UnregisterViews()
        {
            foreach (BaseUIView view in m_ViewLookup.Values)
            {
                if (view != null)
                {
                    Debug.Log("UIManager::Unregister(view): " + view.ToString());
                }
            }

            m_ViewLookup.Clear();
        }

        public BaseUIView ShowDialog(UIHandle viewHandle, IUIController controller)
        {
            if (viewHandle == null)
            {
                // Null key
                return null;
            }

            BaseUIView view = null;
            bool viewFound = m_ViewLookup.TryGetValue(viewHandle, out view);
            Assert.IsTrue(viewFound, $"No registered dialog with handle '{viewHandle}'.");

            if ((view != null) && (view != CurrentDialog))
            {
                view.Controller = controller;
                view.Show();

                if (view.PushToNavigationStack && CurrentDialog != view)
                {
                    m_NavigationStack.Push(view);
                }
            }

            return view;
        }

        public void Tick()
        {
            foreach (BaseUIView view in m_ViewLookup.Values)
            {
                if (view != null && view.IsVisible)
                {
                    view.Tick();
                }
            }
        }

        private bool PopInvalidViews()
        {
            bool popped = false;

            while (m_NavigationStack.Peek() == null || !m_ViewLookup.ContainsKey(m_NavigationStack.Peek().Handle))
            {
                // Pop destroyed or unregistered views from the top of the stack
                Debug.Log("UIManager::PopInvalidViews() -- null or view not found in lookup");
                m_NavigationStack.Pop();
                popped = true;
            }

            return popped;
        }
    }
}
