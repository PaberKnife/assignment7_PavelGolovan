using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment7_PavelGolovan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            int row, col, correct, incorrect, index;

            correct = 0;
            incorrect = 0;
            index = 0;

            const int ROWS = 4;
            const int COLS = 5;

            string[,] correctAnswers = { {"1. B", "2. D", "3. A", "4. A", "5. C"},
                                         {"6. A", "7. B", "8. A", "9. C", "10. D"},
                                         {"11. B", "12. C", "13. D", "14. A", "15. D"},
                                         {"16. C", "17. C", "18. B", "19. D", "20. A"}
                                       };
            string[,] studentAnswers = new string[ROWS, COLS];

            StreamReader inputFile;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFileDialog1.FileName);
                    for (row = 0; row < ROWS; row++)
                    {
                        for (col = 0; col < COLS; col++)
                        {
                            studentAnswers[row, col] = inputFile.ReadLine();
                            if (studentAnswers[row, col] == correctAnswers[row, col])
                            {
                                correct++;
                            }
                            else
                            {
                                incorrect++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string[] incorrectAnswers = new string[incorrect];
            while (index < incorrect)
            {
                for (row = 0; row < ROWS; row++)
                {
                    for (col = 0; col < COLS; col++)
                    {
                        if (studentAnswers[row, col] != correctAnswers[row, col])
                        {
                            incorrectAnswers[index] = (row * COLS + (col + 1)).ToString();
                            index++;
                        }
                    }
                }
            }

            if (correct < 15)
            {
                MessageBox.Show("Student failed the exam." +
                    "\n\nTotal number of correctly answered questions - " + correct +
                    ";\nTotal number of incorrectly answered questions - " + incorrect +
                    ";\nFollowing questions were answered incorrectly: " + string.Join(", ", incorrectAnswers) + ".");
            }
            else if (incorrect == 0)
            {
                MessageBox.Show("Student passed the exam." +
                    "\n\nTotal number of correctly answered questions - " + correct +
                    ";\nTotal number of incorrectly answered questions - " + incorrect +
                    ";\nFollowing questions were answered incorrectly: none.");
            }
            else
            {
                MessageBox.Show("Student passed the exam." +
                    "\n\nTotal number of correctly answered questions - " + correct +
                    ";\nTotal number of incorrectly answered questions - " + incorrect +
                    ";\nFollowing questions were answered incorrectly: " + string.Join(", ", incorrectAnswers) + ".");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}