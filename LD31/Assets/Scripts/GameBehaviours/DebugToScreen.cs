using System.Collections;

using UnityEngine;

using LD31;
using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class DebugToScreen : PlayerBehaviour {

        public DebugToScreen() : base() {
            _PlayerTransform.localPosition = new Vector3(0f, 0.9179498f, 0.05969765f);

            Model.Instance.Particles.SetActive(true);
            GameObject.Destroy(Model.Instance.DoorController.gameObject);
        }

        public override GameBehaviour Update() {
            return new TVGame();
        }
    }
}
