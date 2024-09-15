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

            set
            {
                bool validType = typeof(ControllerType).IsAssignableFrom(value.GetType());
                Assert.IsTrue(validType);
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
