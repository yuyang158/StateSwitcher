using System;
using UnityEngine;
using UnityEngine.UI;

namespace Extend.Switcher.Action {
	[Serializable]
	public class GraphicMaterialSwitcherAction : ISwitcherAction {
		[SerializeField]
		private Graphic m_graphic;

		[SerializeField]
		private Material m_material;
		public void ActiveSwitcher() {
			m_graphic.material = m_material;
		}
	}
}