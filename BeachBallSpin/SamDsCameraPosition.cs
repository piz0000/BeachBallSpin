using System.Windows.Media.Media3D;

namespace BeachBallSpin
{
    /// <summary>
    /// PerspectiveCamera Position 도움 클래스
    /// </summary>
    public class SamDsCameraPosition
    {
        /// <summary>
        /// Position X Up Down 증감 값 
        /// </summary>
        public static int PositionValueX = 1;
        /// <summary>
        /// Position Y Up Down 증감 값
        /// </summary>
        public static int PositionValueY = 1;
        /// <summary>
        /// Position Z Up Down 증감 값
        /// </summary>
        public static int PositionValueZ = 1;

        /// <summary>
        /// Position X 증가
        /// </summary>
        /// <param name="Camera"></param>
        public static void PositionUpX(PerspectiveCamera Camera)
        {
            Point3D point3D = Camera.Position;

            point3D.X += PositionValueX;

            Camera.Position = point3D;
        }
        /// <summary>
        /// Position X 감소
        /// </summary>
        /// <param name="Camera"></param>
        public static void PositionDownX(PerspectiveCamera Camera)
        {
            Point3D point3D = Camera.Position;

            point3D.X -= PositionValueX;

            Camera.Position = point3D;
        }

        /// <summary>
        /// Position Y 증가
        /// </summary>
        /// <param name="Camera"></param>
        public static void PositionUpY(PerspectiveCamera Camera)
        {
            Point3D point3D = Camera.Position;

            point3D.Y += PositionValueY;

            Camera.Position = point3D;
        }
        /// <summary>
        /// Position Y 감소
        /// </summary>
        /// <param name="Camera"></param>
        public static void PositionDownY(PerspectiveCamera Camera)
        {
            Point3D point3D = Camera.Position;

            point3D.Y -= PositionValueY;

            Camera.Position = point3D;
        }

        /// <summary>
        /// Position Z 증가
        /// </summary>
        /// <param name="Camera"></param>
        public static void PositionUpZ(PerspectiveCamera Camera)
        {
            Point3D point3D = Camera.Position;

            point3D.Z += PositionValueZ;

            Camera.Position = point3D;
        }
        /// <summary>
        /// Position Z 감소
        /// </summary>
        /// <param name="Camera"></param>
        public static void PositionDownZ(PerspectiveCamera Camera)
        {
            Point3D point3D = Camera.Position;

            point3D.Z -= PositionValueZ;

            Camera.Position = point3D;
        }

        public static void SetPosition(PerspectiveCamera Camera, Point3D Point3D)
        {
            Camera.Position = Point3D;
        }
        public static void SetPosition(PerspectiveCamera Camera, double X, double Y, double Z)
        {
            Camera.Position = new Point3D(X, Y, Z);
        }
        public static void SetPositionX(PerspectiveCamera Camera, double X)
        {
            Point3D point3D = Camera.Position;

            point3D.X = X;

            Camera.Position = point3D;
        }
        public static void SetPositionY(PerspectiveCamera Camera, double Y)
        {
            Point3D point3D = Camera.Position;

            point3D.Y = Y;

            Camera.Position = point3D;
        }
        public static void SetPositionZ(PerspectiveCamera Camera, double Z)
        {
            Point3D point3D = Camera.Position;

            point3D.Z = Z;

            Camera.Position = point3D;
        }
    }
}
