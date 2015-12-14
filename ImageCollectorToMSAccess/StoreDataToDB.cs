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
        private ImageDB imageDb;

        public StoreDataToDB(ImageDB imageDb)
        {
            this.imageDb = imageDb;
        }

        public void StoreData(Image inputFace, string PersonName)
        {

            if (imageDb.TrainingSetDbGateWay.DbConnection.State.Equals(ConnectionState.Closed))

            {
                imageDb.TrainingSetDbGateWay.DbConnection.Open();
                try
                {


                    byte[] FaceAsByte = ConverImageToByte(inputFace);


                    imageDb.TrainingSetDbGateWay.RowPosition = imageDb.TrainingSetDbGateWay.LocalDataTable.Rows.Count;
                    imageDb.TrainingSetDbGateWay.RowPosition++;


                    MessageBox.Show("Saving Image at Index:" + imageDb.TrainingSetDbGateWay.RowPosition.ToString());

                    SqlCommand InsertCommand = new SqlCommand("INSERT INTO pictureData (ImageID, Image, PersonName) VALUES('" + imageDb.TrainingSetDbGateWay.RowPosition.ToString() + "',@MyImage,'" + PersonName + "' )", imageDb.TrainingSetDbGateWay.DbConnection);


                    // InsertCommand.Parameters.AddWithValue("@MyImage", inputFace);

                    SqlParameter imageParameter = InsertCommand.Parameters.AddWithValue("@MyImage", inputFace);
                    imageParameter.Value = FaceAsByte;
                    imageParameter.Size = FaceAsByte.Length;

                    int rowAffected = InsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Image Data Successfully Uploaded in " + rowAffected.ToString() + "row");

                    imageDb.TrainingSetDbGateWay.RowPosition++;


                }   

                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message.ToString());
                    MessageBox.Show(ex.StackTrace.ToString());
                }


                finally
                {
                    imageDb.TrainingSetDbGateWay.refreshDBconnection();

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