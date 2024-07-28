using System.Collections.ObjectModel;
using UnityEngine;

namespace Apparatys.Navigator
{
    public class UIViewCollection : MonoBehaviour
    {
        [SerializeField]
        private BaseUIView[] m_Views = new BaseUIView[0];

        public ReadOnlyCollection<BaseUIView> Views
        {
            get { return new ReadOnlyCollection<BaseUIView>(m_Views); }
        }
    }
}
