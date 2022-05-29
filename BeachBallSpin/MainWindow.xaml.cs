using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace BeachBallSpin
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public PerspectiveCamera Camera => (PerspectiveCamera)Viewport3D_Draw.Camera;


        public MainWindow()
        {
            InitializeComponent();

            Viewport3D_Draw.Camera = new PerspectiveCamera();

            Camera.Position = new Point3D(-40, 40, 40);
            Camera.LookDirection = new Vector3D(40, -40, -40);
            //Camera.FieldOfView = 60;
            //Camera.FarPlaneDistance = 20;
            Camera.UpDirection = new Vector3D(0, 0, 1);
            //Camera.NearPlaneDistance = 0;

            double minSize = Width > Height ? Height : Width;
            minSize /= 10;
            Viewport3D_Draw.Children.Add(new SamDsBeachBall(minSize));

            //SamDsSquare Square = new SamDsSquare();
            //Square.SetSquare(50, 50, 50);

            //Viewport3D_Draw.Children.Add(Square);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            switch (e.Key)
            {
                case Key.W: SamDsCameraPosition.PositionUpY(Camera); break;
                case Key.S: SamDsCameraPosition.PositionDownY(Camera); break;
                case Key.A: SamDsCameraPosition.PositionDownX(Camera); break;
                case Key.D: SamDsCameraPosition.PositionUpX(Camera); break;
                case Key.Q: SamDsCameraPosition.PositionUpZ(Camera); break;
                case Key.E: SamDsCameraPosition.PositionDownZ(Camera); break;
                case Key.Escape: Close(); break;
            }

        }

    }
}
