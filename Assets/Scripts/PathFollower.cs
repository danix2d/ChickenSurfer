using UnityEngine;
using PathCreation;

    public class PathFollower : MonoBehaviour
    {
        public Control control;
        public PathCreator pathCreator;

        private PathCreator pathChanged;

        public float speed = 5;

        float distanceTravelled;

        float xOffest;

        public float horizontalLimit;

        public GameObject cameraOffset;
        private Vector3 cameraOffsetPos;

        float _lastFrameFingerPositionX;
        float _moveFactorX;

        Vector3 desiredPoint;
        Quaternion desiredPointRot;

        void Start() 
        {
            pathChanged = pathCreator;

            cameraOffsetPos = cameraOffset.transform.localPosition;
        }

        void Update()
        {

            if(pathChanged != pathCreator)
            {
                OnPathChanged();
            }

            UserInput();
            FollowPath();
            CameraOffset();

        }


        void UserInput()
        {

            if(control.canMove == false) return;

            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }
        }

        void FollowPath()
        {
                if(control.canMove == false) return;

                distanceTravelled += speed * Time.deltaTime;

                desiredPoint = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                transform.position = desiredPoint;

                xOffest += _moveFactorX * Time.deltaTime * 0.5f;
                xOffest = Mathf.Clamp(xOffest,-horizontalLimit,horizontalLimit);

                desiredPoint = transform.TransformPoint(new Vector3(xOffest,0,0));
                transform.position = desiredPoint;

                desiredPointRot = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                desiredPointRot.x = 0;
                desiredPointRot.z = 0;

                transform.rotation = desiredPointRot;
        }

        void CameraOffset()
        {
            cameraOffset.transform.localPosition = new Vector3(-xOffest + cameraOffsetPos.x,cameraOffset.transform.localPosition.y,cameraOffset.transform.localPosition.z);
        }

        void OnPathChanged() {
            Debug.Log("Path Changed");

            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
            pathChanged = pathCreator;
        }
    }
