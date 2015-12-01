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


using Emgu.CV;                  //
using Emgu.CV.CvEnum;           // usual Emgu CV imports
using Emgu.CV.Structure;        //
using Emgu.CV.UI;

using System.Data.SqlClient;
using System.IO;


namespace Face_Recognizer
{
    public partial class ImageDB : Form

    {






        SqlConnection dbConnection = new SqlConnection();

        SqlDataAdapter dataAdater;

        DataTable localDataTable = new DataTable();

        int rowPosition= 0;
        int rowNumber=0;


        // for Live camera

        private Capture captureLive;
        private bool captureInPreogress;



        //private void ProcessFrame(object sender, EventArgs arg) {

        //    Image<Bgr, Byte> ImageFram = captureLive.QueryFrame();

        //    imageBox.Image = ImageFram;


        //}
  


        // for live camera



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
            if (openFileDialog.ShowDialog() == DialogResult.OK) {



                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);


               

                buttonSave.Enabled = true;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonstartLiveCam_Click(object sender, EventArgs e)
        {
            try
            {
                captureLive = new Capture(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to read from webcam, error: " + Environment.NewLine + Environment.NewLine +
                                ex.Message + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }
            Application.Idle += processFrameAndUpdateGUI;
        }

        private void processFrameAndUpdateGUI(object sender, EventArgs e)
        {


            Mat imgOriginal;

            imgOriginal = captureLive.QueryFrame();

            if (imgOriginal == null)
            {
                MessageBox.Show("unable to read frame from webcam" + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }

            

            imageBox.Image = imgOriginal;
            



        }
    }

    }

