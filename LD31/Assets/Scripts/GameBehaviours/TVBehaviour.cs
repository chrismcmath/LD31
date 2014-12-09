using System.Collections;

using UnityEngine;

using LD31;
using LD31.Controllers;

namespace LD31.GameBehaviours {
    public abstract class TVBehaviour : PlayerBehaviour {
        protected Transform _TVTransform = null;

        public TVBehaviour() : base() {
            _TVTransform = Model.Instance.TVController.transform;
        }
    }
}
