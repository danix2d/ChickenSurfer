using UnityEngine;
using PathCreation;

    public class PathAuto : MonoBehaviour
    {
        public PathCreator pathCreator;

        public float speed = 5;

        float distanceTravelled;

        Vector3 desiredPoint;
        Quaternion desiredPointRot;

        void Update()
        {
            FollowPath();
        }

        void FollowPath()
        {

                distanceTravelled += speed * Time.deltaTime;

                desiredPoint = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Loop);
                transform.position = desiredPoint;

                desiredPointRot = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                desiredPointRot.x = 0;
                desiredPointRot.z = 0;

                transform.rotation = desiredPointRot;
        }
    }
