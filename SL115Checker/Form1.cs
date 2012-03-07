using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using SL115Lib;
 
namespace SL115Checker
{
    public partial class Form1 : Form
    {
        // the list is to populate the combobox. I don't know how to do it with List<inspectors> and referencing the names
        private List<Inspector> inspectors = new List<Inspector>();
        private List<Filer> filers = new List<Filer>();
        BSRGlobal myBSRGlobal = new BSRGlobal();
        
        // I don't want to create a class variable. I cannot pass it in the procedure because the time the xml file is read and the time it is
        // written can differ a lot.
        // doc is discarded when the ReadInspectors procedure ends, so there is only one object in memory
        // should I just use myXML throughout and forego doc?
        private XDocument myXML; // hold the xml file after it was loaded to be used when writing BRS Period after BSR was copied
        
        Filer Asset = new Filer();
        Filer Book = new Filer();
        Filer Fin = new Filer();
        Filer Bsr = new Filer();
        Filer Omega = new Filer();

        BranchCode Branch = new BranchCode(); // branch number to be entered by user
       
        string xmlFile = @"sl115.xml";  //current app dir, in this case bin/debug
       
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // populate branch types combobox
            List<string> branchTypes = new List<string>();
            branchTypes.Add("Funeral");
            branchTypes.Add("Life");
            branchTypes.Add("Omega");
            comboBranch.DataSource = branchTypes;

            // set path properties, then add each path object to a list 
            InitializePaths();
            filers.Add(Asset);
            filers.Add(Book);
            filers.Add(Fin);
            filers.Add(Bsr);
            filers.Add(Omega);

            labelCurrentBSR.Text = myBSRGlobal.BSRPeriodAvailable.ToString();
            // determine if checkbox should be checked, is the inspector bsr the available bsr?
            if (myBSRGlobal.BSRPeriodAvailable.Year > inspectors[comboInspector.SelectedIndex].BSRperiod.Year) { checkBoxBSR.Checked = true; }
            else if (myBSRGlobal.BSRPeriodAvailable.Month > inspectors[comboInspector.SelectedIndex].BSRperiod.Month) { checkBoxBSR.Checked = true; }
            else { checkBoxBSR.Checked = false; }

            myXML = ReadInspectors();
            
            // load config file, read working dir, navigate if not saved
            if (myBSRGlobal.WorkingDir == null)
            {
                if (myXML.Element("sl115").Element("workingdir").Element("workingdirstring").Value != "")
                { myBSRGlobal.WorkingDir = myXML.Element("sl115").Element("workingdir").Element("workingdirstring").Value; }
                else { NavigateTargetPath(); } // this references myXML before ReadInspectors thus before myXML is created 
            }

            myBSRGlobal.TargetPath = myBSRGlobal.WorkingDir + @"sl115\";
        
            // populate today's date that will be used to calculate days difference
            labelToday.Text = DateTime.Today.ToShortDateString();
            checkBoxBSR.Checked = false;
            InitialState();
            
            ClearTargetDir();
            textBoxStatus.Text += "Target Path = " + myBSRGlobal.TargetPath + (char)13 + (char)10;
            textBoxStatus.Text += "Working Dir = " + myBSRGlobal.WorkingDir + (char)13 + (char)10;
        }

        private void comboInspector_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelBSRPrevious.Text = inspectors[comboInspector.SelectedIndex].BSRperiod.ToString();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // be ready for a search
        public void InitialState()
        {
            ClearControls();
            tbBranch.Clear();
            tbBranch.Focus();
            btnCopy.Enabled = false;
            btnSearch.Enabled = false;
            btnCheck.Enabled = true;
            checkBoxBSR.Enabled = true;
        }

