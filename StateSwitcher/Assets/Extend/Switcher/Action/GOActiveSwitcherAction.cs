using System;
using UnityEngine;

namespace Extend.Switcher.Action {
	[Serializable]
	public class GOActiveSwitcherAction : ISwitcherAction {
		public GameObject GO;
		public bool Active;
		
		public void ActiveSwitcher() {
			GO.SetActive(Active);
		}
	}
}