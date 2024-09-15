using UnityEngine.Assertions;

namespace Apparatys.Navigator
{
    public abstract class UIView<ControllerType> : BaseUIView where ControllerType : IUIController
    {
        private ControllerType m_Controller;

        public sealed override IUIController Controller
        {
            get
            {
                return m_Controller;
            }

            internal set
            {
                bool validType = typeof(ControllerType).IsAssignableFrom(value.GetType());
                Assert.IsTrue(validType, $"Cannot assign controller of type '{value.GetType().FullName}' to view of type '{this.GetType().FullName}'. Expected '{typeof(ControllerType).FullName}'.");
                if (validType)
                {
                    m_Controller = (ControllerType)value;
                }
            }
        }

        protected ControllerType GetController()
        {
            return m_Controller;
        }
    }
}
