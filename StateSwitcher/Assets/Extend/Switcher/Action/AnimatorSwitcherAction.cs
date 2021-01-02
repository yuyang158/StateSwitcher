using System;
using Extend.Common;
using UnityEngine;

namespace Extend.Switcher.Action {
	[Serializable]
	public class AnimatorSwitcherAction : ISwitcherAction {
		[SerializeField]
		public AnimatorParamProcessor m_processor;

		public void ActiveSwitcher() {
			m_processor.Apply();
		}
	}
}