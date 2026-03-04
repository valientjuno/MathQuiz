using System;
using System.Windows.Forms;
using System.Media;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // Random number generator
        private Random randomizer = new Random();

        // Addition variables
        private int addend1;
        private int addend2;

        // Subtraction variables
        private int minuend;
        private int subtrahend;

        // Multiplication variables
        private int multiplicand;
        private int multiplier;

        // Division variables
        private int dividend;
        private int divisor;

        // Timer for quiz countdown
        private int timeLeft;

        // Track if each answer was already correct to play sound only once
        private bool sumCorrect;
        private bool differenceCorrect;
        private bool productCorrect;
        private bool quotientCorrect;

        public Form1()
        {
            InitializeComponent();

            // Event handlers
            startButton.Click += StartButton_Click;
            this.Load += Form1_Load;

            // Timer setup
            timer1.Interval = 1000; // 1 second
            timer1.Tick += Timer1_Tick;

            // NumericUpDown Enter events
            sum.Enter += Answer_Enter;
            difference.Enter += Answer_Enter;
            product.Enter += Answer_Enter;
            quotient.Enter += Answer_Enter;

            // NumericUpDown ValueChanged events for per-question correct sound feedback
            sum.ValueChanged += Answer_ValueChanged;
            difference.ValueChanged += Answer_ValueChanged;
            product.ValueChanged += Answer_ValueChanged;
            quotient.ValueChanged += Answer_ValueChanged;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Optional: initialization on form load
        }

        /// <summary>
        /// Selects all text when a NumericUpDown control is entered
        /// </summary>
        private void Answer_Enter(object? sender, EventArgs e)
        {
            if (sender is NumericUpDown answerBox)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        /// <summary>
        /// Plays a sound when a question is answered correctly (only once)
        /// </summary>
        private void Answer_ValueChanged(object? sender, EventArgs e)
        {
            if (sender is NumericUpDown box)
            {
                if (box == sum && !sumCorrect && sum.Value == addend1 + addend2)
                {
                    SystemSounds.Asterisk.Play();
                    sumCorrect = true;
                }
                else if (box == difference && !differenceCorrect && difference.Value == minuend - subtrahend)
                {
                    SystemSounds.Asterisk.Play();
                    differenceCorrect = true;
                }
                else if (box == product && !productCorrect && product.Value == multiplicand * multiplier)
                {
                    SystemSounds.Asterisk.Play();
                    productCorrect = true;
                }
                else if (box == quotient && !quotientCorrect && quotient.Value == dividend / divisor)
                {
                    SystemSounds.Asterisk.Play();
                    quotientCorrect = true;
                }
            }
        }

        /// <summary>
        /// Starts the quiz by generating all random math problems and starting the timer.
        /// </summary>
        public void StartTheQuiz()
        {
            // Reset per-question correct flags
            sumCorrect = differenceCorrect = productCorrect = quotientCorrect = false;

            // Addition
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            // Subtraction
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Multiplication
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Division
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedleftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timeLabel.BackColor = System.Drawing.Color.Transparent;
            timer1.Start();

            // Disable start button while quiz is running
            startButton.Enabled = false;
        }

        /// <summary>
        /// Event handler for Start button click
        /// </summary>
        private void StartButton_Click(object? sender, EventArgs e)
        {
            StartTheQuiz();
        }

        /// <summary>
        /// Timer Tick: runs each second
        /// </summary>
        private void Timer1_Tick(object? sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
                timeLabel.BackColor = System.Drawing.Color.Transparent;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";

                // Change color when 5 seconds remain
                if (timeLeft <= 5)
                    timeLabel.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");

                // Show correct answers
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;

                // Reset timeLabel color
                timeLabel.BackColor = System.Drawing.Color.Transparent;

                startButton.Enabled = true;
            }
        }

        /// <summary>
        /// Checks whether all answers are correct
        /// </summary>
        private bool CheckTheAnswer()
        {
            return (sum.Value == addend1 + addend2)
                && (difference.Value == minuend - subtrahend)
                && (product.Value == multiplicand * multiplier)
                && (quotient.Value == dividend / divisor);
        }
    }
}