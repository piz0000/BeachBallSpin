using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace BeachBallSpin
{
    public class SamDsBeachBall : ModelVisual3D
    {
        public double Radius { get; set; } = 1.5;

        public SamDsBeachBall()
        {
            Init();
        }
        public SamDsBeachBall(double radius)
        {
            Radius = radius;

            Init();
        }

        public void Init()
        {
            Model3DGroup model3DGroup = new Model3DGroup();
            model3DGroup.Children.Add(new AmbientLight(Color.FromRgb(128, 128, 128)));
            model3DGroup.Children.Add(new DirectionalLight(Color.FromRgb(128, 128, 128), new Vector3D(2, -3, -1)));

            ModelVisual3D modelVisual3D2 = new ModelVisual3D
            {
                Content = model3DGroup
            };
            Children.Add(modelVisual3D2);

            MeshGeometry3D meshGeometry3D = GetSphereMeshGeometry3D(new Point3D(0, 0, 0), Radius, 144, 72);
            meshGeometry3D.Freeze();

            DrawingBrush drawingBrush = new DrawingBrush(DrawingGroup());
            drawingBrush.Freeze();

            //회전 애니메이션
            AxisAngleRotation3D axisAngleRotation3D = new AxisAngleRotation3D(new Vector3D(1, 1, 0), 0);
            DoubleAnimation doubleAnimation = new DoubleAnimation(360, new Duration(TimeSpan.FromSeconds(5)))
            {
                RepeatBehavior = RepeatBehavior.Forever
            };
            axisAngleRotation3D.BeginAnimation(AxisAngleRotation3D.AngleProperty, doubleAnimation);

            ModelVisual3D modelVisual3D = new ModelVisual3D
            {
                Content = new GeometryModel3D()
                {
                    Geometry = meshGeometry3D,
                    Material = new DiffuseMaterial(drawingBrush),
                    Transform = new RotateTransform3D(axisAngleRotation3D)
                }
            };
            Children.Add(modelVisual3D);
        }

        DrawingGroup DrawingGroup()
        {
            Brush[] brushArray = new Brush[6]
            {
                Brushes.Red,
                Brushes.Blue,
                Brushes.Yellow,
                Brushes.Orange,
                Brushes.Green,
                Brushes.White
            };

            DrawingGroup drawingGroup = new DrawingGroup();
            for (int Index = 0; Index < brushArray.Length; Index++)
            {
                RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(10 * Index, 0, 10, 60));
                GeometryDrawing geometryDrawing = new GeometryDrawing(brushArray[Index], null, rectangleGeometry);
                drawingGroup.Children.Add(geometryDrawing);
            }
            return drawingGroup;
        }

        /// <summary>
        /// 구 메쉬 기하학 3D 구하기
        /// </summary>
        /// <param name="centerPoint3D">중앙 포인트 3D</param>
        /// <param name="radius">반경</param>
        /// <param name="sliceCount">슬라이스 수</param>
        /// <param name="stackCount">스택 수</param>
        /// <returns>구 메쉬 기하학 3D</returns>
        MeshGeometry3D GetSphereMeshGeometry3D(Point3D centerPoint3D, double radius, int sliceCount, int stackCount)
        {
            MeshGeometry3D meshGeometry3D = new MeshGeometry3D();

            for (int stack = 0; stack <= stackCount; stack++)
            {
                double phi = Math.PI / 2 - stack * Math.PI / stackCount;
                double y = radius * Math.Sin(phi);
                double scale = -radius * Math.Cos(phi);

                for (int slice = 0; slice <= sliceCount; slice++)
                {
                    double theta = slice * 2 * Math.PI / sliceCount;
                    double x = scale * Math.Sin(theta);
                    double z = scale * Math.Cos(theta);

                    Vector3D normal = new Vector3D(x, y, z);

                    meshGeometry3D.Normals.Add(normal);

                    meshGeometry3D.Positions.Add(normal + centerPoint3D);

                    meshGeometry3D.TextureCoordinates.Add
                    (
                        new Point
                        (
                            (double)slice / sliceCount,
                            (double)stack / stackCount
                        )
                    );
                }
            }

            for (int stack = 0; stack < stackCount; stack++)
            {
                for (int slice = 0; slice < sliceCount; slice++)
                {
                    int number = sliceCount + 1;

                    if (stack != 0)
                    {
                        meshGeometry3D.TriangleIndices.Add((stack + 0) * number + slice);
                        meshGeometry3D.TriangleIndices.Add((stack + 1) * number + slice);
                        meshGeometry3D.TriangleIndices.Add((stack + 0) * number + slice + 1);
                    }

                    if (stack != stackCount - 1)
                    {
                        meshGeometry3D.TriangleIndices.Add((stack + 0) * number + slice + 1);
                        meshGeometry3D.TriangleIndices.Add((stack + 1) * number + slice);
                        meshGeometry3D.TriangleIndices.Add((stack + 1) * number + slice + 1);
                    }
                }
            }

            return meshGeometry3D;
        }

    }
}
