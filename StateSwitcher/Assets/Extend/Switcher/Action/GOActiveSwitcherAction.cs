using System;
using UnityEngine;

namespace Extend.Switcher.Action {
	[Serializable]
	public class GOActiveSwitcherAction : ISwitcherAction {
		[SerializeField]
		public GameObject m_go;
		[SerializeField]
		public bool m_active;
		
		public void ActiveSwitcher() {
			m_go.SetActive(m_active);
		}
	}
}