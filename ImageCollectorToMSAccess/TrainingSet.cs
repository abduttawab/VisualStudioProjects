using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;





using System.Data.SqlClient;
using System.IO;

using Emgu.CV;
using Emgu.Util;

using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace Face_Recognizer
{
    public partial class ImageDB : Form

    {
        




















        private readonly TrainingSetDBGateWay trainingSetDbGateWay;
        private readonly StoreDataToDB storeDataToDb;
       

        public TrainingSetDBGateWay TrainingSetDbGateWay
        {
            get { return trainingSetDbGateWay; }
        }

        public StoreDataToDB StoreDataToDb
        {
            get { return storeDataToDb; }
        }

        //public FaceDetectionProcess FaceDetectionProcess
        //{
        //    get { return faceDetectionProcess; }
        //}




        private Capture captureLive;
        private HaarCascade haarCascade1;
        private Bitmap[] faceList;
        private int faceNo = 0;
        private Image<Bgr, Byte> testImage;


        public Capture CaptureLive
        {
            set { captureLive = value; }
            get { return captureLive; }
        }

        public Bitmap[] FaceList
        {
            set { faceList = value; }
            get { return faceList; }
        }

        public int FaceNo
        {
            set { faceNo = value; }
            get { return faceNo; }
        }

        public Image<Bgr, byte> TestImage
        {
            set { testImage = value; }
            get { return testImage; }
        }

        public void ImageDB_Load(object sender, EventArgs e)
        {

            haarCascade1 = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

            TrainingSetDbGateWay.ConnectToDatabase();



        }




        public void DetectFaces()
        {


            Image<Gray, byte> grayImage = testImage.Convert<Gray, byte>();




            //minimumNighbors = int.Parse(minNeighborComboBox.Text);
            //scaleIncreseRate = Double.Parse(scaleComboBox.Text);
            //windowsSize = int.Parse(minDetectionScaleTextBox.Text);

            var faces = grayImage.DetectHaarCascade(haarCascade1, 1.3, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];

            if (faces.Length > 0)
            {


                // MessageBox.Show("Total Detected Faces: "+ faces.Length.ToString());

                Bitmap bitmapInput = grayImage.ToBitmap();

                Bitmap extractedFace;

                Graphics facePad;



                faceList = new Bitmap[faces.Length];

                faceNo = 0;

                foreach (var face in faces)

                {
                    testImage.Draw(face.rect, new Bgr(Color.Green), 3);

                    extractedFace = new Bitmap(face.rect.Width, face.rect.Height);

                    facePad = Graphics.FromImage(extractedFace);

                    facePad.DrawImage(bitmapInput, 0, 0, face.rect, GraphicsUnit.Pixel);


                    faceList[faceNo] = extractedFace;
                    faceNo++;


                }

                ImageBox.Image = testImage;

                MessageBox.Show("Faces Successfully Extracted !!!");


                ExtractedFacepictureBox.Image = faceList[0];


               ButtonSave.Enabled = true;

                FaceNametextBox.Enabled = true;


                if (faces.Length > 1)


                {
                    ExtracedFaceNextbutton.Enabled = true;

                    ExtracedFacePrebutton.Enabled = true;
                }

                else
                {
                    ExtracedFaceNextbutton.Enabled = false;

                    ExtracedFacePrebutton.Enabled = false;

                }



            }



            else
            {

                MessageBox.Show("No Face Detected!!");


            }



        }

        public void processFrameAndUpdateGUI(object sender, EventArgs e)
        {


            testImage = captureLive.QueryFrame();

            if (testImage != null)



            {

                Image<Gray, byte> grayFrame = testImage.Convert<Gray, byte>();

                var faces = grayFrame.DetectHaarCascade(haarCascade1, 1.3, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(25, 25))[0];


                foreach (var face in faces)

                {
                    testImage.Draw(face.rect, new Bgr(Color.Green), 3);




                }


            }


            ImageBox.Image = testImage;


        }










        public Button ButtonSave
        {
            set { buttonSave = value; }
            get { return buttonSave; }
        }

        public PictureBox ExtractedFacepictureBox
        {
            set { extractedFacepictureBox = value; }
            get { return extractedFacepictureBox; }
        }

        public TextBox FaceNametextBox
        {
            set { faceNametextBox = value; }
            get { return faceNametextBox; }
        }

        public Button ExtracedFaceNextbutton
        {
            set { extracedFaceNextbutton = value; }
            get { return extracedFaceNextbutton; }
        }

        public Button ExtracedFacePrebutton
        {
            set { extracedFacePrebutton = value; }
            get { return extracedFacePrebutton; }
        }

        public ImageBox ImageBox
        {
            set { imageBox = value; }
            get { return imageBox; }
        }


        public ImageDB()
        {
            InitializeComponent();
            trainingSetDbGateWay = new TrainingSetDBGateWay();
            storeDataToDb = new StoreDataToDB(this);
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {



            try

            {
                TrainingSetDbGateWay.LocalDataTable.Rows[TrainingSetDbGateWay.RowNumber].Delete();

                SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(TrainingSetDbGateWay.DataAdater);

                MessageBox.Show("Image Record Successfully Deleted!!");

                TrainingSetDbGateWay.DataAdater.Update(TrainingSetDbGateWay.LocalDataTable);

                TrainingSetDbGateWay.refreshDBconnection();

                TrainingSetDbGateWay.RowNumber--;

                pictureBox1.Image = TrainingSetDbGateWay.ReadImageFromDB();
                importedFaceNametextBox.Text = TrainingSetDbGateWay.LocalDataTable.Rows[TrainingSetDbGateWay.RowNumber]["PersonName"].ToString();


            }


            catch (Exception ex)

            {

                MessageBox.Show(ex.ToString());

            }


        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)


            {



              Image inputImage = Image.FromFile(openFileDialog.FileName);


                TestImage = new Image<Bgr, byte>(new Bitmap(inputImage));

                imageBox.Image = TestImage;


                DetectFaces();

               



            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {
                StoreDataToDb.StoreData(extractedFacepictureBox.Image, faceNametextBox.Text);

            }

            catch(Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }

          

           
        }


       

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (TrainingSetDbGateWay.RowNumber == TrainingSetDbGateWay.LocalDataTable.Rows.Count - 1)
            {

                MessageBox.Show("You Have Reached The Last Image!!");

            }

            else {
                TrainingSetDbGateWay.RowNumber++;
                pictureBox1.Image = TrainingSetDbGateWay.ReadImageFromDB();

                importedFaceNametextBox.Text = TrainingSetDbGateWay.LocalDataTable.Rows[TrainingSetDbGateWay.RowNumber]["PersonName"].ToString();
                PersonNamelabel.Text = (TrainingSetDbGateWay.RowNumber + 1).ToString();


            }

        }

        private void buttonPre_Click(object sender, EventArgs e)
        {
            if (TrainingSetDbGateWay.RowNumber == 0)
            {

                MessageBox.Show("This Is The First Image");

            }

            else {
                TrainingSetDbGateWay.RowNumber--;
                pictureBox1.Image = TrainingSetDbGateWay.ReadImageFromDB();

                importedFaceNametextBox.Text = TrainingSetDbGateWay.LocalDataTable.Rows[TrainingSetDbGateWay.RowNumber]["PersonName"].ToString();
                PersonNamelabel.Text = (TrainingSetDbGateWay.RowNumber + 1).ToString();

            }


        }

     

       
        private void buttonstartLiveCam_Click(object sender, EventArgs e)
        {
            if (CaptureLive != null)
            {
                if (buttonstartLiveCam.Text == "Pause")
                {  //if camera is getting frames then pause the capture and set button Text to
                    // "Resume" for resuming capture
                    buttonstartLiveCam.Text = "Resume"; //
                    Application.Idle -= processFrameAndUpdateGUI;

                    DetectFaces();

                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Pause" for pausing capture
                    buttonstartLiveCam.Text = "Pause";
                    Application.Idle += processFrameAndUpdateGUI;
                }

            }


        }

        private void selectCamcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {



            //Set the camera number to the one selected via combo box
            int CamNumber = 0;
            CamNumber = int.Parse(selectCamcomboBox.Text);

            //Start the selected camera
            #region if capture is not created, create it now
            if (CaptureLive == null)
            {
                try
                {
                   CaptureLive = new Capture(CamNumber);
                    
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            //Start showing the stream from camera
            buttonstartLiveCam_Click(sender, e);

            buttonstartLiveCam.Enabled = true;   

        }

      

        private void extracedFaceNextbutton_Click(object sender, EventArgs e)
        {


            if(FaceNo< FaceList.Length-1)

            {
                FaceNo++;

                extractedFacepictureBox.Image = FaceList[FaceNo];


            }

            


        }

        private void extracedFacePrebutton_Click(object sender, EventArgs e)
        {


            if (FaceNo > 0)


            {
                FaceNo--;

                extractedFacepictureBox.Image =FaceList[FaceNo];

            }

            else
            {
                MessageBox.Show("Nothing Detected For Extraction!!");
            }



        }

        private void goToFirstImageButton_Click(object sender, EventArgs e)
        {
            TrainingSetDbGateWay.refreshDBconnection();
            TrainingSetDbGateWay.RowNumber = 0;
            pictureBox1.Image = TrainingSetDbGateWay.ReadImageFromDB();

            importedFaceNametextBox.Text = TrainingSetDbGateWay.LocalDataTable.Rows[TrainingSetDbGateWay.RowNumber]["PersonName"].ToString();

            PersonNamelabel.Text =(TrainingSetDbGateWay.RowNumber + 1).ToString();

            MessageBox.Show("You Have Reached The First Image In List!!!");

            buttonNext.Enabled = true;
            buttonPre.Enabled = true;
            buttonDelete.Enabled = true;
            goToLastImageButton.Enabled = true;


        }

        private void goToLastImageButton_Click(object sender, EventArgs e)
        {
            int totalRows = TrainingSetDbGateWay.LocalDataTable.Rows.Count;


            TrainingSetDbGateWay.refreshDBconnection();
            TrainingSetDbGateWay.RowNumber = totalRows-1;
            pictureBox1.Image = TrainingSetDbGateWay.ReadImageFromDB();

           importedFaceNametextBox.Text = TrainingSetDbGateWay.LocalDataTable.Rows[TrainingSetDbGateWay.RowNumber]["PersonName"].ToString();
            PersonNamelabel.Text = (TrainingSetDbGateWay.RowNumber + 1).ToString();



            MessageBox.Show("You Have Reached The First Image In List!!!");

        }

        private void updateFaceNameButton_Click(object sender, EventArgs e)
        {


           


            try {

                PersonNamelabel.Text = (TrainingSetDbGateWay.RowNumber + 1).ToString();


                TrainingSetDbGateWay.LocalDataTable.Rows[TrainingSetDbGateWay.RowNumber]["PersonName"] = importedFaceNametextBox.Text;

                SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(TrainingSetDbGateWay.DataAdater);


                MessageBox.Show("Successfully Updated!!!");


                TrainingSetDbGateWay.DataAdater.Update(TrainingSetDbGateWay.LocalDataTable);

                TrainingSetDbGateWay.refreshDBconnection();

              



            }

            catch (Exception ex) {


              
                MessageBox.Show(ex.ToString());

            }

           

           


        }
    }

    }

