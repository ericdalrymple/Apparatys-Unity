using UnityEngine;

namespace Apparatys.Navigator
{
    public abstract class BaseUIView : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Handle used to uniquely identify this view.")]
        private UIHandle m_Handle = null;

        [SerializeField]
        [Tooltip("Whether to hide underlying views when this view is shown.")]
        private bool m_HideUnderlying = true;

        [SerializeField]
        [Tooltip("Whether this view will be traversed when navigating backwards.")]
        private bool m_PushToNavigationStack = true;

        public abstract IUIController Controller { get; internal set; }

        public UIHandle Handle
        {
            get { return m_Handle; }
        }

        public bool IsVisible
        {
            get { return isActiveAndEnabled; }
        }

        public bool PushToNavigationStack
        {
            get { return m_PushToNavigationStack; }
        }

        public bool HideUnderlying
        {
            get { return m_HideUnderlying; }
        }

        internal virtual void Tick() { }

        internal void Hide()
        {
            gameObject.SetActive(false);
            OnWillHide();
            OnHidden();
        }

        internal void Show()
        {
            gameObject.SetActive(true);
            OnWillShow();
            OnShown();
        }

        protected virtual void OnWillShow() { }
        protected virtual void OnShown() { }
        protected virtual void OnWillHide() { }
        protected virtual void OnHidden() { }
    }
}
