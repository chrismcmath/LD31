using System.Collections;

using UnityEngine;

using LD31;
using LD31.Controllers;

namespace LD31.GameBehaviours {
    public abstract class PlayerBehaviour : GameBehaviour {
        protected PlayerController _PlayerController = null;
        protected Transform _PlayerTransform = null;

        public PlayerBehaviour() {
            _PlayerController = Model.Instance.PlayerController;
            _PlayerTransform = _PlayerController.transform;
        }
    }
}
