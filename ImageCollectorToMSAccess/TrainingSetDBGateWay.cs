using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Face_Recognizer
{
    public class TrainingSetDBGateWay
    {
        private SqlConnection dbConnection = new SqlConnection();
        private SqlDataAdapter dataAdater;
        private DataTable localDataTable = new DataTable();
        private int rowPosition= 0;
        private int rowNumber=0;

        public TrainingSetDBGateWay()
        {
        }

        public SqlConnection DbConnection
        {
            set { dbConnection = value; }
            get { return dbConnection; }
        }

        public SqlDataAdapter DataAdater
        {
            set { dataAdater = value; }
            get { return dataAdater; }
        }

        public DataTable LocalDataTable
        {
            set { localDataTable = value; }
            get { return localDataTable; }
        }

        public int RowPosition
        {
            set { rowPosition = value; }
            get { return rowPosition; }
        }

        public int RowNumber
        {
            set { rowNumber = value; }
            get { return rowNumber; }
        }

        public void ConnectToDatabase() {




            dbConnection.ConnectionString = "Data Source = ASIF-PC; Initial Catalog = PictureBoxDB; User ID = sa; Password = ATBRasif12";

            dbConnection.Open();

            dataAdater = new SqlDataAdapter("Select * from pictureData", dbConnection);

            SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(dataAdater);

            dataAdater.UpdateCommand = sqlBuilder.GetUpdateCommand(true);


            dataAdater.Fill(localDataTable);

            dbConnection.Close();


            if (localDataTable.Rows.Count !=0) {

                rowPosition = localDataTable.Rows.Count;
            }



        }

        public void refreshDBconnection()
        {
            if (dbConnection.State.Equals(ConnectionState.Open)) {

                dbConnection.Close();
                localDataTable.Clear();
                ConnectToDatabase();

            }
        }

        public Image ReadImageFromDB()
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





        private void StoreData(Image inputFace, string PersonName)
        {

            if (DbConnection.State.Equals(ConnectionState.Closed))

            {
                DbConnection.Open();
                try
                {


                    byte[] FaceAsByte = ConverImageToByte(inputFace);


                    RowPosition = LocalDataTable.Rows.Count;
                    RowPosition++;


                    MessageBox.Show("Saving Image at Index:" + RowPosition.ToString());

                    SqlCommand InsertCommand = new SqlCommand("INSERT INTO pictureData (ImageID, Image, PersonName) VALUES('" + RowPosition.ToString() + "',@MyImage,'" + PersonName + "' )", DbConnection);


                    // InsertCommand.Parameters.AddWithValue("@MyImage", inputFace);

                    SqlParameter imageParameter = InsertCommand.Parameters.AddWithValue("@MyImage", inputFace);
                    imageParameter.Value = FaceAsByte;
                    imageParameter.Size = FaceAsByte.Length;

                    int rowAffected = InsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Image Data Successfully Uploaded in " + rowAffected.ToString() + "row");

                    RowPosition++;


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