# Math Quiz WinForms App

## Overview
This is a simple math quiz Windows Forms application built in C#.  
The quiz generates four random math problems — addition, subtraction, multiplication, and division — and gives the user **30 seconds** to answer them.  
The app automatically checks answers and provides feedback.

## Features
- Randomized math problems
- Countdown timer (30 seconds)
- Automatic answer checking
- Shows correct answers if time runs out
- Restart quiz without restarting the app
- NumericUpDown controls auto-select values for easy input

## Prerequisites
- [Visual Studio](https://visualstudio.microsoft.com/) (any recent version with Windows Forms support)
- .NET 6 or later

## How to Run
1. Open the solution (`MathQuiz.sln`) in Visual Studio.
2. Build the project by pressing **Ctrl+Shift+B**.
3. Run the project by pressing **F5** or clicking **Start**.
4. The Math Quiz form will appear.

## How to Use
1. Click the **Start the quiz** button.
2. Answer the four random math problems using the **NumericUpDown** controls.
3. You have **30 seconds** to complete the quiz.
4. The timer counts down each second:
   - If all answers are correct before time runs out:
     - A congratulatory message appears.
     - You can start a new quiz by clicking **Start the quiz** again.
   - If time runs out before completing:
     - A "Time's up!" message appears.
     - Correct answers are shown automatically.
     - The start button becomes available to restart the quiz.
5. Click on any NumericUpDown to automatically select its value for easy editing.

## Customization
- Change quiz duration by modifying `timeLeft` in `Form1.cs`.
- Change the number range of problems by adjusting `Random.Next()` in `StartTheQuiz()`.
- Customize appearance in `Form1.Designer.cs` (colors, fonts, and layout).

## License
This project is free to use and modify for learning purposes.