        // read the config file, create a new one if there is none
        public XDocument ReadInspectors()
        {
            XDocument doc = new XDocument();
            try { doc = XDocument.Load(xmlFile); }
            catch (FileNotFoundException) 
            {
                if (MessageBox.Show("Configuration file not found, do you want to create a new configuration XML file?", "Create new file", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // build sample XML config file in memory, the file need not be loaded as the object is now in memory as if it was loaded from the config file
                    doc = new XDocument(
                        new XDeclaration("1.0", null, "yes"),
                        new XElement("sl115",
                            new XElement("controlinspector",
                                new XElement("name", "Ronnie"),
                                new XElement("period", "201101")
                            ),
                            new XElement("controlinspector",
                                new XElement("name", "Titus"),
                                new XElement("period", "201102")
                            ),
                            new XElement("controlinspector",
                                new XElement("name", "Renier"),
                                new XElement("period", "201103")
                            ),
                            new XElement("controlinspector",
                                new XElement("name", "Thys"),
                                new XElement("period", "201104")
                            ),
                            new XElement("controlinspector",
                                new XElement("name", "John"),
                                new XElement("period", "201105")
                            ),
                            new XElement("workingdir",
                                new XElement("workingdirstring", "")
                            ))
                    );

                    // save the file
                    try { doc.Save(xmlFile); }
                    catch (Exception exSave) { textBoxStatus.Text = "Error saving file. " + exSave.Message; }
                }
                else 
                { 
                    MessageBox.Show("The application cannot continue without a valid configuration file and will now exit. Create a new configuration file or replace the missing configuration file.", 
                        "Configuration file not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex) { textBoxStatus.Text = "Error. " + ex.Message; }

            // loop through all the nodes and create a list of inspector objects
            
            foreach (XElement element in doc.Element("sl115").Elements("controlinspector"))
            {
                // read period as string from xml, create Period object with the string constructor
                // assign the Period object to the inspector's period field which is of type Period
                // couldn't do it all in one statement as the following statement could not covert XElement to Period:
                // newInspector.BSRPeriod = (Period)element.Element("period"); 

                string stringPeriod = "";
                Inspector newInspector = new Inspector();
                newInspector.Name = (string)element.Element("name");
                stringPeriod = (string)element.Element("period");
                Period periodPeriod = new Period(stringPeriod);
                newInspector.BSRperiod = periodPeriod;
                
                inspectors.Add(newInspector);
            }

            textBoxStatus.Clear();
            for (int i = 0; i < inspectors.Count; i++) { comboInspector.Items.Add(inspectors[i].Name); }
            comboInspector.SelectedIndex = 0;  // I get a -1 SelectedIndex if I don't do this?
            return doc;
        
        } //ReadInspectors

        // reset control values 
        public void ClearControls()
        {
            lblAssetDate.Text = "";
            lblAssetDif.Text = "";
            lblAssetExist.Text = "";
            lblAssetCopied.Text = "";
            lblBookDate.Text = "";
            lblBookDif.Text = "";
            lblBookExist.Text = "";
            lblBookCopied.Text = "";
            lblFinDate.Text = "";
            lblFinDif.Text = "";
            lblFinExist.Text = "";
            lblFinCopied.Text = "";
            lblBSRExist.Text = "";
            lblBSRCopied.Text = "";
            lblOmegaDate.Text = "";
            lblOmegaDif.Text = "";
            lblOmegaExist.Text = "";
            lblOmegaCopied.Text = "";
            textBoxStatus.Clear();
        } // ClearControls

        // clear paths for next search
        public void ClearPaths()
        {
            // loop through the list and reset all paths regardless of how many there are
            for (int i = 0; i < filers.Count; i++) { filers[i].FullPath = ""; }
        }
        
        // add the branch number and extension to path stubs
        public void CreatePaths()
        {
            Asset.FullPath = myBSRGlobal.WorkingDir + Asset.Stub + Branch.Number + ".csv";
            Book.FullPath = myBSRGlobal.WorkingDir + Book.Stub + Branch.Number + ".csv";
            Fin.FullPath = myBSRGlobal.WorkingDir + Fin.Stub + Branch.Number + ".csv";
            Bsr.FullPath = myBSRGlobal.WorkingDir + Bsr.Stub + myBSRGlobal.BSRPeriodAvailable.ToString() + ".csv";
            Omega.FullPath = myBSRGlobal.WorkingDir + Omega.Stub + Branch.Number + ".csv";
                        
            //textBoxStatus.Clear();
            //for (int i = 0; i < filers.Count; i++) { textBoxStatus.Text += filers[i].FullPath + "\r\n"; }
        }

        // test if files exist, populate labels
        public void CheckFiles()
        {
            if (comboBranch.Text == "Funeral")
            {
                if (File.Exists(Asset.FullPath)) 
                { 
                    lblAssetExist.Text = "Yes";
                    lblAssetDate.Text = File.GetLastWriteTime(Asset.FullPath).ToShortDateString();
                }
                else { lblAssetExist.Text = "No"; }
                if (File.Exists(Fin.FullPath)) 
                { 
                    lblFinExist.Text = "Yes";
                    lblFinDate.Text = File.GetLastWriteTime(Fin.FullPath).ToShortDateString();
                }
                else { lblFinExist.Text = "No"; }
            }
            if (comboBranch.Text == "Life")
            {
                if (File.Exists(Asset.FullPath)) 
                { 
                    lblAssetExist.Text = "Yes";
                    lblAssetDate.Text = File.GetLastWriteTime(Asset.FullPath).ToShortDateString();
                }
                else { lblAssetExist.Text = "No"; }
                if (File.Exists(Book.FullPath)) 
                { 
                    lblBookExist.Text = "Yes";
                    lblBookDate.Text = File.GetLastWriteTime(Book.FullPath).ToShortDateString();
                }
                else { lblBookExist.Text = "No"; }
            }
            if (comboBranch.Text == "Omega")
            {
                if (File.Exists(Omega.FullPath)) 
                { 
                    lblOmegaExist.Text = "Yes";
                    lblOmegaDate.Text = File.GetLastWriteTime(Omega.FullPath).ToShortDateString();
                }
                else { lblOmegaExist.Text = "No"; }
            }
               
            // BSR will always be available for copying
            if (File.Exists(Bsr.FullPath)) { lblBSRExist.Text = "Yes"; }
            else { lblBSRExist.Text = "No"; } 
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            textBoxStatus.Clear();

            if (Branch.IsValid(tbBranch.Text))
            {
                Branch.Number = tbBranch.Text;
                CreatePaths();
                CheckFiles();
                CalculateDaysDifference();
                
                CopyState();
            }
            else 
            { 
                textBoxStatus.Text = "Branch number is invalid, must be between 1 and 9999";
                tbBranch.Clear();
                tbBranch.Focus();
            }
        }
        
        private void InitializePaths()
        {
            Asset.Stub = @"bates\bate";
            Book.Stub = @"boekevoorraad\boek";
            Fin.Stub = @"workfiles\FOP320-";
            Bsr.Stub = @"workfiles\bsr210";
            Omega.Stub = @"voorraad\ovba_";
            for (int i = 0; i < filers.Count; i++) 
            { 
                filers[i].FullPath = "";
            }
        }

        private void ClearTargetDir()
        {
            // clear the target directory
            try
            {
                string[] targetFiles = Directory.GetFiles(myBSRGlobal.TargetPath, "*.*");
                foreach (string targetFile in targetFiles)
                {
                    //      textBoxStatus.Text += "File: " + targetFile + (char)13 + (char)10;
                    File.Delete(targetFile);
                }
            }
            catch (Exception ex)
            {
                textBoxStatus.Text += "Error deleting files in target directory " + myBSRGlobal.TargetPath + " : " + ex.Message + (char)13 + (char)10;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            
              
            
            try
            {
                // copy files based on branch type
                if (comboBranch.Text == "Funeral")
                {
                    File.Copy(Asset.FullPath, myBSRGlobal.TargetPath + Path.GetFileName(Asset.FullPath), true);
                    lblAssetCopied.Text = "Yes";
                    File.Copy(Fin.FullPath, myBSRGlobal.TargetPath + Path.GetFileName(Fin.FullPath), true);
                    lblFinCopied.Text = "Yes";
                    textBoxStatus.Text += "Assets were copied to " + myBSRGlobal.TargetPath + Path.GetFileName(Asset.FullPath) + (char)13 + (char)10;
                    textBoxStatus.Text += "Financials were copied to " + myBSRGlobal.TargetPath + Path.GetFileName(Fin.FullPath) + (char)13 + (char)10;
                }
                if (comboBranch.Text == "Life")
                {
                    File.Copy(Asset.FullPath, myBSRGlobal.TargetPath + Path.GetFileName(Asset.FullPath), true);
                    lblAssetCopied.Text = "Yes";
                    File.Copy(Book.FullPath, myBSRGlobal.TargetPath + Path.GetFileName(Book.FullPath), true);
                    lblBookCopied.Text = "Yes";
                    textBoxStatus.Text += "Assets were copied to " + myBSRGlobal.TargetPath + Path.GetFileName(Asset.FullPath) + (char)13 + (char)10;
                    textBoxStatus.Text += "Books were copied to " + myBSRGlobal.TargetPath + Path.GetFileName(Book.FullPath) + (char)13 + (char)10;
                }
                if (comboBranch.Text == "Omega")
                {
                    File.Copy(Omega.FullPath, myBSRGlobal.TargetPath + Path.GetFileName(Omega.FullPath), true);
                    lblOmegaCopied.Text = "Yes";
                    textBoxStatus.Text += "Omega assets were copied to " + myBSRGlobal.TargetPath + Path.GetFileName(Omega.FullPath) + (char)13 + (char)10;
                }
                if (checkBoxBSR.Checked)
                {
                    File.Copy(Bsr.FullPath, myBSRGlobal.TargetPath + Path.GetFileName(Bsr.FullPath), true);
                    lblBSRCopied.Text = "Yes";
                    //textBoxStatus.Text += "Inspector: " + comboInspector.SelectedItem + " BSR Period: " + BSRPeriod + (char)13 + (char)10;
                    textBoxStatus.Text += "BSR was copied to " + myBSRGlobal.TargetPath + Path.GetFileName(Bsr.FullPath) + (char)13 + (char)10;

                    foreach (XElement element in myXML.Element("sl115").Elements("controlinspector"))
                    {
                        // find the correct inspector
                        if (element.Element("name").Value.ToString() == comboInspector.SelectedValue.ToString())
                        {
                            element.Element("period").Value = myBSRGlobal.BSRPeriodAvailable.ToString();
                            //textBoxStatus.Text += "Element value: " + element.Element("name").Value.ToString() + " will have a new Period of "
                            //    + element.Element("period").Value.ToString();
                            try { myXML.Save(xmlFile); }
                            catch (Exception ex) { textBoxStatus.Text += "Error writing XML file: " + ex.Message + (char)13 + (char)10; }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                textBoxStatus.Text += "Error copying file: " + ex.Message + (char)13 + (char)10;
            }
            finally
            {
                NewSearchState(); // reset control so a new search can be done
            }

           
        }

        // calc today - file date in days
        private void CalculateDaysDifference()
        {
            System.TimeSpan Dif;
            
            if (comboBranch.Text == "Funeral")
            {
                if (lblAssetExist.Text == "Yes")
                {
                    Dif = DateTime.Today - File.GetLastWriteTime(Asset.FullPath);
                    lblAssetDif.Text = Dif.Days.ToString();
                }
                if (lblFinExist.Text == "Yes")
                {
                    Dif = DateTime.Today - File.GetLastWriteTime(Fin.FullPath);
                    lblFinDif.Text = Dif.Days.ToString();
                }
            }
            if (comboBranch.Text == "Life")
            {
                if (lblAssetExist.Text == "Yes")
                {
                    Dif = DateTime.Today - File.GetLastWriteTime(Asset.FullPath);
                    lblAssetDif.Text = Dif.Days.ToString();
                }
                if (lblBookExist.Text == "Yes")
                {
                    Dif = DateTime.Today - File.GetLastWriteTime(Book.FullPath);
                    lblBookDif.Text = Dif.Days.ToString();
                }
            }
            if (comboBranch.Text == "Omega")
            {
                if (lblOmegaExist.Text == "Yes")
                {
                    Dif = DateTime.Today - File.GetLastWriteTime(Omega.FullPath);
                    lblOmegaDif.Text = Dif.Days.ToString();
                }
            }
        }

        private void CopyState()
        {
            comboBranch.Enabled = false;
            comboInspector.Enabled = false;
            tbBranch.Enabled = false;
            btnCopy.Enabled = true;
            btnCheck.Enabled = false;
            btnSearch.Enabled = true;
            btnCopy.Focus();
        }

        private void NewSearchState()
        {
            btnCopy.Enabled = false;
            btnSearch.Enabled = true;
            btnSearch.Focus();
        }

        // enable/disable controls based on branch type
        private void comboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBranch.Text == "Funeral")  // no books, no omega
            {
                labelAsset.Enabled = true;
                lblAssetDate.Enabled = true;
                lblAssetDif.Enabled = true;
                lblAssetExist.Enabled = true;
                lblAssetCopied.Enabled = true;
                
                labelBook.Enabled = false;
                lblBookDate.Enabled = false;
                lblBookDif.Enabled = false;
                lblBookExist.Enabled = false;
                lblBookCopied.Enabled = false;
                
                labelFin.Enabled = true;
                lblFinDate.Enabled = true;
                lblFinDif.Enabled = true;
                lblFinExist.Enabled = true;
                lblFinCopied.Enabled = true;
                
                labelBSR.Enabled = true;
                lblBSRExist.Enabled = true;
                lblBSRCopied.Enabled = true;
                
                labelOmega.Enabled = false;
                lblOmegaDate.Enabled = false;
                lblOmegaDif.Enabled = false;
                lblOmegaExist.Enabled = false;
                lblOmegaCopied.Enabled = false;
            }
            else if (comboBranch.Text == "Life")  // no omega, no financials
            {
                labelAsset.Enabled = true;
                lblAssetDate.Enabled = true;
                lblAssetDif.Enabled = true;
                lblAssetExist.Enabled = true;
                lblAssetCopied.Enabled = true;

                labelBook.Enabled = true;
                lblBookDate.Enabled = true;
                lblBookDif.Enabled = true;
                lblBookExist.Enabled = true;
                lblBookCopied.Enabled = true;

                labelFin.Enabled = false;
                lblFinDate.Enabled = false;
                lblFinDif.Enabled = false;
                lblFinExist.Enabled = false;
                lblFinCopied.Enabled = false;

                labelBSR.Enabled = true;
                lblBSRExist.Enabled = true;
                lblBSRCopied.Enabled = true;

                labelOmega.Enabled = false;
                lblOmegaDate.Enabled = false;
                lblOmegaDif.Enabled = false;
                lblOmegaExist.Enabled = false;
                lblOmegaCopied.Enabled = false;

            }
            else if (comboBranch.Text == "Omega") // only omega
            {
                labelAsset.Enabled = false;
                lblAssetDate.Enabled = false;
                lblAssetDif.Enabled = false;
                lblAssetExist.Enabled = false;
                lblAssetCopied.Enabled = false;

                labelBook.Enabled = false;
                lblBookDate.Enabled = false;
                lblBookDif.Enabled = false;
                lblBookExist.Enabled = false;
                lblBookCopied.Enabled = false;

                labelFin.Enabled = false;
                lblFinDate.Enabled = false;
                lblFinDif.Enabled = false;
                lblFinExist.Enabled = false;
                lblFinCopied.Enabled = false;

                labelBSR.Enabled = true;
                lblBSRExist.Enabled = true;
                lblBSRCopied.Enabled = true;

                labelOmega.Enabled = true;
                lblOmegaDate.Enabled = true;
                lblOmegaDif.Enabled = true;
                lblOmegaExist.Enabled = true;
                lblOmegaCopied.Enabled = true;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearControls();
            tbBranch.Enabled = true;
            comboBranch.Enabled = true;
            comboInspector.Enabled = true;
            btnSearch.Enabled = false;
            checkBoxBSR.Checked = true;
            comboBranch.SelectedIndex = 0;
            btnCheck.Enabled = true;
            btnCheck.Focus();
            tbBranch.Clear();
            tbBranch.Focus();
        }

        private void btnNavigateTarget_Click(object sender, EventArgs e)
        {
            NavigateTargetPath();
        }

        private void NavigateTargetPath()
        {
            // navigate to the target path and set the static member
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                myBSRGlobal.WorkingDir = folderBrowserDialog1.SelectedPath + @"\";
                textBoxStatus.Text += "The working dir selected is: " + myBSRGlobal.WorkingDir + (char)13 + (char)10;

                // This does not execute correctly, cause combo to be not populated
                SaveWorkingDir();
            }
            else
            {
                textBoxStatus.Text += "Please select a valid target path" + (char)13 + (char)10;
            }
        }

        // find the path element, replace it, save file
        public void SaveWorkingDir()
        {
            try { myXML.Element("sl115").Element("workingdir").Element("workingdirstring").Value = myBSRGlobal.WorkingDir; }
            catch (NullReferenceException ex) { textBoxStatus.Text += "Null reference to myXML caught: " + ex.Message; }  // do nothing, do it next time around after object is created and button is clicked
            
            try { myXML.Save(xmlFile); } 
            catch (Exception exSave) { textBoxStatus.Text += "Error saving file. " + exSave.Message; }
            
        } //SaveWorkingDir

    } //class

}
