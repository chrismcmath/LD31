using System.Collections;

using UnityEngine;

using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class SetupInitialPlayerPosition : PlayerBehaviour {
        public static readonly Vector3 INITIAL_PLAYER_POSITION = new Vector3(0f , 1f,  -10000f);

        public SetupInitialPlayerPosition() : base() {}

        public override GameBehaviour Update() {
            _PlayerTransform.localPosition = INITIAL_PLAYER_POSITION;

            return new MoveToDoor();
        }
    }
}

