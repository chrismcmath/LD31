using System.Collections;

using UnityEngine;

using LD31.Controllers;

namespace LD31 {
    public class Model : Singleton<Model> {
        public DoorController DoorController = null;
        public PlayerController PlayerController = null;
        public TVController TVController = null;
        public ObstacleGeneratorController ObstacleGeneratorController = null;
        public FlashController FlashController = null;
        public CameraShakeController CameraShakeController = null;
        public SoundsController SoundsController = null;
        public GameObject Particles = null;
        public Transform WordTransform = null;
    }
}

