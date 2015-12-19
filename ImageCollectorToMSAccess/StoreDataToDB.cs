using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Face_Recognizer
{
    public class StoreDataToDB
    {
        private TrainingSetWindow trainingSetWindow;

        public StoreDataToDB(TrainingSetWindow trainingSetWindow)
        {
            this.trainingSetWindow = trainingSetWindow;
        }

        public void StoreData(Image inputFace, string PersonName)
        {

            if (trainingSetWindow.TrainingSetDbGateWay.DbConnection.State.Equals(ConnectionState.Closed))

            {
                trainingSetWindow.TrainingSetDbGateWay.DbConnection.Open();
                try
                {


                    byte[] FaceAsByte = ConverImageToByte(inputFace);


                    trainingSetWindow.TrainingSetDbGateWay.RowPosition = trainingSetWindow.TrainingSetDbGateWay.LocalDataTable.Rows.Count;
                    trainingSetWindow.TrainingSetDbGateWay.RowPosition++;


                    MessageBox.Show("Saving Image at Index:" + trainingSetWindow.TrainingSetDbGateWay.RowPosition.ToString());

                    SqlCommand InsertCommand = new SqlCommand("INSERT INTO pictureData (ImageID, Image, PersonName) VALUES('" + trainingSetWindow.TrainingSetDbGateWay.RowPosition.ToString() + "',@MyImage,'" + PersonName + "' )", trainingSetWindow.TrainingSetDbGateWay.DbConnection);


                    // InsertCommand.Parameters.AddWithValue("@MyImage", inputFace);

                    SqlParameter imageParameter = InsertCommand.Parameters.AddWithValue("@MyImage", inputFace);
                    imageParameter.Value = FaceAsByte;
                    imageParameter.Size = FaceAsByte.Length;

                    int rowAffected = InsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Image Data Successfully Uploaded in " + rowAffected.ToString() + "row");

                    trainingSetWindow.TrainingSetDbGateWay.RowPosition++;


                }   

                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message.ToString());
                    MessageBox.Show(ex.StackTrace.ToString());
                }


                finally
                {
                    trainingSetWindow.TrainingSetDbGateWay.refreshDBconnection();

                }



            }




        }

        private byte[] ConverImageToByte(Image inputImage)
        {






            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                inputImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;





          

        }
    }
}