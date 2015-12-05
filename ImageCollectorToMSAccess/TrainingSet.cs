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
namespace Face_Recognizer
{
    public partial class ImageDB : Form

    {

        




        SqlConnection dbConnection = new SqlConnection();

        SqlDataAdapter dataAdater;

        DataTable localDataTable = new DataTable();

        int rowPosition= 0;
        int rowNumber=0;




      
        
        private Capture captureLive;
        private HaarCascade haarCascade1;
        private int windowsSize = 0;
        private Double scaleIncreseRate = 1.1;
        private int minimumNighbors = 3;



        Bitmap[] faceList;

        int faceNo = 0;


        Image<Bgr, Byte> testImage;













        public void ConnectToDatabase() {




            dbConnection.ConnectionString = "Data Source = ASIF-PC; Initial Catalog = PictureBoxDB; User ID = sa; Password = ATBRasif12";

            dbConnection.Open();

            dataAdater = new SqlDataAdapter("Select * from pictureData", dbConnection);

           


            dataAdater.Fill(localDataTable);

            dbConnection.Close();


            if (localDataTable.Rows.Count !=0) {

                rowPosition = localDataTable.Rows.Count;
            }



        }


       









        public ImageDB()
        {
            InitializeComponent();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {



            try

            {

                localDataTable.Rows[rowNumber].Delete();

                SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(dataAdater);

                MessageBox.Show("Image Record Successfully Deleted!!");

                dataAdater.Update(localDataTable);

                refreshDBconnection();

                rowNumber--;

                pictureBox1.Image = ReadImageFromDB();


            }


            catch (Exception ex)

            {

                MessageBox.Show(ex.ToString());

            }


        }

        private void ImageDB_Load(object sender, EventArgs e)
        {




            haarCascade1 = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

            ConnectToDatabase();


            refreshDBconnection();

            rowNumber = 0;
            pictureBox1.Image = ReadImageFromDB();
            buttonNext.Enabled = true;
            buttonPre.Enabled = true;
            buttonDelete.Enabled = true;



        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)


            {



              Image inputImage = Image.FromFile(openFileDialog.FileName);


              testImage = new Image<Bgr, byte>(new Bitmap(inputImage));

                imageBox.Image = testImage;


                DetectFaces();

               



            }
        }

        private void DetectFaces()
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

                    imageBox.Image = testImage;

                    MessageBox.Show("Faces Successfully Extracted !!!");



                    extractedFacepictureBox.Image = faceList[0];


                    buttonSave.Enabled = true;

                    faceNametextBox.Enabled = true;


                    if (faces.Length > 1)


                    {

                        extracedFaceNextbutton.Enabled = true;

                        extracedFacePrebutton.Enabled = true;
                    }

                    else
                    {

                        extracedFaceNextbutton.Enabled = false;

                        extracedFacePrebutton.Enabled = false;

                    }






                }



                else
                {

                    MessageBox.Show("No Face Detected!!");


                }



            



        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {
                StoreData(ConverImageToByte(pictureBox1.Image));

            }

            catch(Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }

          

           
        }

      

        private byte[] ConverImageToByte(Image inputImage)
        {


            

          var bitmapimage = new Bitmap(inputImage);


            MemoryStream Mystream = new MemoryStream();


         bitmapimage.Save(Mystream, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] byteImage = Mystream.ToArray();

            return byteImage;

        }


        private void StoreData(byte[] byteImage)
        {

            if (dbConnection.State.Equals(ConnectionState.Closed))

            {

                dbConnection.Open();
                try
                {

                    MessageBox.Show("Saving Image at Index:" + rowPosition.ToString());

                    SqlCommand InsertCommand = new SqlCommand("INSERT INTO pictureData (ImageID, Image) VALUES('"+rowPosition.ToString()+"',@MyImage)", dbConnection);


                    InsertCommand.Parameters.AddWithValue("@MyImage", byteImage);

                  

                 int rowAffected = InsertCommand.ExecuteNonQuery();

                MessageBox.Show("Image Data Successfully Uploaded in " + rowAffected.ToString() + "row");

                    rowPosition++;


                }

                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message.ToString());
                    MessageBox.Show(ex.StackTrace.ToString());
                }


                finally
                {


                    refreshDBconnection();

                }



            }
              



            }

        private void refreshDBconnection()
        {
            if (dbConnection.State.Equals(ConnectionState.Open)) {

                dbConnection.Close();
                localDataTable.Clear();
                ConnectToDatabase();

            }
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
      


        }

        private Image ReadImageFromDB()
        {
            Image fectImage;

            if (rowNumber >= 0)
            {

                byte[] fetchImageBytes = (byte[])localDataTable.Rows[rowNumber]["Image"];

                MemoryStream memoryStream2 = new MemoryStream(fetchImageBytes);

                fectImage = Image.FromStream(memoryStream2);

                return fectImage;




            }


            else {

                MessageBox.Show("There is no image in the Database. Pleace Reconnect Or insert some image.");
                return null;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (rowNumber == localDataTable.Rows.Count - 1)
            {

                MessageBox.Show("You Have Reached The Last Image!!");

            }

            else {
                rowNumber++;
                pictureBox1.Image = ReadImageFromDB();


            }

        }

        private void buttonPre_Click(object sender, EventArgs e)
        {
            if (rowNumber == 0)
            {

                MessageBox.Show("This Is The First Image");

            }

            else {

                rowNumber--;
                pictureBox1.Image = ReadImageFromDB();

            }


        }

     

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonstartLiveCam_Click(object sender, EventArgs e)
        {
            if (captureLive != null)
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

        private void processFrameAndUpdateGUI(object sender, EventArgs e)
        {


           testImage = captureLive.QueryFrame();


            imageBox.Image = testImage;


        }

        private void selectCamcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {



            //Set the camera number to the one selected via combo box
            int CamNumber = 0;
            CamNumber = int.Parse(selectCamcomboBox.Text);

            //Start the selected camera
            #region if capture is not created, create it now
            if (captureLive == null)
            {
                try
                {
                    captureLive = new Capture(CamNumber);
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

        private void imageBox_Click(object sender, EventArgs e)
        {

        }

        private void extracedFaceNextbutton_Click(object sender, EventArgs e)
        {


            if(faceNo< faceList.Length-1)

            {

                faceNo++;

                extractedFacepictureBox.Image = faceList[faceNo];


            }

            


        }

        private void extracedFacePrebutton_Click(object sender, EventArgs e)
        {


            if (faceNo > 0)




            {


                faceNo--;

                extractedFacepictureBox.Image = faceList[faceNo];

            }



        }
    }

    }

