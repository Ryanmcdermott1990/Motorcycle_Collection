using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MotorcycleCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // A static integer has been declared, (max) and assigned a value of 20, (static means that it can be referenced outside of the class without first instantiating the variable in another class).
        // Two string arrays have been created, make[] and model[], these arrays can hold a maximum value of the value assigned to the max static varaible, (assigned as 20), in laymans terms all arrays 
        // can hold a maximum of 20 values.
        // Another array cost[] has been declared as an integer, (this is due to the fact that the user should be using whole numbers and not decimals for such high value items) this has been assigned a maximum number of 
        // indexes equivelent to the value assigned to max.
        // emptyPtr has been declared as an integer and assigned an initial value of 0. This variable is used as a list that runs in paralell to each array in order to effectively transfer unwanted data from the array 
        // which can be sent to the trash disposal. emptyPtr also does several other important things that will be elaborated on when emptyPtr is used within the program.
        // fileName has been declared as a static string, this sets the path for the file that will be created when a user clicks on the Save_Button. As there is no path specified, this file will automatically be dropped
        // within the bin folder of the project contained within the repos. The file is a .dat filetype meaning binary. 

        static int max = 20;
        string[] make = new string[max];
        string[] model = new string[max];
        int[] cost = new int[max];
        int emptyPtr = 0;
        static string fileName = "myBikes.dat";


        // A private void, (meaning cannot be accessed outside the class and returns no value) method has been created, Sum(), which declares an integer total and assigns it to sum of the elements within the array cost.
        // The method then clears the text in textbox4 and assigns the value of the text within textbox4 as the value of total,(the sum of all the elements within the cost array) parsed in to a string value.

        private void Sum()
        {
            int total = cost.Sum();
            textBox4.Clear();
            textBox4.Text = "$" + total.ToString();
        }
        // A private void, (meaning cannot be accessed outside the class and returns no value) method has been created, Sort(),  this uses the bubblesort algorithm to sort the string values alphebetically. 
        
        private void Sort()
        {
            // A try catch has been added to catch a NullReferenceException, thrown when trying to access a memor type whose value is null.
            try
            {
                // An initial for statement has been added which declares the variable inner as an integer and assigns an initial value of 0. The for loop will iterate as long as inner is less than emptyPtr, and with each iteration the 
                // value of inner will increase by one.
                // Another for loop declares the value of outer as an integer with an initial value of inner + 1, and will iterate as long as outer is less than emptyPtr, after each iteration the value of outer will increase by 1. 
                // These two loops are used in order to take a less than and greater than value that is used to order the elements within the array, (this process will be elaborated on in the Swap function below. 
                for (int inner = 0; inner < emptyPtr; inner++)
                {
                    for (int outer = inner + 1; outer < emptyPtr; outer++)
                    {
                        // string.CompareOrdinal is a way to sort string values alphebetically with the parameters set as model[] at the array index value of inner and model[] at the array index value of outer. In laymans terms this will 
                        // compare the order of the string values at the index values inner and outer and if inner is greater than outer, (string.CompareOrdinal > 0), then the values will be swapped.
                        // Swap is a method which accepts two integer parameters for both inner and outer. It is called by setting the parameters inner and outer witihin the parenthesis of the method. 
                        // Once this logic has been executed DisplayArray() is called so that all current array values are correctly displayed, summed and sorted, (please refer to DisplayArray() method below.
                        if (string.CompareOrdinal(model[inner], model[outer]) > 0)
                        {
                            Swap(inner, outer);
                            DisplayArray();

                        }
                    }
                }
            }
            //A try catch has been added to catch a NullReferenceException, thrown when trying to access a memory type whose value is null.
            catch (NullReferenceException)
            {

            }
        }
        // A private void, (meaning cannot be accessed outside the class and returns no value) method has been created,
        // Swap() is a method that accepts two parameters which are both integer values. The arguments that are passed in this method are inner and outer, (reflecting the variables within the for loop within the Sort() method. 

        private void Swap(int inner, int outer)
        {
            // tempModel is declared as a string and a value is assigned as model[] at the index value of inner. Model[] at the index value inner is then assigned a value as model[] at the index value outer, which is then assigned a value of 
            // tempModel. This in effect will push the values up or down depending on whether the compared value is greater than or less than the previous index value. The rest of the arrays, make[], cost[] do exactly the same thing as
            // the model[] array. The other arrays have been added so that there is consistency for all of the 3 arrays.
            //. 
            string tempModel = model[inner];
            model[inner] = model[outer];
            model[outer] = tempModel;
            string tempMake = make[inner];
            make[inner] = make[outer];
            make[outer] = tempMake;
            int tempint = cost[inner];
            cost[inner] = cost[outer];
            cost[outer] = tempint;
        }

        // A private void, (meaning cannot be accessed outside the class and returns no value) method has been created, DisplayArray()
        // All items within the listBox1 are cleared, (this is in order to flush any remaining values that were added and populate the listBox1 with the fresh values). 
        // A for loop declares the x as an integer and assigns an intial value of 0, this for loop will continue to iterate as long as x is less than emptyPtr and after each iteration x will increase by 1. 
        // After each iteration listBox1 will add the values for each of the 3 arrays, (model[], make[] and cost[]) at the index value of x, (which iterates from a starting point of 0 until emptyPtr, 
        // emptyPtr is a list which runs paralell to the 3 arrays, that will increase by 1 every time a record is added and decrease by 1 every time a record is deleted). 
        // Clear(), Sort() and Sum() methods are then called, (each are explained in greater detail by comments within the logic of each method).
        

        private void DisplayArray()
        {

            listBox1.Items.Clear();
            for (int x = 0; x < emptyPtr; x++)
            {
                listBox1.Items.Add(model[x] + " " + make[x] + " " + "$" + cost[x]);
            }
            Clear();
            Sort();
            Sum();

        }
        // This method will load the form.
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // The Add_Button is for each time a user clicks on the Add button on the user interface. 
        // A try catch has been added to catch any format exception errors that are thrown. 
        private void Add_Button(object sender, EventArgs e)
        {
            try
            {
                // If the text in textBox1, textBox2 or textBox3 is empty then executre the follwoing logic, otherwise display an error message informing the user to 
                // please enter values for model, make and cost. 

                if (!(string.IsNullOrEmpty(textBox3.Text)) && (!(string.IsNullOrEmpty(textBox2.Text)) && (!(string.IsNullOrEmpty(textBox1.Text)))))

                    // A for loop declares x as an integer and assigns x an intial value of 0, this loop will continue to iterate as long as x is less than max, (assigned as 20 in the global variables).  
                {
                    for (int x = 0; x < max; x++)
                    {
                        // If statements condition: the assigned index value of model[] and make[] are null and the index value of cost[] is 0, (ie don't overwrite any existing records, only add when the value of each array is 0).
                        // If the above condition is true, assign the value of the text of textBox1 to the index value of x, (ie add the text that is inputted in textBox1 and textBox2 and add this to the model[] and make [] arrays)
                        // Further the text value that is inputted in to textBox3 is parsed in to an integer and added to the cost[] array. 
                        // These items are then added to listBox1, in the order of model[], make[] and cost[]. (before cost a $ is added for design purposes). 
                        // Once the logic within the if statement has been executed, break out of the loop. 

                        if (cost[x] == 0 && model[x] == null && make[x] == null)
                        {

                            model[x] = textBox1.Text.ToString();
                            make[x] = textBox2.Text.ToString();
                            cost[x] = int.Parse(textBox3.Text);
                            listBox1.Items.Add(model[x] + " " + make[x] + " " + "$" + cost[x]);
                            emptyPtr++;


                            break;
                        }
                    }
                }
                // If no values are entered for any of the text boxes an error will be shown asking the user to please input values for each of the text boxes. 
                // DisplayArray() is called so that old values can be flushed out and fresh values will populate listBox1.
                else
                {
                    MessageBox.Show("Error, please enter values for model, make and cost");
                }
                DisplayArray();
                // If there are more values than the value assigned to the integer varaible max, (20), an error message is displayed informing the user that the array is full.  

                if (emptyPtr >= max)
                {
                    MessageBox.Show("Array is full");
                }
                // A try catch has been added to catch any format exception errors that are thrown, in case a string or other data type other than an integer is inputted in to the cost text box. 
                // If this error is thrown a message box is used to display an error message.
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter in a valid integer for cost");
                // A try catch has been added to catch any Overflow Exception errors that are thrown by inputting a very large number in the cost field. 
                // If this error is thrown a message box is used to display an error message.
            }
            catch (OverflowException)
            {
                MessageBox.Show("Please enter in a valid integer for cost");
            }
        }
        // Delete_Button is called when a click event occurs on the Delete button on the user interface.
        // This has been added in place of using the pop up dialogue box as I stongly think that having a delete button makes the UI much more user friendly and will avoid the confusion of people double clicking on values within listBox1
        // and expecting to open the record or to see more details about the record, (which is what occurs in most UI's when a record is double clicked).

        // If statement has the following condition: The value of the selected index within listBox1 isn't -1, (ie that the user has selected a record)
        // If this condition is true, declare a string data type called, curIndex, (current index) and assign this a value of the selected item within listBox1 and parse this value to a string. 
        // Declare an integer datatype called indx and assign the value as the item in listBox1 matching the value assigned to curIndex.
        // This is achievd using the FindString() method which accpets a string variable as a parameter.
        // Then take the index value of indx within the model[], make[] and cost[] arrays, for the model[] and make[] arrays, the index value, (indx) is assigned as model[] and make[] at the index value of emptyPtr -1.
        // This index value is then assigned a value of null.
        // With the cost[] array it is the same except, the cost[] at index value emptyPtr-1 is assigned as 0 not null, (as cost[] is an integer array while model[] and make[] are both string arrays).
        // emptyPtr is then decreased by 1 and DisplayArray() is called refreshing the values, flushing any old values from listBox1, sorting the values and adding the values in the cost[] array and displaying this within textBox4.
        // In laymans terms emptyPtr is used here to assign the values of the array index for each array to the previous value then assigning this to zero and deleting 1 from emptyPtr, in effect removing the index value from each of the 3 arrays. 
      
        private void Delete_Button(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedIndex == -1))
            {
                string curIndex = listBox1.SelectedItem.ToString();
                int indx = listBox1.FindString(curIndex);
                model[indx] = model[emptyPtr - 1];
                model[emptyPtr - 1] = null;
                make[indx] = make[emptyPtr - 1];
                make[emptyPtr - 1] = null;
                cost[indx] = cost[emptyPtr - 1];
                cost[emptyPtr - 1] = 0;

                emptyPtr--;
                DisplayArray();

            }
            // If the above If statement condition is not met, (nothing is selected from listBox1, an error message will be displayed asking the user to select the record that they want to delete. 
            else
            {
                MessageBox.Show("Please select the record you want to delete from the list box");
            }
        }
        // Reset_Button is a method that will be called in the event that the user clicks on the Reset button on the user interface. 
        // Arrays model[], make[] and cost[] will assign all of the values within each array as 0. 
        // The Array.Clear() function accepts 3 parameters, 1. the array that you would like to clear, 2. the integer value you would like to set the values to and 3. the length of the array.
        // For each array, upon clicking the Reset button on the UI, the values for each current value within the array will be set to 0 up to the length of the array assigned as emptyPtr, (emptyPtr holds the amount of records that have been created less those that have been deleted)
        // The items within listBox1 are cleared and the value of the text within textBox1, textBox2, textBox3 and textBox4 are assigned as, " ", (ie blank). 
        private void Reset_Button(object sender, EventArgs e)
        {

            Array.Clear(model, 0, emptyPtr);
            Array.Clear(make, 0, emptyPtr);
            Array.Clear(cost, 0, emptyPtr);
            listBox1.Items.Clear();

            textBox1.Text = (" ");
            textBox2.Text = (" ");
            textBox3.Text = (" ");
            textBox4.Text = (" ");

        }
        // Binary_Button is a method that will be called in the event that the user clicks on the Binary Search button on the user interface. 
 
        private void Binary_Button(object sender, EventArgs e)
        {
            // A try catch has been added to catch any NullReferenceExcepttion errors that are thrown. 
            // midPoint has been declared as an integer with no inital value assigned. 
            // lowBound has been declared as an integer and assigned an intital value of 0.
            // highBound has been declared as an integer and assigned a value of emptyPtr, (emptyPtr holds the amount of records that have been created less those that have been deleted)
            // targetFound has been declared as a boolean value with an intital value assigned as false. 
            try
            {
                int midPoint;
                int lowBound = 0;
                int highBound = emptyPtr;
                bool targetFound = false;

                // A while loop will continue to iterate forever as long as lowBound is less than or equal to highBound.

                while (lowBound <= highBound)
                {
                    // midPoint is assigned a value of lowBound + highBound divided by 2
                    // binary is declared as an integer and assigned a value of model[] at the index value of midPoint compared with the text within textBox1.
                    // CompareTo is an in-built function that will return either -1, 0 or 1.  
                    midPoint = (lowBound + highBound) / 2;
                    int binary = model[midPoint].CompareTo(textBox1.Text);

                   // The confition of the If statement is: the value is returned as 0, then the text within textBox1 is equal to the index value of midPoint within the model[] array.
                   // If this condition is true, then set the value of text in textbox1 to that of the index value of midPoint within the model[], make[] arrays
                   // For the cost[] it is the same as ther other two arrays except that the value that is assigned to the text in textBox3 is parsed in to a string. 
                   // Once a record has been found, assign the value of targetFound to true and return to the start of the method.  
                    if (binary == 0)
                    {
                        textBox1.Text = model[midPoint];
                        textBox2.Text = make[midPoint];
                        textBox3.Text = cost[midPoint].ToString();
                        targetFound = true;
                        return;

                    }
                    // This If statement has the following condition: the value of binary is less than 0, (ie, the targeted index value is less than index value of midPoint),
                    // If this condition is true, assign the value of highBound to midPoint - 1, (this in effect will split the search range in half and make the process of finding the targeted model much faster). 
                    else if (binary > 0)
                    {
                        highBound = midPoint - 1;
                    }
                    // If either of the if or else if statements are not satisfied, (ie binary is greater than 0)
                    // The lowBound is assigned a value of the midPoint + 1, moving the lowBound above the midPoint and splitting the targeted search range. 

                    else
                    {
                        lowBound = midPoint + 1;
                    }

                }
                // If statement has the following condition: if targetFound is not true, (the target has not been found)
                // If this condition is true, display an error message informing the user that the record is not found. 
                if (!targetFound)
                {
                    MessageBox.Show("Error record not found");

                }
            }
            // A try catch has been added to catch any NullReferenceExcepttion errors that are thrown.
            // If this error is thrown a message box is used to display an error message.
            catch (NullReferenceException)
            {
                MessageBox.Show("Error please try again");
            }
        }

        // Linear_Button is a method that will be called in the event that the user clicks on the Linear Search button on the user interface. 
        private void Linear_Button(object sender, EventArgs e)
        {
            // modelTarget has been declared as a string and assigned a value of the text of textBox1.
            // found has been declared as a boolean value and an intial value is assigned as false. 
            // A for loop declares x as an integer data type and sets the intial value at 0, the loop will continue to iterate as long as x is less than the length of the model[] array, at each iteration the value of x will increase by 1.

            string modelTarget = textBox1.Text;
            bool found = false;
            
            for (int x = 0; x < model.Length; x++)
            {
                // The if statement has the following condition: model[x] is compared to the value of modelTarget.
                // If the values of model[] at index x and modelTarget match then a message box will display Found at index, x, (x being the index value at which the record was found)
                // found is assigned as true and assign the text in textBox1, textBox2 and  texBox3 as model[] at index value x, make at index value x, and cost at index value x parsed to a string respectively. 
                if (model[x] == modelTarget)
                {
                    MessageBox.Show("Found at index " + x);
                    found = true;
                    textBox1.Text = model[x];
                    textBox2.Text = make[x];
                    textBox3.Text = cost[x].ToString();



                }
            }
            // The if statement has the following condition: if found is assigned a false value, (ie the record cannot be found)
            // Display a message informing the user, "Target is not found".
            if (!found)
            {
                MessageBox.Show("Target not found");
            }
        }
        // Save_Button is a method that will be called in the event that the user clicks on the Save button on the user interface.
        private void Save_Button(object sender, EventArgs e)
        {
            // using a class BinaryWriter, a new instance, (bin) is created creating a new instance of the FileStream constructor using the following parameters, fileName, (path of the file that will be created) and the mode of the file. 
            // in this case FileMode.Create means that the file will be created and any existing values will be overwritten.
            using (BinaryWriter bin = new BinaryWriter(new FileStream(fileName, FileMode.Create)))
            {
                // A for loop declares the variable x as an integer and assigns an initial value of 0, this for loop will continue to iterate as long as x is less than emptyPtr and will increase by 1 each iteration. 

                for (int x = 0; x < emptyPtr; x++)
                {
                    // For each value within the model[], make[] and cost arrays the new instance of the BinaryWriter will write values to a binary value. 
                    // The items statusStrip1 will be cleared, (to flush out any existing messages displayed) and "File Created" will be displayed. 
                    bin.Write(model[x]);
                    bin.Write(make[x]);
                    bin.Write(cost[x]);
                }
                statusStrip1.Items.Clear();
                statusStrip1.Items.Add("File created");
            }
        }




        // Load_Button is a method that will be called in the event that the user clicks on the Load button on the user interface.
        private void Load_Button(object sender, EventArgs e)
        {
            // The items in listBox1 will be cleared in order to flush out any existing values that were stored there.
            // A try catch has been added to catch any EndOfSteamException errors that are thrown. 
            listBox1.Items.Clear();
            try
            {
                // This if statement has the following condition: If the file exists, (ie the file path assigned above for filename - "myBikes.dat" can be located using the path specified.
                // If this condition is satisfied, the statusStrip1 items are cleared, to flush any previously assigned values and a message, "File Loaded" is added and displayed for the user to see.
                if (File.Exists(fileName))
                {
                    statusStrip1.Items.Clear();
                    statusStrip1.Items.Add("File loaded");
                }
                // using the claass BinaryReader a new instance, (binRead) is created specifying in the parameters the location to open the file and mode,(open) to use the file. 
                using (BinaryReader binRead = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    // fileLength is declared as an integer and assigned a value of the new instance of the BinaryReader, (binRead) with the length of the stream read from the BinaryWriter divided by 3 due to their being 3 seperate arrays. 
                    int fileLength = (int)binRead.BaseStream.Length / 3;
                    // emptyPtr is set to 0 in order to flush any existing values that may be present and replace these with the fresh values read from the binary file. 
                    emptyPtr = 0;
                    // a for loop declares x as an integer type and assigns an initial value of 0. The loop will continue to iterate as long as x is less than the fileLength, after each iteration x will increase by 1/
                    for (int x = 0; x < fileLength; x++)
                    {
                        // For each of the values within the array the new instance of BinaryReader is used to call the method, ReadString(), and then these value are added to listBox1 and emptyPtr index is increase by 1 each time, 
                        // (using the same logic as when records are added or deleted manually)
                        // cost is read as ReadInt32 as the cost[] array is an integer type array/
                        model[x] = binRead.ReadString();
                        make[x] = binRead.ReadString();
                        cost[x] = binRead.ReadInt32();
                        listBox1.Items.Add(make[x] + " " + model[x] + " " + cost[x]);
                        emptyPtr++;
                        // Once all the logic has been executed, DisplayArray() is called to refresh, sort, sum and display current values within all 3 of the array's
                        DisplayArray();
                    }


                }
            }
            // A try catch has been added to catch any EndOfSteamException errors that are thrown. 
            catch (EndOfStreamException)
            {

            }
        }
        // SelectedIndex is a method that will be called in the event that the user clicks on one of the index within listBox1.
        private void SelectedIndex(object sender, EventArgs e)
        {
            // A try catch has been added to catch any IndexOutOfRangeException errors that are thrown.
            try
            {
                // the text in textBox1, textBox2, textBox3 is assigned the value of the value of each array at the selected index, (ie if the user clicks on index value 0 of the array, textBox1, textBox2 and textBox3 will be populated with the same
                // values as those that have been selected in listBox1.
                // As always for the cost[] array the value of this selected index must first be parsed in to a string value in order to be displayed. 
                textBox1.Text = model[listBox1.SelectedIndex];
                textBox2.Text = make[listBox1.SelectedIndex];
                textBox3.Text = cost[listBox1.SelectedIndex].ToString();

            }
            // A try catch has been added to catch any IndexOutOfRangeException errors that are thrown.
            // If this error is thrown a message box is used to display an error message.
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Please select an index");
            }



        }
        // Clear_Button is a method that will be called in the event that the user clicks on the Clear button on the user interface.
        // A custom Clear() method is called, clearing all 4 text boxes. 
        private void Clear_Button(object sender, EventArgs e)
        {

            Clear();

          //textBox1.Text = (" ");
          //  textBox2.Text = (" ");
           // textBox3.Text = (" ");
           // textBox4.Text = (" ");
        }

        // private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        // {

        //        }

        // A custom method has been created that will clear the values of textBox1, textBox2 and textBox3 using the inbuilt Clear() method.  
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        //      private void label1_Click(object sender, EventArgs e)
        //    {

        //        }
    }
}
