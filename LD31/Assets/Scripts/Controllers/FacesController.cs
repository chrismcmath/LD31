using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace LD31.Controllers {
    public class FacesController : MonoBehaviour {
        public FaceController LeftFace = null;
        public FaceController RightFace = null;
        public FaceController TopFace = null;
        public FaceController BottomFace = null;
        public FaceController MiddleFace = null;

        public void Reset(
                string[] leftParams,
                string[] rightParams,
                string[] topParams,
                string[] bottomParams,
                string[] middleParams) {
            LeftFace.Setup(leftParams);
            RightFace.Setup(rightParams);
            TopFace.Setup(topParams);
            BottomFace.Setup(bottomParams);
            MiddleFace.Setup(middleParams);
        }

        public void SetSuccess(Config.Direction direction) {
            FaceController targetFace = GetFaceFromDirection(direction);
            targetFace.SetSuccess();
            MiddleFace.SetSuccess();
        }

        public void SetFail(Config.Direction direction) {
            TurnAllOuterFacesOff();

            FaceController targetFace = GetFaceFromDirection(direction);
            targetFace.SetFail();
            MiddleFace.SetFail();
        }

        public void TurnAllOuterFacesOff() {
            LeftFace.SetOff();
            RightFace.SetOff();
            TopFace.SetOff();
            BottomFace.SetOff();
        }

        public FaceController GetFaceFromDirection(Config.Direction direction) {
            switch (direction) {
                case Config.Direction.UP: 
                    return TopFace;
                case Config.Direction.DOWN: 
                    return BottomFace;
                case Config.Direction.LEFT: 
                    return LeftFace;
                case Config.Direction.RIGHT: 
                    return RightFace;
                default:
                    return null;
            }
        }
    }
}

