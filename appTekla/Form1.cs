using System;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;

namespace appTekla
{

    public partial class Form1 : Form
    {
        private readonly Model _myModel;
        private readonly Sap2000.SapObject _modelSap2000;


        public Form1( Model modelTekla , Sap2000.SapObject modelSap2000)
        {
            InitializeComponent();
            _myModel = modelTekla;
            _modelSap2000 = modelSap2000;

        }

        private void btnExcerise_Click(object sender, EventArgs e)
        {
            // Always remember to check that you really have working connection
            if (_myModel.GetConnectionStatus())
            {
                // Loop through X-axis  (these loops should be changed to match current grid)
                for (double PositionX = 0.0; PositionX <= 12000.0; PositionX += 3000.0)
                {
                    // In first and in last line
                    if (PositionX.Equals(0.0) || PositionX.Equals(12000.0))
                    {
                        // Loop through Y-axis to get pad footings on the longer sides of the grid
                        for (double PositionY = 0.0; PositionY <= 30000.0; PositionY += 6000.0)
                        {
                            CreatePadFooting(PositionX, PositionY);
                        }
                    }
                    else
                    {   // Create pad footings on the shorter sides of the grid
                        CreatePadFooting(PositionX, 0.0);
                        CreatePadFooting(PositionX, 30000.0);
                    }
                }
                // Always remember to commit changes to Tekla Structures, otherwise some things might be left in uncertain state
                _myModel.CommitChanges();
            }
        }
        private static void CreatePadFooting(double PositionX, double PositionY)
        {
            Beam PadFooting1 = new Beam();

            PadFooting1.Name = "FOOTING";
            PadFooting1.Profile.ProfileString = "1500*1500";
            PadFooting1.Material.MaterialString = "K30-2";
            PadFooting1.Class = "8";
            PadFooting1.StartPoint.X = PositionX;
            PadFooting1.StartPoint.Y = PositionY;
            PadFooting1.StartPoint.Z = 0.0;
            PadFooting1.EndPoint.X = PositionX;
            PadFooting1.EndPoint.Y = PositionY;
            PadFooting1.EndPoint.Z = -500.0;
            PadFooting1.Position.Rotation = Position.RotationEnum.FRONT;
            PadFooting1.Position.Plane = Position.PlaneEnum.MIDDLE;
            PadFooting1.Position.Depth = Position.DepthEnum.MIDDLE;

            PadFooting1.Insert();
        }
       

        /// <summary>
        /// Method that creates a column to given position and returns the created column.
        /// The created pad footing is recognized as beam in Tekla Structures.
        /// </summary>
        /// <param name="PositionX">X-coordination of the position</param>
        /// <param name="PositionY">Y-coordination of the position</param>
        /// <returns></returns>
    
        private void btnExcerise2_Click(object sender, EventArgs e)
        {
            _modelSap2000.ApplicationStart(Sap2000.eUnits.kN_mm_C, true);
            // Always remember to check that you really have working connection
            if (_myModel.GetConnectionStatus())
            {
                // Loop through X-axis  (these loops should be changed to match current grid)
                for (double PositionX = 0.0; PositionX <= 12000.0; PositionX += 3000.0)
                {
                    // In first and in last line
                    if (PositionX.Equals(0.0) || PositionX.Equals(12000.0))
                    {
                        // Loop through Y-axis to get pad footings on the longer sides of the grid
                        for (double PositionY = 0.0; PositionY <= 30000.0; PositionY += 6000.0)
                        {
                            CreateFootingAndColumn(PositionX, PositionY);
                        }
                    }
                    else
                    {
                        CreateFootingAndColumn(PositionX, 0.0);
                        CreateFootingAndColumn(PositionX, 30000.0);
                    }
                }
                // Always remember to commit changes to Tekla Structures, otherwise some things might be left in uncertain state
                _myModel.CommitChanges();
            }
        }



        private static ModelObject CreatePadFooting(double PositionX, double PositionY, double FootingSize)
        {
            Beam PadFooting = new Beam();

            PadFooting.Name = "FOOTING";
            PadFooting.Profile.ProfileString = FootingSize + "*" + FootingSize; //"1500*1500";
            PadFooting.Material.MaterialString = "K30-2";
            PadFooting.Class = "8";
            PadFooting.StartPoint.X = PositionX;
            PadFooting.StartPoint.Y = PositionY;
            PadFooting.EndPoint.X = PositionX;
            PadFooting.EndPoint.Y = PositionY;
            PadFooting.EndPoint.Z = -500.0;
            PadFooting.Position.Rotation = Position.RotationEnum.FRONT;
            PadFooting.Position.Plane = Position.PlaneEnum.MIDDLE;
            PadFooting.Position.Depth = Position.DepthEnum.MIDDLE;

            if (!PadFooting.Insert())
            {
                Console.WriteLine("Insertion of pad footing failed.");
            }

            return PadFooting;
        }

        private static ModelObject CreateColumn(double PositionX, double PositionY)
        {
            Beam Column = new Beam();

            Column.Name = "COLUMN";
            Column.Profile.ProfileString = "HEA400";
            Column.Material.MaterialString = "S235JR";
            Column.Class = "2";
            Column.StartPoint.X = PositionX;
            Column.StartPoint.Y = PositionY;
            Column.EndPoint.X = PositionX;
            Column.EndPoint.Y = PositionY;
            Column.EndPoint.Z = 5000.0;
            Column.Position.Rotation = Position.RotationEnum.FRONT;
            Column.Position.Plane = Position.PlaneEnum.MIDDLE;
            Column.Position.Depth = Position.DepthEnum.MIDDLE;

            if (!Column.Insert())
            {
                Console.WriteLine("Insertion of column failed.");
            }

            return Column;
        }


        private static void CreateBasePlate(ModelObject PrimaryObject, ModelObject SecondaryObject)
        {
            Connection BasePlate = new Connection();

            BasePlate.Name = "Stiffened Base Plate";
            BasePlate.Number = 1014;
            BasePlate.LoadAttributesFromFile("standard");
            BasePlate.UpVector = new Vector(0, 0, 1000);
            BasePlate.PositionType = PositionTypeEnum.COLLISION_PLANE;

            BasePlate.SetPrimaryObject(PrimaryObject);
            BasePlate.SetSecondaryObject(SecondaryObject);

            BasePlate.SetAttribute("cut", 1);  //Enable anchor rods

            if (!BasePlate.Insert())
            {
                Console.WriteLine("Insertion of stiffened base plate failed.");
            }
        }
        private static void CreateFootingAndColumn(double PositionX, double PositionY)
        {
            const double FootingSize = 1500;

            ModelObject PadFooting = CreatePadFooting(PositionX, PositionY, FootingSize);
            ModelObject Column = CreateColumn(PositionX, PositionY);
            CreateBasePlate(Column, PadFooting);
        }
    }
   

}
