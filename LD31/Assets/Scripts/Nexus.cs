using System.Collections;

using UnityEngine;

//using LD31.Controllers;

using LD31.GameBehaviours;

namespace LD31 {
    public class Nexus : MonoBehaviour {
        private GameBehaviour _CurrentBehaviour = null;

        public void Start() {
            _CurrentBehaviour = new MoveToDoor();
            //_CurrentBehaviour = new DebugToScreen();
        }

        public void Update() {
            _CurrentBehaviour = _CurrentBehaviour.Update();
        }
    }
}

