using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class MathQuiz : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;
        //fills all problems & starts timer
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == difference.Value)
            && (multiplicand * multiplier == product.Value) && (dividend / divisor == quotient.Value))
                return true;
            else
                MessageBox.Show("Wow! You can't even do simple math!");
                timer1.Stop();
                return false;

        }
        public MathQuiz()
        {
            InitializeComponent();
        }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void MathQuiz_Load(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void label7_Click(object sender, EventArgs e)
    {

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {

    }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("C'mon, my dead grandma could go faster!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void plusLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (CheckTheAnswer())
            {
                MessageBox.Show("Congratulations, You can do 4th grade math!");
            }
            startButton.Enabled = true;
        }
    }
}
