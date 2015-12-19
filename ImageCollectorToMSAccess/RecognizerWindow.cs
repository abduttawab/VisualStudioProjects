﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  System.IO;


using  Emgu.CV;
using  Emgu.Util;
using  Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Face_Recognizer;


namespace ImageCollectorToMSAccess
{
    public partial class RecognizerWindow : Form
    {




        TrainingSetDBGateWay trainingSetDBGateWay1 = new TrainingSetDBGateWay();

        TrainingSetWindow trainingSetWindow1 = new TrainingSetWindow();





        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

        

        private void RecognizerWindow_Load(object sender, EventArgs e)
        {
            LoadEigenFacesFromDB();
        }

        private void imageLoaderbutton_Click(object sender, EventArgs e)
        {


            try
            {







               


                    ContTrain = ContTrain + 1;


                    trainingSetDBGateWay1.ConnectToDatabase();



                foreach (DataRow row in trainingSetDBGateWay1.LocalDataTable.Rows)
                {


                    Bitmap bitmappedImageFromDB = (Bitmap)trainingSetDBGateWay1.ReadAllImageFromDB(row);

                    Image<Gray, Byte> grayImageFromDB = new Image<Gray, Byte>(bitmappedImageFromDB);

                    TrainedFace = grayImageFromDB;


                    trainingImages.Add(TrainedFace);


                    string getName = row["PersonName"].ToString();


                    labels.Add(getName);

                    //Show face added in gray scale
                    imageBox1.Image = TrainedFace;

                    //Write the number of triained faces in a file text for further load
                    File.WriteAllText(Application.StartupPath + "/TrainedFacesFromDB/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                    //Write the labels of triained faces in a file text for further load
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFacesFromDB/face" + i + ".bmp");
                        File.AppendAllText(Application.StartupPath + "/TrainedFacesFromDB/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    }

                    MessageBox.Show(getName + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           


        }


            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




        }

        public RecognizerWindow()
        {
            InitializeComponent();


            
        }

        public void LoadEigenFacesFromDB()
        {
            //Load haarcascades for face detection


            face = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

          



            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {

                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFacesFromDB/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFacesFromDB/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show(
                    "Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).",
                    "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void starRegButton_Click(object sender, EventArgs e)
        {

            

            grabber = new Capture();

            grabber.QueryFrame();



            Application.Idle += new EventHandler(FrameGrabber);


            starRegButton.Enabled = false;



        }

        private void FrameGrabber(object sender, EventArgs e)
        {





            detectedFaceNo.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
               face,
               1.2,
               10,
               Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
               new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 3000, ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                detectedFaceNo.Text = facesDetected[0].Length.ToString();

                /*
                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                }
                 */

            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            personName.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();


        }
    }
}
