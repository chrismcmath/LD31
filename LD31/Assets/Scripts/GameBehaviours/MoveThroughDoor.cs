using System.Collections;

using UnityEngine;

using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class MoveThroughDoor : PlayerBehaviour {
        public static readonly float CHANGE_BEHAVIOUR_THRESHOLD = -3f;
        private float _Speed;

        public MoveThroughDoor(float speed) : base() {
            _Speed = speed;
            Model.Instance.DoorController.Open();
        }

        public override GameBehaviour Update() {
            _PlayerTransform.localPosition = new Vector3(
                    _PlayerTransform.localPosition.x,
                    _PlayerTransform.localPosition.y,
                    _PlayerTransform.localPosition.z + _Speed
                    );

            if (_PlayerTransform.localPosition.z > (CHANGE_BEHAVIOUR_THRESHOLD)) {
                GameObject.Destroy(Model.Instance.DoorController.gameObject);
                Model.Instance.Particles.SetActive(true);
                return new TVGame();
            }

            return this;
        }
    }
}

