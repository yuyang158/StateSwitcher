using System;
using UnityEngine;
using UnityEngine.UI;

namespace Extend.Switcher.Action {
	[Serializable]
	public class ImageSwitcherAction : ISwitcherAction {
		[SerializeField]
		private Image m_image;

		[SerializeField]
		private Sprite m_sprite;
		
		public void ActiveSwitcher() {
			m_image.sprite = m_sprite;
		}
	}
}