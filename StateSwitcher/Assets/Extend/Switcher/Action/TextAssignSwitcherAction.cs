using System;
using TMPro;
using UnityEngine;

namespace Extend.Switcher.Action {
	[Serializable]
	public class TextAssignSwitcherAction : ISwitcherAction {
		[SerializeField]
		private TextMeshProUGUI m_textGUI;

		[SerializeField]
		private string m_text;
		
		public void ActiveSwitcher() {
			m_textGUI.text = m_text;
		}
	}
}