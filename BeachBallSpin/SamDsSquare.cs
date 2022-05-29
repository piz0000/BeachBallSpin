using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace BeachBallSpin
{
    /// <summary>
    /// 정사각형
    /// </summary>
    public class SamDsSquare : ModelVisual3D
    {
        GeometryModel3D model = null;
        DirectionalLight light = null;

        /// <summary>
        /// 정사각형 시작 위치
        /// </summary>
        public Point3D SquarePoint;

        /// <summary>
        /// 정사각형 X방향 길이 (가로)
        /// </summary>
        public double SquareWidth { get; protected set; } = 10;
        /// <summary>
        /// 정사각형 Y방향 길이 (세로)
        /// </summary>
        public double SquareHeight { get; protected set; } = 10;
        /// <summary>
        /// 정사각형 Z방향 깊이 (깊이)
        /// </summary>
        public double SquareDepth { get; protected set; } = 10;

        public SamDsSquare()
        {
            Model3DGroup SquareModel3DGroup = new Model3DGroup();

            model = new GeometryModel3D();
            model.Geometry = new MeshGeometry3D();
            SquareModel3DGroup.Children.Add(model);

            light = new DirectionalLight();
            light.Color = Colors.White;
            light.Direction = new Vector3D(-1, -1, -3);
            SquareModel3DGroup.Children.Add(light);

            Content = SquareModel3DGroup;
        }

        /// <summary>
        /// 정사각형 만들기
        /// </summary>
        public void SetSquare(double SquareWidth, double SquareHeight, double SquareDepth)
        {
            this.SquareWidth = SquareWidth;
            this.SquareHeight = SquareHeight;
            this.SquareDepth = SquareDepth;

            Point3D[] Point3Ds = new Point3D[8];

            //1점 => 사각형 첫번째는 시작 위치와 동일하게
            Point3Ds[0] = new Point3D(0, 0, 0);

            //2점
            Point3Ds[1] = new Point3D(SquareWidth, 0, 0);

            //3점
            Point3Ds[2] = new Point3D(SquareWidth, SquareHeight, 0);

            //4점
            Point3Ds[3] = new Point3D(0, SquareHeight, 0);

            //5점
            Point3Ds[4] = new Point3D(0, 0, SquareDepth);

            //6점
            Point3Ds[5] = new Point3D(SquareWidth, 0, SquareDepth);

            //7점
            Point3Ds[6] = new Point3D(SquareWidth, SquareHeight, SquareDepth);

            //8점
            Point3Ds[7] = new Point3D(0, SquareHeight, SquareDepth);

            ((MeshGeometry3D)model.Geometry).Positions = new Point3DCollection(Point3Ds); 
        }

        public void SetSquareLight()
        {

        }

        public void SetSquarePoint3D(Point3D Point3D)
        {
            //시작 위치에서 가로, 세로, 깊이 값을 계산해서 포지션 위치 구하기

            SquarePoint = Point3D;



        }
    }
}
