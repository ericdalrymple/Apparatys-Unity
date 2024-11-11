using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Apparatys.Navigator
{
    public class UIManager : MonoBehaviour
    {
        private Dictionary<UIHandle, BaseUIView> m_ViewLookup = new Dictionary<UIHandle, BaseUIView>();

        private List<BaseUIView> m_NavigationStack = new List<BaseUIView>();

        private BaseUIView CurrentDialog
        {
            get
            {
                if (m_NavigationStack.Count > 0)
                {
                    return PeekViewStack();
                }

                return null;
            }
        }

        public void ClearViews()
        {
            Debug.Log("UIManager::ClearViews()");

            // Hide all the views.
            foreach (BaseUIView view in m_ViewLookup.Values)
            {
                view?.Hide();
            }

            // Clear the nav stack.
            m_NavigationStack.Clear();
        }

        public void HideView(UIHandle handle)
        {
            if ((handle == null) || (m_NavigationStack.Count == 0))
            {
                return;
            }

            BaseUIView view = m_NavigationStack.FindLast(x => x.Handle == handle);
            view.Hide();
        }

        public void NavigateBack()
        {
            if (!PopInvalidViews())
            {
                // Pop the current view.
                CurrentDialog?.Hide();
                PopViewStack();
            }

            RestoreStackVisibility();
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

        public BaseUIView ShowView(UIHandle viewHandle, IUIController controller)
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
                if (view.HideUnderlying)
                {
                    for (int i = m_NavigationStack.Count - 1; i >= 0; --i)
                    {
                        m_NavigationStack[i].Hide();

                        if (m_NavigationStack[i].HideUnderlying)
                        {
                            // Further views should already be hidden; no need to continue.
                            break;
                        }
                    }
                }

                view.Controller = controller;
                view.Show();

                if (view.PushToNavigationStack && CurrentDialog != view)
                {
                    m_NavigationStack.Add(view);
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

        private BaseUIView PeekViewStack()
        {
            return m_NavigationStack[m_NavigationStack.Count - 1];
        }

        private bool PopInvalidViews()
        {
            bool popped = false;

            BaseUIView currentView = PeekViewStack();
            while (currentView == null || !m_ViewLookup.ContainsKey(currentView.Handle))
            {
                // Pop destroyed or unregistered views from the top of the stack
                Debug.Log("UIManager::PopInvalidViews() -- null or view not found in lookup");
                PopViewStack();
                popped = true;
            }

            return popped;
        }

        private void PopViewStack()
        {
            m_NavigationStack.RemoveAt(m_NavigationStack.Count - 1);
        }

        private void RestoreStackVisibility()
        {
            PopInvalidViews();

            for (int i = m_NavigationStack.Count - 1; i >= 0; --i)
            {
                m_NavigationStack[i].Show();

                if (m_NavigationStack[i].HideUnderlying)
                {
                    // Everything under this view should remain hidden, so we can stop traversing.
                    break;
                }
            }
        }
    }
}
